using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using static Project_Black_Pearl.Library;

namespace Project_Black_Pearl
{
    public partial class GamesDisplayContainer : UserControl
    {
        public static string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string completePath = Path.Combine(systemPath, "Project Black Pearl\\");
        public static string GameIDPath = Path.Combine(completePath, "GameIDCount.txt");
        public static string gameinfoPath = Path.Combine(completePath, "GameInfoFolder\\");
        public static string CoversPath = Path.Combine(completePath, "GameCoverImagesAndIcons\\");
        public static string WhitebackgroundPath = Path.Combine(CoversPath, "WhiteBackground.PNG");

        public int CurrentGameID = 0;
        public int CurrentPage = 1;
        public int AmountOfPages;
        public int AmountOfGames;

        public int GamesOnLastPage;
        public int GamesOnCurrentPage;

        public int PanelsToGenerate;

        public int minPanel = 0;
        public int maxPanel = 5;

        public bool isGenerated = false;
        
        //Sets the UI's color
        [Category("Config")]
        public Color UIColor
        {
            get { return GetUIColor(); }
            set { SetUIColor(value); }
        }

        public void SetUIColor(Color UIColor)
        {
            Panel1.UIColor = UIColor;
            Panel2.UIColor = UIColor;

            EditGameScreen.UIColor = UIColor;
            EditGameScreen2.UIColor = UIColor;
            EditGameScreen3.UIColor = UIColor;
            EditGameScreen4.UIColor = UIColor;
            EditGameScreen5.UIColor = UIColor;
            EditGameScreen6.UIColor = UIColor;
        }

        public Color GetUIColor()
        {
            return Panel1.UIColor;
        }              

        public GamesDisplayContainer()
        {
            InitializeComponent();

            if (!Directory.Exists(CoversPath))
            {
                Directory.CreateDirectory(CoversPath);
            }

            if (!File.Exists(WhitebackgroundPath))
            {
                CreateWhiteBackground(80, 80);
            }
        }

        private void GamesDisplayContainer_Load(object sender, EventArgs e)
        {
            GetAmountOfPanels();
            GeneratePanels();
        }

        private void GetAmountOfPanels()
        {
            if (Directory.Exists(gameinfoPath))
            {
                AmountOfGames = Directory.GetFiles(gameinfoPath, "*", SearchOption.TopDirectoryOnly).Length;
            }
            else
            {
                AmountOfGames = 0;
            }

            if (AmountOfGames != 0)
            {
                int gamecount = Convert.ToInt32(AmountOfGames % 6);

                GamesOnLastPage = gamecount;           
            }
            else
            {
                GamesOnLastPage = 0;
            }

            if (GamesOnLastPage != 0)
            {
                AmountOfPages = Convert.ToInt32(AmountOfGames / 6) + 1; 
            }
            else
            {
                AmountOfPages = Convert.ToInt32(AmountOfGames / 6);
            }

            if (AmountOfGames != 0)
            {
                if (CurrentPage == 1)
                {                    
                   if (AmountOfPages == 1)
                   {
                       GamesOnCurrentPage = AmountOfGames;
                   }
                   else
                   {
                       GamesOnCurrentPage = 6;
                   }
                    
                }
                else
                {
                    if(CurrentPage == AmountOfPages)
                    {
                        GamesOnCurrentPage = GamesOnLastPage;
                    }
                    else
                    {
                        GamesOnCurrentPage = 6;
                    }
                }
            }
            else
            {
                GamesOnCurrentPage = 0;
            }

            if (CurrentPage == 1)
            {
                minPanel = 0;
                maxPanel = minPanel + GamesOnCurrentPage - 1;          
            }
            else
            {
                minPanel = (CurrentPage-1) * 6;
                maxPanel = minPanel + GamesOnCurrentPage - 1;
            }

            PanelsToGenerate = maxPanel - minPanel + 1;
            LibraryPage.Text = CurrentPage.ToString();

            if(AmountOfGames == 0)
            {
                NoGamesMessage.Visible = true;
            }
            else
            {
                NoGamesMessage.Visible = false;
            }
        }

        private void GeneratePanels()
        {
            switch (PanelsToGenerate)
            {
                case 1:
                    Panel1.Visible = true;
                    Panel2.Visible = false;

                    EditBTN1.Visible = true;
                    EditBTN2.Visible = false;
                    EditBTN3.Visible = false;
                    EditBTN4.Visible = false;
                    EditBTN5.Visible = false;
                    EditBTN6.Visible = false;

                    break;
                case 2:
                    Panel1.Visible = true;
                    Panel2.Visible = true;

                    EditBTN1.Visible = true;
                    EditBTN2.Visible = true;
                    EditBTN3.Visible = false;
                    EditBTN4.Visible = false;
                    EditBTN5.Visible = false;
                    EditBTN6.Visible = false;

                    break;
                case 3:
                    Panel1.Visible = true;
                    Panel2.Visible = true;

                    EditBTN1.Visible = true;
                    EditBTN2.Visible = true;
                    EditBTN3.Visible = true;
                    EditBTN4.Visible = false;
                    EditBTN5.Visible = false;
                    EditBTN6.Visible = false;

                    break;
                case 4:
                    Panel1.Visible = true;
                    Panel2.Visible = true;

                    EditBTN1.Visible = true;
                    EditBTN2.Visible = true;
                    EditBTN3.Visible = true;
                    EditBTN4.Visible = true;
                    EditBTN5.Visible = false;
                    EditBTN6.Visible = false;

                    break;
                case 5:
                    Panel1.Visible = true;
                    Panel2.Visible = true;

                    EditBTN1.Visible = true;
                    EditBTN2.Visible = true;
                    EditBTN3.Visible = true;
                    EditBTN4.Visible = true;
                    EditBTN5.Visible = true;
                    EditBTN6.Visible = false;

                    break;
                case 6:
                    Panel1.Visible = true;
                    Panel2.Visible = true;

                    EditBTN1.Visible = true;
                    EditBTN2.Visible = true;
                    EditBTN3.Visible = true;
                    EditBTN4.Visible = true;
                    EditBTN5.Visible = true;
                    EditBTN6.Visible = true;

                    break;
            }

            GetCurrentGameID();

            for (int i = 0; i < PanelsToGenerate; i++)
            {
                string filepath = gameinfoPath + "GameInfo" + CurrentGameID.ToString() + ".JSON";
                string contents = File.ReadAllText(filepath);
                Game CurrentGame = JsonSerializer.Deserialize<Game>(contents)!;

                switch (i)
                {
                    case 0:
                        Panel1.GameTitleDisplay = CurrentGame.GameName;
                        Panel1.GamePathString = CurrentGame.GamePath;

                        if(CurrentGame.GamePlaytime != 0)
                        {
                            Panel1.PlaytimeDisplay = CurrentGame.GamePlaytime.ToString() + " Hrs";
                        }
                        else
                        {
                            Panel1.PlaytimeDisplay = "-";
                        }
                       
                        if (CurrentGame.GameSize != 0)
                        {
                            Panel1.SizeDisplay = CurrentGame.GameSize.ToString() + " GB";
                        }
                        else
                        {
                            Panel1.SizeDisplay = "-";
                        }

                        if(CurrentGame.GameCoverImage != "")
                        {
                            Panel1.CoverImagePath = CurrentGame.GameCoverImage;
                        }
                        else
                        {
                            Panel1.CoverImagePath = WhitebackgroundPath;
                        }

                        break;
                    case 1:
                        Panel2.GameTitleDisplay = CurrentGame.GameName;
                        Panel2.GamePathString = CurrentGame.GamePath;

                        if (CurrentGame.GamePlaytime != 0)
                        {
                            Panel2.PlaytimeDisplay = CurrentGame.GamePlaytime.ToString() + " Hrs";
                        }
                        else
                        {
                            Panel2.PlaytimeDisplay = "-";
                        }

                        if (CurrentGame.GameSize != 0)
                        {
                            Panel2.SizeDisplay = CurrentGame.GameSize.ToString() + " GB";
                        }
                        else
                        {
                            Panel2.SizeDisplay = "-";
                        }

                        if (CurrentGame.GameCoverImage != "")
                        {
                            Panel2.CoverImagePath = CurrentGame.GameCoverImage;
                        }
                        else
                        {
                            Panel2.CoverImagePath = WhitebackgroundPath;
                        }

                        break;
                }

                CurrentGameID++;
            }
        }

        private void GetCurrentGameID()
        {
            if(CurrentPage == 1)
            {
                CurrentGameID = 0;
            }
            else
            {
                CurrentGameID = (CurrentPage - 1) * 6;
            }
        }

        private void NextPageBTN_Click(object sender, EventArgs e)
        {
            if(CurrentPage != AmountOfPages)
            {
                CurrentPage += 1;
                isGenerated = false;
                LibraryPage.Text = AmountOfPages.ToString();
            }

            if (!isGenerated)
            {
                GetAmountOfPanels();
                GeneratePanels();
                isGenerated = true;
            }      
        }

        private void PreviousPageBTN_Click(object sender, EventArgs e)
        {
            if(CurrentPage != 1)
            {
                CurrentPage -= 1;
                isGenerated = false;
                LibraryPage.Text = CurrentPage.ToString();
            }

            if (!isGenerated)
            {
                GetAmountOfPanels();
                GeneratePanels();
                isGenerated = true;
            }
        }

        private void RefreshPageButton_Click(object sender, EventArgs e)
        {
            GetAmountOfPanels();
            GeneratePanels();
        }

        private void CreateWhiteBackground(int x, int y)
        {
            Bitmap bmp = new Bitmap(x, y);
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle ImageSize = new Rectangle(0, 0, x, y);
                int R = 199;
                int G = 0;
                int B = 57;

                SolidBrush mybrush = new SolidBrush(Color.FromArgb(255, (byte)R, (byte)G, (byte)B));
                graph.FillRectangle(mybrush, ImageSize);
            }

            bmp.Save(WhitebackgroundPath);
        }

        private void EditBTN1_Click(object sender, EventArgs e)
        {
            int GameToLoad = minPanel;
            string filepath = gameinfoPath + "GameInfo" + GameToLoad.ToString() + ".JSON";
            string contents = File.ReadAllText(filepath);

            Game GameToEdit = JsonSerializer.Deserialize<Game>(contents)!;

            EditGameScreen.GameID = GameToLoad;
            EditGameScreen.GameName = GameToEdit.GameName;
            EditGameScreen.GamePlaytime = Convert.ToDouble(GameToEdit.GamePlaytime);
            EditGameScreen.GameSize = Convert.ToDouble(GameToEdit.GameSize);
            EditGameScreen.GamePath = GameToEdit.GamePath;

            EditGameScreen.BringToFront();
            EditGameScreen.Visible = true;
        }

        private void EditBTN2_Click(object sender, EventArgs e)
        {
            int GameToLoad = minPanel + 1;
            string filepath = gameinfoPath + "GameInfo" + GameToLoad.ToString() + ".JSON";
            string contents = File.ReadAllText(filepath);

            Game GameToEdit = JsonSerializer.Deserialize<Game>(contents)!;

            EditGameScreen2.GameID = GameToLoad;
            EditGameScreen2.GameName = GameToEdit.GameName;
            EditGameScreen2.GamePlaytime = Convert.ToDouble(GameToEdit.GamePlaytime);
            EditGameScreen2.GameSize = Convert.ToDouble(GameToEdit.GameSize);
            EditGameScreen2.GamePath = GameToEdit.GamePath;

            EditGameScreen2.BringToFront();
            EditGameScreen2.Visible = true;
        }

        private void EditBTN3_Click(object sender, EventArgs e)
        {
            int GameToLoad = minPanel + 2;
            string filepath = gameinfoPath + "GameInfo" + GameToLoad.ToString() + ".JSON";
            string contents = File.ReadAllText(filepath);

            Game GameToEdit = JsonSerializer.Deserialize<Game>(contents)!;

            EditGameScreen3.GameID = GameToLoad;
            EditGameScreen3.GameName = GameToEdit.GameName;
            EditGameScreen3.GamePlaytime = Convert.ToDouble(GameToEdit.GamePlaytime);
            EditGameScreen3.GameSize = Convert.ToDouble(GameToEdit.GameSize);
            EditGameScreen3.GamePath = GameToEdit.GamePath;

            EditGameScreen3.BringToFront();
            EditGameScreen3.Visible = true;
        }

        private void EditBTN4_Click(object sender, EventArgs e)
        {
            int GameToLoad = minPanel + 3;
            string filepath = gameinfoPath + "GameInfo" + GameToLoad.ToString() + ".JSON";
            string contents = File.ReadAllText(filepath);

            Game GameToEdit = JsonSerializer.Deserialize<Game>(contents)!;

            EditGameScreen4.GameID = GameToLoad;
            EditGameScreen4.GameName = GameToEdit.GameName;
            EditGameScreen4.GamePlaytime = Convert.ToDouble(GameToEdit.GamePlaytime);
            EditGameScreen4.GameSize = Convert.ToDouble(GameToEdit.GameSize);
            EditGameScreen4.GamePath = GameToEdit.GamePath;

            EditGameScreen4.BringToFront();
            EditGameScreen4.Visible = true;
        }

        private void EditBTN5_Click(object sender, EventArgs e)
        {
            int GameToLoad = minPanel + 4;
            string filepath = gameinfoPath + "GameInfo" + GameToLoad.ToString() + ".JSON";
            string contents = File.ReadAllText(filepath);

            Game GameToEdit = JsonSerializer.Deserialize<Game>(contents)!;

            EditGameScreen5.GameID = GameToLoad;
            EditGameScreen5.GameName = GameToEdit.GameName;
            EditGameScreen5.GamePlaytime = Convert.ToDouble(GameToEdit.GamePlaytime);
            EditGameScreen5.GameSize = Convert.ToDouble(GameToEdit.GameSize);
            EditGameScreen5.GamePath = GameToEdit.GamePath;

            EditGameScreen5.BringToFront();
            EditGameScreen5.Visible = true;
        }

        private void EditBTN6_Click(object sender, EventArgs e)
        {
            int GameToLoad = maxPanel;
            string filepath = gameinfoPath + "GameInfo" + GameToLoad.ToString() + ".JSON";
            string contents = File.ReadAllText(filepath);

            Game GameToEdit = JsonSerializer.Deserialize<Game>(contents)!;

            EditGameScreen6.GameID = GameToLoad;
            EditGameScreen6.GameName = GameToEdit.GameName;
            EditGameScreen6.GamePlaytime = Convert.ToDouble(GameToEdit.GamePlaytime);
            EditGameScreen6.GameSize = Convert.ToDouble(GameToEdit.GameSize);
            EditGameScreen6.GamePath = GameToEdit.GamePath;

            EditGameScreen6.BringToFront();
            EditGameScreen6.Visible = true;
        }

        public static string ShortenStrings(string UneditedString, int LengthOfString)
        {
            string RegularString = UneditedString;
            string ShortenedString = "";

            if (RegularString.Length < LengthOfString)
            {
                ShortenedString = RegularString;
            }
            else
            {
                for (int i = 0; i < LengthOfString - 3; i++)
                {
                    char c = RegularString[i];
                    ShortenedString += c;

                }
                ShortenedString += "...";
            }                     
            return ShortenedString;
        }
    }
}
