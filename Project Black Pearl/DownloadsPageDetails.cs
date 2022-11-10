using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Black_Pearl
{
    public partial class DownloadsPageDetails : UserControl
    {
        public DownloadsPageDetails()
        {
            InitializeComponent();
        }


        [Category("Data")]
        //Game Name
        public string CurrentGameName = "Name";
        public string GameName
        {
            get { return CurrentGameName; }
            set { SetGameName(value); }
        }
        public void SetGameName(string Name)
        {
            GameNameLabel.Text = Name;
        }

        [Category("Data")]
        //Game Source
        public string CurrentGameSource = "-";
        public string GameSource
        {
            get { return CurrentGameSource; }
            set { SetGameSource(value); }
        }
        public void SetGameSource(string Source)
        {
            GameSourceLabel.Text = Source;
            CurrentGameSource = Source;
        }

        [Category("Data")]
        //Game Description
        public string CurrentDescription = "-";
        public string GameDescription
        {
            get { return CurrentDescription; }
            set { SetGameDescription(value); }
        }
        public void SetGameDescription(string Description)
        {
            GameDescriptionLabel.Text = AddNewLines(Description, 145, Description.Length);
        }


        //Adds a new line character after reaching the edge of the page to fit the window
        public string AddNewLines(string UneditedString, int CutoffIndex, int StringLength)
        {
            string RegularString = UneditedString;
            string EditedString = "";

            if (UneditedString.Length < StringLength)
            {
                EditedString = RegularString;
            }
            else
            {
                for (int i = 0; i < StringLength; i++)
                {
                    if (i == CutoffIndex)
                    {
                        EditedString += "\n";
                    }
                    char c = RegularString[i];
                    EditedString += c;
                }
            }

            return EditedString;
        }


        //Sets Download Method 1's URL
        [Category("Data")]
        public List<string> Method1URL
        {
            get { return DLMethod1.DownloadURI; }
            set { SetDL1(value); }
        }
        public void SetDL1(List<string> URL)
        {
            DLMethod1.DownloadURI = URL;
        }

        //Sets Download Method 2's URL
        [Category("Data")]
        public List<string> Method2URL
        {
            get { return DLMethod2.DownloadURI; }
            set { SetDL2(value); }
        }
        public void SetDL2(List<string> URL)
        {
            DLMethod2.DownloadURI = URL;
        }

        //Sets Download Method 3's URL
        [Category("Data")]
        public List<string> Method3URL
        {
            get { return DLMethod3.DownloadURI; }
            set { SetDL3(value); }
        }
        public void SetDL3(List<string> URL)
        {
            DLMethod3.DownloadURI = URL;
        }

        //Sets Download Method 4's URL
        [Category("Data")]
        public List<string> Method4URL
        {
            get { return DLMethod4.DownloadURI; }
            set { SetDL4(value); }
        }
        public void SetDL4(List<string> URL)
        {
            DLMethod4.DownloadURI = URL;
        }


        //Makes the page invisible
        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
