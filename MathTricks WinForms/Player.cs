using System.Collections.Generic;
using System.Windows.Forms;

namespace MathTricks_WinForms
{
    internal class Player
    {
        public int[] position { get; set; }
        public int score { get; set; }
        public List<Button> moves { get; set; }
        public string lastExpession { get; set; }
    }
}
