using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathTricks_WinForms
{
    public partial class MathTricks : Form
    {
        #region TODO
        //Izchisti koda Gore-Dolu
        //Napravi algoritum koito generira chisla i operatori suobrazno razmera na board-a
        //Napravi Hard AI
        //HARD Dobaví multiplayer
        #endregion

        #region DONE
        //Opravi smqtaneto DONE
        //Opravi check-vaneto na hodove DONE
        //Opravi da se pokazva koi e na hod Done
        //Oprate da se swapva teksta na butonite adekvatno DONE
        //Napravi reset na igrata DONE
        //Vizualno podobri igrata DONE
        #endregion

        Random rng = new Random();
        char[] operators = { '+', '+', '-', '-', 'x', '÷' };

        Player player;
        Player enemy;

        bool playerTurn;

        List<Button> possibleMoves;

        int rows;
        int columns;

        int AILevel = 0;
        public MathTricks()
        {
            InitializeComponent();
            TurnIndicator.Text = string.Empty;
            Resize += new EventHandler(ResizeButtons);
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StartButton.Text = "1v1";

            player = new Player();
            enemy = new Player();
            playerTurn = true;

            GameBoard.Controls.Clear();
            SetupGrid();
            AdjustButtonSizes();
        }

        private void SetupGrid()
        {
            rows = (int)Rows.Value;
            columns = (int)Columns.Value;
            int margin = 10;

            int minDimension = Math.Min(GameBoard.Width, GameBoard.Height);
            int buttonSize = (minDimension - 2 * margin) / Math.Max(rows, columns);

            // Calculate the total width and height of all buttons
            int totalButtonWidth = columns * buttonSize + (columns - 1) * margin;
            int totalButtonHeight = rows * buttonSize + (rows - 1) * margin;

            // Calculate the starting position for centering
            int startX = (GameBoard.Width - totalButtonWidth) / 2;
            int startY = (GameBoard.Height - totalButtonHeight) / 2;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Button button = new Button();
                    char operation = GenerateRandomOperator();
                    int number = GenerateRandomNumber(operation);
                    button.Tag = $"{i}{j}";
                    button.Text = $"{operation}{number}";
                    button.Width = buttonSize;
                    button.Height = buttonSize;

                    SetupButton(button);

                    // Calculate button's position
                    int x = startX + j * (buttonSize + margin);
                    int y = startY + i * (buttonSize + margin);

                    button.Left = x;
                    button.Top = y;
                    GameBoard.Controls.Add(button);
                }
            }

            //Setup Player
            player.position = new int[] { 0, 0 };
            player.score = 0;
            player.moves = new List<Button>();

            //Setup Enemy
            enemy.position = new int[] { rows - 1, columns - 1 };
            enemy.score = 0;
            enemy.moves = new List<Button>();

            //Add starting positions
            player.moves.Add((Button)GameBoard.Controls[player.position[0] * columns + player.position[1]]);
            enemy.moves.Add((Button)GameBoard.Controls[enemy.position[0] * columns + enemy.position[1]]);

            //Setup starting positions

            GameBoard.Controls[player.position[0] * columns + player.position[1]].BackColor = GameColors.PlayerColor;
            player.lastExpession = GameBoard.Controls[player.position[0] * columns + player.position[1]].Text;
            GameBoard.Controls[player.position[0] * columns + player.position[1]].Text = "0";
            AdjustButtonFontSize(GameBoard.Controls[player.position[0] * columns + player.position[1]] as Button);

            GameBoard.Controls[enemy.position[0] * columns + enemy.position[1]].BackColor = GameColors.EnemyColor;
            enemy.lastExpession = GameBoard.Controls[enemy.position[0] * columns + enemy.position[1]].Text;
            GameBoard.Controls[enemy.position[0] * columns + enemy.position[1]].Text = "0";
            AdjustButtonFontSize(GameBoard.Controls[enemy.position[0] * columns + enemy.position[1]] as Button);

            TurnIndicator.Text = "Player's turn";

            possibleMoves = ShowPossibleMoves();
        }

        private async void GameButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            string move = (string)btn.Tag;

            int row = int.Parse(move[0].ToString());
            int col = int.Parse(move[1].ToString());

            if (playerTurn)
            {
                if (CheckMove(player, btn))
                {
                    player.position = new int[] { row, col };
                    SwapExpressions(player.moves[player.moves.Count - 1], btn);
                    player.moves.Add((Button)GameBoard.Controls[player.position[0] * columns + player.position[1]]);

                    btn.BackColor = GameColors.PlayerColor;
                    btn.Text = player.score.ToString();
                    AdjustButtonFontSize(btn);

                    TurnIndicator.Text = "Enemy's turn";
                    playerTurn = false;
                }
            }
            else
            {
                if (CheckMove(enemy, btn))
                {
                    enemy.position = new int[] { row, col };
                    SwapExpressions(enemy.moves[enemy.moves.Count - 1], btn);
                    enemy.moves.Add((Button)GameBoard.Controls[enemy.position[0] * columns + enemy.position[1]]);

                    btn.BackColor = GameColors.EnemyColor;
                    btn.Text = enemy.score.ToString();
                    AdjustButtonFontSize(btn);

                    TurnIndicator.Text = "Player's turn";
                    playerTurn = true;
                }
            }

            DeColourUnplayedPossibleMoves(btn, possibleMoves);
            possibleMoves = ShowPossibleMoves();

            CheckWin();

            await Task.Delay(1000);

            if (!playerTurn && AILevel == 1)
            {
                SimpleAI();
            }
            else if (!playerTurn && AILevel == 2)
            {
                MediumAI();
            }
            else if (!playerTurn && AILevel == 3)
            {
                //HardAI();
            }
        }

        private int CalculateScore(int score, string toBeAdded)
        {
            string expression = toBeAdded.Split(new char[] { '+', '-', 'x', '÷' }, StringSplitOptions.RemoveEmptyEntries)[0];

            if (toBeAdded[0] == '+')
            {
                return score += int.Parse(expression);
            }
            else if (toBeAdded[0] == '-')
            {
                return score -= int.Parse(expression);
            }
            else if (toBeAdded[0] == 'x')
            {
                return score *= int.Parse(expression);
            }
            else
            {
                return score /= int.Parse(expression);
            }
        }

        private void CheckWin()
        {
            if (possibleMoves.Count == 0)
            {
                if (player.score > enemy.score)
                {
                    MessageBox.Show("Player wins!");
                }
                else if (player.score < enemy.score)
                {
                    MessageBox.Show("Enemy wins!");
                }
                else
                {
                    MessageBox.Show("It's a draw!");
                }

                DisableButtons();
                StartButton.Text = "Restart";
                AdjustButtonFontSize(StartButton);
            }
        }

        private void SetupButton(Button btn)
        {
            btn.BackColor = GameColors.BackgorundColor;
            AdjustButtonFontSize(btn);
            btn.ForeColor = Color.Black;
            btn.Name = btn.Text;
            btn.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btn.Click += new EventHandler(GameButtonClick);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.Black;
        }

        private void AdjustButtonFontSize(Button button)
        {
            int maxFontSize = 20; // Set your desired maximum font size

            int padding = 10; // Set your desired padding

            // Calculate the maximum width and height that the text can occupy within the button
            int maxWidth = button.Width - padding; // Adjust for padding if any
            int maxHeight = button.Height - padding; // Adjust for padding if any

            // Create a temporary font with the maximum font size
            Font tempFont = new Font(button.Font.FontFamily, maxFontSize);

            // Measure the size of the text with the temporary font
            SizeF textSize = TextRenderer.MeasureText(button.Text, tempFont);

            // Calculate the optimal font size that fits within the maximum width and height
            float widthRatio = maxWidth / textSize.Width;
            float heightRatio = maxHeight / textSize.Height;
            float ratio = Math.Min(widthRatio, heightRatio);
            float fontSize = maxFontSize * ratio;

            // Set the font size of the button accordingly
            button.Font = new Font(button.Font.FontFamily, fontSize);
        }

        char GenerateRandomOperator()
        {
            //Random operator is generated
            //Can make an algorithm for the operators depending on the board size
            return operators[rng.Next(0, operators.Length)];
        }

        int GenerateRandomNumber(char operation)
        {
            //Numbers are generated based on the operation
            //Can make an algorithm for the range of numbers depending on the board size

            switch (operation)
            {
                case '+':
                    return rng.Next(0, 31);
                case '-':
                    return rng.Next(0, 31);
                case 'x':
                    return rng.Next(0, 11);
                case '÷':
                    return rng.Next(1, 11);
                default:
                    return 0;
            }
        }

        private void DisableButtons()
        {
            foreach (Button btn in GameBoard.Controls)
                btn.Enabled = false;
        }

        private void SwapExpressions(Button lastButton, Button newButton)
        {
            // Store the current text of the button
            string currentText = newButton.Text;

            // Update the last expression of the appropriate player with the current text of the button
            if (playerTurn)
            {
                player.score = CalculateScore(player.score, currentText);
                lastButton.Text = player.lastExpession;
                AdjustButtonFontSize(lastButton);
                newButton.Text = player.score.ToString();
                AdjustButtonFontSize(newButton);
                player.moves.Add(newButton);
                player.lastExpession = currentText;
            }
            else
            {
                enemy.score = CalculateScore(enemy.score, currentText);
                lastButton.Text = enemy.lastExpession;
                AdjustButtonFontSize(lastButton);
                newButton.Text = enemy.score.ToString();
                AdjustButtonFontSize(newButton);
                enemy.moves.Add(newButton);
                enemy.lastExpession = currentText;
            }
        }

        private bool CheckMove(Player player, Button newMove)
        {
            string move = (string)newMove.Tag;

            // Check if the move array contains at least two elements
            if (move.Length < 2)
            {
                // Handle the case where the move array does not contain enough elements
                // (e.g., invalid format of the tag)
                return false;
            }

            int newRow, newCol;

            // Try to parse the row and column indices
            if (!int.TryParse(move[0].ToString(), out newRow) || !int.TryParse(move[1].ToString(), out newCol))
            {
                // Handle the case where the row or column indices cannot be parsed as integers
                MessageBox.Show("Invalid move format.");
                return false;
            }

            int currentRow = player.position[0];
            int currentCol = player.position[1];

            // Check if the new move is adjacent to the current position
            if (Math.Abs(newRow - currentRow) <= 1 && Math.Abs(newCol - currentCol) <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private List<Button> ShowPossibleMoves()
        {
            int row = playerTurn ? player.position[0] : enemy.position[0];
            int col = playerTurn ? player.position[1] : enemy.position[1];
            Color color = playerTurn ? GameColors.PlayerMarkedColor : GameColors.EnemyMarkedColor;
            List<Button> possibleMoves = new List<Button>();

            if (row + 1 < rows && GameBoard.Controls[(row + 1) * columns + col].BackColor == GameColors.BackgorundColor)
                possibleMoves.Add((Button)GameBoard.Controls[(row + 1) * columns + col]);
            if (row + 1 < rows && col + 1 < columns && GameBoard.Controls[(row + 1) * columns + col + 1].BackColor == GameColors.BackgorundColor)
                possibleMoves.Add((Button)GameBoard.Controls[(row + 1) * columns + col + 1]);
            if (row + 1 < rows && col - 1 >= 0 && GameBoard.Controls[(row + 1) * columns + col - 1].BackColor == GameColors.BackgorundColor)
                possibleMoves.Add((Button)GameBoard.Controls[(row + 1) * columns + col - 1]);
            if (row - 1 >= 0 && GameBoard.Controls[(row - 1) * columns + col].BackColor == GameColors.BackgorundColor)
                possibleMoves.Add((Button)GameBoard.Controls[(row - 1) * columns + col]);
            if (row - 1 >= 0 && col + 1 < columns && GameBoard.Controls[(row - 1) * columns + col + 1].BackColor == GameColors.BackgorundColor)
                possibleMoves.Add((Button)GameBoard.Controls[(row - 1) * columns + col + 1]);
            if (row - 1 >= 0 && col - 1 >= 0 && GameBoard.Controls[(row - 1) * columns + col - 1].BackColor == GameColors.BackgorundColor)
                possibleMoves.Add((Button)GameBoard.Controls[(row - 1) * columns + col - 1]);
            if (col + 1 < columns && GameBoard.Controls[row * columns + col + 1].BackColor == GameColors.BackgorundColor)
                possibleMoves.Add((Button)GameBoard.Controls[row * columns + col + 1]);
            if (col - 1 >= 0 && GameBoard.Controls[row * columns + col - 1].BackColor == GameColors.BackgorundColor)
                possibleMoves.Add((Button)GameBoard.Controls[row * columns + col - 1]);

            foreach (Button btn in possibleMoves)
                btn.BackColor = color;

            return possibleMoves;
        }

        private void DeColourUnplayedPossibleMoves(Button newMove, List<Button> possibleMoves)
        {
            possibleMoves.Remove(newMove);

            foreach (Button btn in possibleMoves)
                btn.BackColor = GameColors.BackgorundColor;
        }

        private void ResizeButtons(object sender, EventArgs e)
        {
            if (GameBoard.Controls.Count > 0)
                AdjustButtonSizes();
        }

        private void AdjustButtonSizes()
        {
            int margin = 10;

            // Calculate the minimum dimension of the GameBoard panel
            int minDimension = Math.Min(GameBoard.Width, GameBoard.Height);

            // Calculate the size of each button
            int buttonSize = (minDimension - (Math.Max(rows, columns) - 1) * margin) / Math.Max(rows, columns);

            // Calculate the total width and height of all buttons including margins
            int totalButtonWidth = columns * buttonSize + (columns - 1) * margin;
            int totalButtonHeight = rows * buttonSize + (rows - 1) * margin;

            // Calculate the starting position for centering
            int startX = (GameBoard.Width - totalButtonWidth) / 2;
            int startY = (GameBoard.Height - totalButtonHeight) / 2;

            foreach (Button btn in GameBoard.Controls)
            {
                int row = int.Parse(btn.Tag.ToString()[0].ToString());
                int col = int.Parse(btn.Tag.ToString()[1].ToString());

                // Calculate the button's position within the panel including margins
                int x = startX + col * (buttonSize + margin);
                int y = startY + row * (buttonSize + margin);

                // Adjust button's position to ensure it fits within the panel
                x = Math.Max(x, 0);
                y = Math.Max(y, 0);
                x = Math.Min(x, GameBoard.Width - buttonSize);
                y = Math.Min(y, GameBoard.Height - buttonSize);

                btn.Left = x;
                btn.Top = y;
                btn.Width = buttonSize;
                btn.Height = buttonSize;

                AdjustButtonFontSize(btn);
            }
        }

        private void SimpleAI()
        {
            Button move = possibleMoves[rng.Next(0, possibleMoves.Count)];

            move.PerformClick();
        }

        private void MediumAI()
        {
            int maxScore = int.MinValue;
            Button bestMove = null;

            foreach (Button btn in possibleMoves)
            {
                int score = CalculateScore(enemy.score, btn.Text);
                if (score > maxScore)
                {
                    maxScore = score;
                    bestMove = btn;
                }
            }

            if (bestMove != null)
                bestMove.PerformClick();

            //My way
            /*
            int score = 0;
            Button bestMove = null;
            List<object[]> scoreButtonPairs = new List<object[]>();

            foreach (Button btn in possibleMoves)
            {
                score = CalculateScore(enemy.score, btn.Text);
                scoreButtonPairs.Add(new object[] { score, btn });
            }

            QuickSortForMyNeed(scoreButtonPairs, 0, scoreButtonPairs.Count - 1);

            bestMove = (Button)scoreButtonPairs[scoreButtonPairs.Count - 1][1];

            bestMove.PerformClick();

            */
        }

        private void QuickSortForMyNeed(List<object[]> items, int start, int end)
        {
            if (start < end)
            {
                int pivot = Partition(items, start, end);

                QuickSortForMyNeed(items, start, pivot - 1);
                QuickSortForMyNeed(items, pivot + 1, end);
            }
        }

        private int Partition(List<object[]> items, int start, int end)
        {
            int pivot = (int)items[end][0];
            int i = start - 1;

            for (int j = start; j < end; j++)
            {
                if ((int)items[j][0] < pivot)
                {
                    i++;
                    object[] temp = items[i];
                    items[i] = items[j];
                    items[j] = temp;
                }
            }

            object[] temp1 = items[i + 1];
            items[i + 1] = items[end];
            items[end] = temp1;

            return i + 1;
        }

        private void SimpleAIButton_Click(object sender, EventArgs e)
        {
            AILevel = 1;
            StartButton.PerformClick();
        }

        private void MediumAIButton_Click(object sender, EventArgs e)
        {
            AILevel = 2;
            StartButton.PerformClick();
        }
    }
}
