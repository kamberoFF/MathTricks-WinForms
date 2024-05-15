namespace MathTricks_WinForms
{
    partial class MathTricks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameBoard = new System.Windows.Forms.Panel();
            this.GameInfo = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SimpleAIButton = new System.Windows.Forms.Button();
            this.HardAIButton = new System.Windows.Forms.Button();
            this.MediumAIButton = new System.Windows.Forms.Button();
            this.TurnIndicator = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.Columns = new System.Windows.Forms.NumericUpDown();
            this.Rows = new System.Windows.Forms.NumericUpDown();
            this.ColumnsLabel = new System.Windows.Forms.Label();
            this.RowsLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Columns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rows)).BeginInit();
            this.SuspendLayout();
            // 
            // GameBoard
            // 
            this.GameBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameBoard.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.GameBoard.ForeColor = System.Drawing.Color.White;
            this.GameBoard.Location = new System.Drawing.Point(260, 12);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(1248, 792);
            this.GameBoard.TabIndex = 0;
            // 
            // GameInfo
            // 
            this.GameInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GameInfo.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.GameInfo.ForeColor = System.Drawing.Color.White;
            this.GameInfo.Location = new System.Drawing.Point(12, 12);
            this.GameInfo.Name = "GameInfo";
            this.GameInfo.Size = new System.Drawing.Size(0, 0);
            this.GameInfo.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel1.Controls.Add(this.SimpleAIButton);
            this.panel1.Controls.Add(this.HardAIButton);
            this.panel1.Controls.Add(this.MediumAIButton);
            this.panel1.Controls.Add(this.TurnIndicator);
            this.panel1.Controls.Add(this.StartButton);
            this.panel1.Controls.Add(this.Columns);
            this.panel1.Controls.Add(this.Rows);
            this.panel1.Controls.Add(this.ColumnsLabel);
            this.panel1.Controls.Add(this.RowsLabel);
            this.panel1.Location = new System.Drawing.Point(8, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(243, 792);
            this.panel1.TabIndex = 2;
            // 
            // SimpleAIButton
            // 
            this.SimpleAIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.SimpleAIButton.BackColor = System.Drawing.Color.SpringGreen;
            this.SimpleAIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SimpleAIButton.ForeColor = System.Drawing.Color.Black;
            this.SimpleAIButton.Location = new System.Drawing.Point(8, 652);
            this.SimpleAIButton.Name = "SimpleAIButton";
            this.SimpleAIButton.Size = new System.Drawing.Size(109, 61);
            this.SimpleAIButton.TabIndex = 7;
            this.SimpleAIButton.Text = "Simple AI";
            this.SimpleAIButton.UseVisualStyleBackColor = false;
            this.SimpleAIButton.Click += new System.EventHandler(this.SimpleAIButton_Click);
            // 
            // HardAIButton
            // 
            this.HardAIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.HardAIButton.BackColor = System.Drawing.Color.SpringGreen;
            this.HardAIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HardAIButton.ForeColor = System.Drawing.Color.Black;
            this.HardAIButton.Location = new System.Drawing.Point(47, 720);
            this.HardAIButton.Name = "HardAIButton";
            this.HardAIButton.Size = new System.Drawing.Size(142, 61);
            this.HardAIButton.TabIndex = 6;
            this.HardAIButton.Text = "Hard AI (not working)";
            this.HardAIButton.UseVisualStyleBackColor = false;
            // 
            // MediumAIButton
            // 
            this.MediumAIButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.MediumAIButton.BackColor = System.Drawing.Color.SpringGreen;
            this.MediumAIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MediumAIButton.ForeColor = System.Drawing.Color.Black;
            this.MediumAIButton.Location = new System.Drawing.Point(122, 653);
            this.MediumAIButton.Name = "MediumAIButton";
            this.MediumAIButton.Size = new System.Drawing.Size(114, 61);
            this.MediumAIButton.TabIndex = 5;
            this.MediumAIButton.Text = "Medium AI";
            this.MediumAIButton.UseVisualStyleBackColor = false;
            this.MediumAIButton.Click += new System.EventHandler(this.MediumAIButton_Click);
            // 
            // TurnIndicator
            // 
            this.TurnIndicator.AutoSize = true;
            this.TurnIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TurnIndicator.ForeColor = System.Drawing.Color.Black;
            this.TurnIndicator.Location = new System.Drawing.Point(25, 32);
            this.TurnIndicator.Name = "TurnIndicator";
            this.TurnIndicator.Size = new System.Drawing.Size(193, 29);
            this.TurnIndicator.TabIndex = 4;
            this.TurnIndicator.Text = "It\'s Enemy\'s Turn";
            this.TurnIndicator.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.BackColor = System.Drawing.Color.SpringGreen;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartButton.ForeColor = System.Drawing.Color.Black;
            this.StartButton.Location = new System.Drawing.Point(47, 586);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(142, 61);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "1v1";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // Columns
            // 
            this.Columns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Columns.BackColor = System.Drawing.Color.SpringGreen;
            this.Columns.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Columns.Location = new System.Drawing.Point(30, 399);
            this.Columns.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Columns.Name = "Columns";
            this.Columns.Size = new System.Drawing.Size(141, 27);
            this.Columns.TabIndex = 3;
            this.Columns.ThousandsSeparator = true;
            this.Columns.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Rows
            // 
            this.Rows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Rows.BackColor = System.Drawing.Color.SpringGreen;
            this.Rows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Rows.Location = new System.Drawing.Point(30, 279);
            this.Rows.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Rows.Name = "Rows";
            this.Rows.Size = new System.Drawing.Size(141, 27);
            this.Rows.TabIndex = 2;
            this.Rows.ThousandsSeparator = true;
            this.Rows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // ColumnsLabel
            // 
            this.ColumnsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ColumnsLabel.AutoSize = true;
            this.ColumnsLabel.BackColor = System.Drawing.Color.Transparent;
            this.ColumnsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ColumnsLabel.ForeColor = System.Drawing.Color.Black;
            this.ColumnsLabel.Location = new System.Drawing.Point(45, 364);
            this.ColumnsLabel.Name = "ColumnsLabel";
            this.ColumnsLabel.Size = new System.Drawing.Size(126, 32);
            this.ColumnsLabel.TabIndex = 1;
            this.ColumnsLabel.Text = "Columns";
            // 
            // RowsLabel
            // 
            this.RowsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RowsLabel.AutoSize = true;
            this.RowsLabel.BackColor = System.Drawing.Color.Transparent;
            this.RowsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RowsLabel.ForeColor = System.Drawing.Color.Black;
            this.RowsLabel.Location = new System.Drawing.Point(66, 244);
            this.RowsLabel.Name = "RowsLabel";
            this.RowsLabel.Size = new System.Drawing.Size(84, 32);
            this.RowsLabel.TabIndex = 0;
            this.RowsLabel.Text = "Rows";
            // 
            // MathTricks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1518, 817);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GameInfo);
            this.Controls.Add(this.GameBoard);
            this.Name = "MathTricks";
            this.Text = "MathTricks";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Columns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Rows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel GameBoard;
        private System.Windows.Forms.Panel GameInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label RowsLabel;
        private System.Windows.Forms.Label ColumnsLabel;
        private System.Windows.Forms.NumericUpDown Rows;
        private System.Windows.Forms.NumericUpDown Columns;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label TurnIndicator;
        private System.Windows.Forms.Button MediumAIButton;
        private System.Windows.Forms.Button SimpleAIButton;
        private System.Windows.Forms.Button HardAIButton;
    }
}

