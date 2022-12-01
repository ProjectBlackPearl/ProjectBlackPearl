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

        //Sets Download Method 1's Name
        [Category("Data")]
        public string Method1Name
        {
            get { return DLMethod1.MethodName; }
            set { SetMethod1DL(value); }
        }
        public void SetMethod1DL(string Name)
        {
            DLMethod1.MethodName = Name;
        }

        [Category("Data")]
        public string Method1Image
        {
            get { return DLMethod1.ImageToDisplay; }
            set { SetMethod1Image(value); }
        }
        public void SetMethod1Image(string Path)
        {
            DLMethod1.ImageToDisplay = Path;
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

        //Sets Download Method 2's Name
        [Category("Data")]
        public string Method2Name
        {
            get { return DLMethod2.MethodName; }
            set { SetMethod2DL(value); }
        }
        public void SetMethod2DL(string Name)
        {
            DLMethod2.MethodName = Name;
        }

        [Category("Data")]
        public string Method2Image
        {
            get { return DLMethod2.ImageToDisplay; }
            set { SetMethod2Image(value); }
        }
        public void SetMethod2Image(string Path)
        {
            DLMethod2.ImageToDisplay = Path;
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

        //Sets Download Method 3's Name
        [Category("Data")]
        public string Method3Name
        {
            get { return DLMethod3.MethodName; }
            set { SetMethod3DL(value); }
        }
        public void SetMethod3DL(string Name)
        {
            DLMethod3.MethodName = Name;
        }

        [Category("Data")]
        public string Method3Image
        {
            get { return DLMethod3.ImageToDisplay; }
            set { SetMethod3Image(value); }
        }
        public void SetMethod3Image(string Path)
        {
            DLMethod3.ImageToDisplay = Path;
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

        //Sets Download Method 4's Name
        [Category("Data")]
        public string Method4Name
        {
            get { return DLMethod4.MethodName; }
            set { SetMethod4DL(value); }
        }
        public void SetMethod4DL(string Name)
        {
            DLMethod4.MethodName = Name;
        }

        [Category("Data")]
        public string Method4Image
        {
            get { return DLMethod4.ImageToDisplay; }
            set { SetMethod4Image(value); }
        }
        public void SetMethod4Image(string Path)
        {
            DLMethod4.ImageToDisplay = Path;
        }

        //Makes the page invisible
        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
