using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Project_Black_Pearl
{
    public partial class GameLibraryDisplayPanel : UserControl
    {
        public string GamePath = "";

        public GameLibraryDisplayPanel()
        {
            InitializeComponent();

        }

        //Sets the UI's color
        [Category("Config")]
        public Color UIColor
        {
            get { return GetUIColor(); }
            set { SetUIColor(value); }
        }

        public void SetUIColor(Color UIColor)
        {
            panel1.BackColor = UIColor;
        }

        public Color GetUIColor()
        {
            return panel1.BackColor;
        }

        //Makes the properties of Playtime label accessible from the designer
        [Category("Panel")]
        public string PlaytimeDisplay
        {
            get { return GetPlayTime(); }
            set { SetPlayTime(value); }
        }

        //Sets the value of Playtime label
        public void SetPlayTime(string PlayTime)
        {
            PlaytimeDisplayLabel.Text = PlayTime;
        }

        //Retrieves the value of Playtime label
        public string GetPlayTime()
        {
            return PlaytimeDisplayLabel.Text;
        }

        //Makes the properties of Size label accessible from the designer
        [Category("Panel")]
        public string SizeDisplay
        {
            get { return GetSize(); }
            set { SetSize(value); }
        }

        //Sets the value of Size label
        public void SetSize(string Size)
        {
            SizeDisplayLabel.Text = Size;
        }

        //Retrieves the value of Size label
        public string GetSize()
        {
            return SizeDisplayLabel.Text;
        }

        //Makes the properties of LastLaunch label accessible from the designer
        [Category("Panel")]
        public string LastLaunchDisplay
        {
            get { return GetLastLaunch(); }
            set { SetLastLaunch(value); }
        }

        //Sets the value of LastLaunch label
        public void SetLastLaunch(string LastLaunch)
        {
            LastLaunchDisplayLabel.Text = LastLaunch;
        }

        //Retrieves the value of LastLaunch label
        public string GetLastLaunch()
        {
            return LastLaunchDisplayLabel.Text;
        }

        //Makes the properties of GameTitle label accessible from the designer
        [Category("Panel")]
        public string GameTitleDisplay
        {
            get { return GetGameTitle(); }
            set { SetGameTitle(value); }
        }

        //Sets the value of GameTitle label
        public void SetGameTitle(string GameTitle)
        {
            GameTitleDisplayLabel.Text = GameTitle;
        }

        //Retrieves the value of GameTitle label
        public string GetGameTitle()
        {
            return GameTitleDisplayLabel.Text;
        }

        //Resizes the image to fit the picturebox
        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate  width with new desired size  
            nPercentW = ((float)size.Width / (float)sourceWidth);
            //Calculate height with new desired size  
            nPercentH = ((float)size.Height / (float)sourceHeight);
            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;
            //New Width  
            int destWidth = (int)(sourceWidth * nPercent);
            //New Height  
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Draw image with new width and height  
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return (System.Drawing.Image)b;
        }

        //Makes the properties of CoverImagePath accessible from the designer
        [Category("Panel")]
        public string CoverImagePath
        {
            get { return GetImage(); }
            set { SetImage(value); }
        }

        //Sets the value of CoverImagePath in the picture box
        public void SetImage(string ImagePath)
        {
            if (ImagePath != "")
            {
                Image img = Image.FromFile(ImagePath);
                Bitmap b = new Bitmap(img);
                Image i = resizeImage(b, new Size(60, 60));

                GameCoverPictureBox.Image = i;

                b.Dispose();
            }
        }

        //Retrieves the value of CoverImagePath
        public string GetImage()
        {
            return "";
        }

        [Category("Panel")]
        public string GamePathString
        {
            get { return GetPath(); }
            set { SetPath(value); }
        }

        public void SetPath(string GamePathString)
        {
            GamePath = GamePathString;
        }

        public string GetPath()
        {
            return GamePath;
        }

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            if(GamePath != "")
            {
                Process.Start(GamePath);
            }
        }
    }
}