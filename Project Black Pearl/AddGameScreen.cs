using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Project_Black_Pearl.Data;
using System.Text.Json;
using System.Drawing.Drawing2D;

namespace Project_Black_Pearl
{
    public partial class Add_Game_Screen : UserControl
    {
        public static string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string completePath = Path.Combine(systemPath, "Project Black Pearl\\");
        public static string gameinfoPath = Path.Combine(completePath, "GameInfoFolder\\");

        //Sets the UI's color
        [Category("Config")]
        public Color UIColor
        {
            get { return GetUIColor(); }
            set { SetUIColor(value); }
        }

        public void SetUIColor(Color UIColor)
        {
            ApplyNewGameBTN.BackColor = UIColor;
            ApplyNewGameBTN.BackgroundColor = UIColor;
        }

        public Color GetUIColor()
        {
            return ApplyNewGameBTN.BackgroundColor;
        }


        public Add_Game_Screen()
        {
            InitializeComponent();
        }

        int game_id;
        string game_name = "...";
        string game_path = "";      
        double game_size = 0f;
        double game_playtime = 0f;
        string game_launcher = "";
        string game_account = "";
        string game_cover_image_path = "";
        string game_description = "";
        bool isIDGenerated = false;
        bool isImageLoaded = false;

        //Triggers the OpenFileDialog to grab the game's path
        private void EditPathBTN_Click(object sender, EventArgs e)
        {
            GrabGamePath();
        }

        //Generates the game's ID
        private void GenerateGameID()
        {
            //If the directory isn't created, creates it manually
            if (!Directory.Exists(completePath))
            {
                Directory.CreateDirectory(completePath);
            }

            //Grabs the game ID if a previous one exits 
            //Sets the ID as 0 if the ID wasn't previously set
            //Grabs the ID from the file and increments it by 1

            if(!File.Exists(completePath + "GameIDCount.txt"))
            {
                game_id = 0;
                File.WriteAllText(completePath + "GameIDCount.txt", 0.ToString());
            }
            else
            {
                string GameIDString = File.ReadAllText(completePath + "GameIDCount.txt");
                game_id = int.Parse(GameIDString) + 1;
                File.WriteAllText(completePath + "GameIDCount.txt", game_id.ToString());
            }
        }

        //Grabs the game's path
        private void GrabGamePath()
        {
            //Opens a file dialog window to choose the game's EXE
            using (OpenFileDialog ofp = new OpenFileDialog())
            {
                ofp.InitialDirectory = "c:\\";

                //Only accepts.exe files
                ofp.Filter = "Executables (*.exe)|*.exe";

                ofp.FilterIndex = 1;
                ofp.RestoreDirectory = true;

                if (ofp.ShowDialog() == DialogResult.OK)
                {
                    PathError.Visible = false;

                    game_path = ofp.FileName;
                    string GamePathParsed = GamesDisplayContainer.ShortenStrings(game_path, 65);
                    PathLbl.Text = GamePathParsed;
                }
                else
                {
                    PathError.Visible = true;
                }
            }
        }

        //Makes the textbox for editing the game name visible
        private void EditGameNameBTN_Click(object sender, EventArgs e)
        {
            GameNameTxtBox.Visible = true;
            ApproveGameNameChangeBTN.Visible = true;
        }

        //Makes the textbox for editing the game name invisible
        //Assigns the input in textbox to a variable
        //Updates the label with the name for UI
        private void ApproveGameNameChangeBTN_Click(object sender, EventArgs e)
        {
            GameNameTxtBox.Visible = false;
            ApproveGameNameChangeBTN.Visible = false;
            game_name = GameNameTxtBox.Texts.ToString();
            GameNameLbl.Text = game_name;

            if (MissingNameError.Visible = true && game_name != "")
            {
                MissingNameError.Visible = false;
            }
        }

        private void EditSizeBTN_Click(object sender, EventArgs e)
        {
            GameSizeTxtBox.Visible = true;
            GBLabel.Visible = true;
            ApproveGameSizeChangeBTN.Visible = true;
        }

        private void ApproveGameSizeChangeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                FormatErrorLbl.Visible = false;
                game_size = Convert.ToDouble(GameSizeTxtBox.Texts);

                GameSizeTxtBox.Visible = false;
                GBLabel.Visible = false;
                ApproveGameSizeChangeBTN.Visible = false;

                SizeLbl.Text = game_size.ToString() + " GB";
            }
            catch (System.FormatException)
            {
                FormatErrorLbl.Visible = true;
            }
        }

        //Creates new instance of the Game class and assigns values of it
        //Then serializes and writes the attributes to a .JSON file
        private void WriteGameInfo()
        {
            if (!isIDGenerated)
            {
                GenerateGameID();
                isIDGenerated = true;
            }

            Game CurrentGame = new Game();
            CurrentGame.GameID = game_id;
            CurrentGame.GameName = game_name;
            CurrentGame.GamePath = game_path;
            CurrentGame.GameSize = game_size;
            CurrentGame.GamePlaytime = game_playtime;
            CurrentGame.GameLauncher = game_launcher;
            CurrentGame.GameAccount = game_account;
            CurrentGame.GameDescription = game_description;
            CurrentGame.GameCoverImage = game_cover_image_path;

            string GameString = JsonSerializer.Serialize(CurrentGame);

            if (!Directory.Exists(gameinfoPath))
            {
                Directory.CreateDirectory(gameinfoPath);
            }

            File.WriteAllText(gameinfoPath + "GameInfo" + game_id.ToString() + ".JSON", GameString);
        }

        //Invokes the WriteGameInfo method when adding a new game
        private void ApplyNewGameBTN_Click(object sender, EventArgs e)
        {
            MissingNameError.Visible = false;
            PathError.Visible = false;

            if (GameNameTxtBox.Texts != "" && PathLbl.Text != "...")
            {
                game_description = DescriptionTextBox.Texts.ToString();

                WriteGameInfo();

                isIDGenerated = false;

                GameNameTxtBox.Texts = "";
                GameSizeTxtBox.Texts = "";
                PlaytimeTxtBox.Texts = "";
                LauncherTxtBox.Texts = "";
                AccountTxtBox.Texts = "";
                DescriptionTextBox.Texts = "";

                GameNameLbl.Text = "...";
                PathLbl.Text = "...";
                SizeLbl.Text = "...";
                PlaytimeLbl.Text = "...";
                LauncherLbl.Text = "...";
                AccountLbl.Text = "...";

                this.Visible = false;
            }
            else
            {
                if (GameNameTxtBox.Texts == "")
                {
                    MissingNameError.Visible = true;
                }
                else if(PathLbl.Text == "...")
                {
                    PathError.Visible = true;
                }                             
            }
        }

        //Makes the edit Play Time text box and confirm button visible
        private void EditPlayTimeBTN_Click(object sender, EventArgs e)
        {
            PlaytimeTxtBox.Visible = true;
            PlaytimeUnitLbl.Visible = true;
            ApprovePlaytimeChangeBTN.Visible = true;
        }

        //Grabs the playtime change value from the text box or throws an error if FormatException is caught
        private void ApprovePlaytimeChangeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                FormatErrorLblPlaytime.Visible = false;
                game_playtime = Convert.ToDouble(PlaytimeTxtBox.Texts);
                PlaytimeTxtBox.Visible = false;
                PlaytimeUnitLbl.Visible = false;
                ApprovePlaytimeChangeBTN.Visible = false;
                PlaytimeLbl.Text = game_playtime.ToString() + "h";
            }
            catch (FormatException)
            {
                FormatErrorLblPlaytime.Visible = true;
            }
        }

        //Creates an OpenFileDialog that accepts .png files for the cover
        //Makes a copy of the image into AppData to preserve it in case they delete the original .png
        //Grabs the path of the image copy and assigns it to GameCoverImagePath variable
        private void GrabImagePath()
        {
            //Generates the ID in case it wasn't previously generated
            if (!isIDGenerated)
            {
                GenerateGameID();
                isIDGenerated = true;
            }

            //Creates the OpenFileDialog
            using (OpenFileDialog ofp = new OpenFileDialog())
            {
                string NewPath = completePath + "GameCoverImagesAndIcons\\";
                string filename = NewPath + "GameCover" + game_id.ToString() + ".png";

                ofp.InitialDirectory = "c:\\";

                //Accepts.png files
                ofp.Filter = "Images (*.png)|*.png";

                ofp.FilterIndex = 1;
                ofp.RestoreDirectory = true;

                if (ofp.ShowDialog() == DialogResult.OK)
                {
                    //Creates a folder specifically for GameCovers
                    string OriginalPath = ofp.FileName;

                    if (!Directory.Exists(NewPath))
                    {
                        Directory.CreateDirectory(NewPath);
                    }

                    if (!isImageLoaded)
                    {
                        Image img = Image.FromFile(OriginalPath);
                        Bitmap b = new Bitmap(img);
                        Image i = resizeImage(b, new Size(128, 128));

                        i.Save(filename);

                        CoverImagePictureBox.Image = i;

                        b.Dispose();

                        isImageLoaded = true;
                        game_cover_image_path = filename;
                    }
                    else
                    {
                        Image img = Image.FromFile(OriginalPath);
                        Bitmap b = new Bitmap(img);
                        Image i = resizeImage(b, new Size(128, 128));

                        if (File.Exists(filename))
                        {
                            File.Delete(filename);
                        }

                        i.Save(filename);

                        CoverImagePictureBox.Image = i;

                        b.Dispose();

                        isImageLoaded = true;
                        game_cover_image_path = filename;
                    }                                    
                }

            }
        }

        //Calls the GrabImagePath method
        private void ChangePictureBTN_Click(object sender, EventArgs e)
        {
            GrabImagePath();
        }

        private void EditLauncherBTN_Click(object sender, EventArgs e)
        {
            LauncherTxtBox.Visible = true;
            ApplyLauncherChangeBTN.Visible = true;
        }

        private void EditAccountBTN_Click(object sender, EventArgs e)
        {
            AccountTxtBox.Visible = true;
            ApplyAccountChangeBTN.Visible = true;
        }

        private void ApplyLauncherChangeBTN_Click(object sender, EventArgs e)
        {
            LauncherTxtBox.Visible = false;
            ApplyLauncherChangeBTN.Visible = false;
            game_launcher = LauncherTxtBox.Texts.ToString();
            LauncherLbl.Text = game_launcher.ToString();
        }

        private void ApplyAccountChangeBTN_Click(object sender, EventArgs e)
        {
            AccountTxtBox.Visible = false;
            ApplyAccountChangeBTN.Visible = false;
            game_account = AccountTxtBox.Texts.ToString();
            AccountLbl.Text = game_account.ToString();
        }

        //Used to resize the image to fit the picturebox
        private static System.Drawing.Image resizeImage(System.Drawing.Image imgToResize, Size size)
        {
            //Get the image current width  
            int sourceWidth = imgToResize.Width;
            //Get the image current height  
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            //Calulate width with new desired size  
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

        private void PreviousPageButton_Click(object sender, EventArgs e)
        {
            GameNameTxtBox.Texts = "";
            GameSizeTxtBox.Texts = "";
            PlaytimeTxtBox.Texts = "";
            LauncherTxtBox.Texts = "";
            AccountTxtBox.Texts = "";
            DescriptionTextBox.Texts = "";

            GameNameLbl.Text = "...";
            PathLbl.Text = "...";
            SizeLbl.Text = "...";
            PlaytimeLbl.Text = "...";
            LauncherLbl.Text = "...";
            AccountLbl.Text = "...";

            this.Visible = false;
        }
    }
}
