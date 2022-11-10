using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project_Black_Pearl.LauncherForm;

namespace Project_Black_Pearl
{
    public partial class Library : UserControl
    {
        public Library()
        {
            InitializeComponent();
        }

        private void AddGameBTN_Click(object sender, EventArgs e)
        {
            AddGameScreen.BringToFront();
            AddGameScreen.Visible = true;         
        }

        [Category("Config")]
        public Color UIColor
        {
            get { return GetUIColor(); }
            set { SetUIColor(value); }
        }

        public void SetUIColor(Color UIColor)
        {
            AddGameBTN.BackColor = UIColor;
            GamesDisplayContainer.UIColor = UIColor;
            AddGameScreen.UIColor = UIColor;
        }

        public Color GetUIColor()
        {
            return AddGameBTN.BackColor;
        }
    }
}
