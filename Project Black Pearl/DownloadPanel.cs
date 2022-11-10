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
    public partial class DownloadPanel : UserControl
    {
        public DownloadPanel()
        {
            InitializeComponent();
        }


        //Makes the Game Name property of the panel accessible through the designer
        [Category("Panel")]
        public string GameName
        {
            get { return GetGameName(); }
            set { SetGameName(value); }
        }
        public void SetGameName(string GameName)
        {
            NameLabel.Text = GamesDisplayContainer.ShortenStrings(GameName, 64); 
        }
        public string GetGameName()
        {
            return NameLabel.Text;
        }

        //Makes the Source property of the panel accessible through the designer
        [Category("Panel")]
        public string GameSource
        {
            get { return GetGameSource(); }
            set { SetGameSource(value); }
        }
        public void SetGameSource(string Source)
        {
            SourceLabel.Text = Source;
        }
        public string GetGameSource()
        {
            return SourceLabel.Text;
        }

        //Makes the Flag property of the panel accessible through the designer
        public int GameFlagIndex;
        [Category("Panel")]
        public int GameFlag
        {
            get { return GetGameFlag(); }
            set { SetGameFlag(value); }
        }
        public void SetGameFlag(int Index)
        {
            switch (Index)
            {
                case 1:
                    FlagLabel.Text = "Scene";
                    FlagLabel.Location = new Point(886, 31);
                    GameFlagIndex = 1;
                    break;
                case 2:
                    FlagLabel.Text = "Repack";
                    FlagLabel.Location = new Point(875, 31);
                    GameFlagIndex = 2;
                    break;
            }
        }
        public int GetGameFlag()
        {
            return GameFlagIndex;
        }


        //Sets DL Method 1 URL
        public List<string> URL1;
        [Category("Data")]
        public List<string> Method1URL
        {
            get { return URL1; }
            set { SetURL1(value); }
        }
        public void SetURL1(List<string> URL)
        {
            URL1 = URL;
        }

        //Sets DL Method 1 URL
        public List<string> URL2;
        [Category("Data")]
        public List<string> Method2URL
        {
            get { return URL2; }
            set { SetURL2(value); }
        }
        public void SetURL2(List<string> URL)
        {
            URL2 = URL;
        }

        //Sets DL Method 1 URL
        public List<string> URL3;
        [Category("Data")]
        public List<string> Method3URL
        {
            get { return URL3; }
            set { SetURL3(value); }
        }
        public void SetURL3(List<string> URL)
        {
            URL3 = URL;
        }

        //Sets DL Method 1 URL
        public List<string> URL4;
        [Category("Data")]
        public List<string> Method4URL
        {
            get { return URL1; }
            set { SetURL4(value); }
        }
        public void SetURL4(List<string> URL)
        {
            URL4 = URL;
        }
    }
}
