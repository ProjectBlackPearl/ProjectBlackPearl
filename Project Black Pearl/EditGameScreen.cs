using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Black_Pearl
{
    public partial class EditGameScreen : UserControl
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

        public EditGameScreen()
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
        bool isImageLoaded = false;
        bool isImageEdited = false;
        int ImageEdits;

        List<string> TempImagesToDelete;

        //GameID
        [Category("InformationInitializer")]
        public int GameID
        {
            get { return game_id; }
            set { SetGameID(value); }
        }
        public void SetGameID(int GameID)
        {
            game_id = GameID;
        }

        //GameName
        [Category("InformationInitializer")]
        public string GameName
        {
            get { return game_name; }
            set { SetGameName(value); }
        }
        public void SetGameName(string GameName)
        {
            game_name = GameName;
            GameNameLbl.Text = GameName;
            GameNameTxtBox.Texts = GameName;
        }


        //GamePath
        [Category("InformationInitializer")]
        public string GamePath
        {
            get { return game_path; }
            set { SetGamePath(value); }
        }
        public void SetGamePath(string GamePath)
        {
            game_path = GamePath;
            PathLbl.Text = GamePath;
        }

        //GameSize
        [Category("InformationInitializer")]
        public double GameSize
        {
            get { return game_size; }
            set { SetGameSize(value); }
        }
        public void SetGameSize(double GameSize)
        {
            game_size = GameSize;

            if(GameSize != 0)
            {
                SizeLbl.Text = GameSize.ToString();
            }
            else
            {
                SizeLbl.Text = "...";
            }

            GameSizeTxtBox.Texts = GameSize.ToString();
        }

        //GamePlaytime
        [Category("InformationInitializer")]
        public double GamePlaytime
        {
            get { return game_playtime; }
            set { SetGamePlaytime(value); }
        }
        public void SetGamePlaytime(double GamePlaytime)
        {
            game_playtime = GamePlaytime;

            if(GamePlaytime != 0)
            {
                PlaytimeLbl.Text = GamePlaytime.ToString();
            }
            else
            {
                PlaytimeLbl.Text = "...";
            }
            PlaytimeTxtBox.Texts = GamePlaytime.ToString();
        }

        //GameLauncher
        [Category("InformationInitializer")]
        public string GameLauncher
        {
            get { return game_launcher; }
            set { SetGameLauncher(value); }
        }
        public void SetGameLauncher(string GameLauncher)
        {
            game_launcher = GameLauncher;

            if (GameLauncher != "")
            {
                LauncherLbl.Text = GameLauncher;
            }
            else
            {
                LauncherLbl.Text = "...";
            }
            LauncherTxtBox.Texts = GameLauncher.ToString();
        }

        //GameAccount
        [Category("InformationInitializer")]
        public string GameAccount
        {
            get { return game_account; }
            set { SetGameAccount(value); }
        }
        public void SetGameAccount(string GameAccount)
        {
            game_account = GameAccount;

            if(GameAccount != "")
            {
                AccountLbl.Text = GameAccount;
            }
            else
            {
                AccountLbl.Text = "...";
            }
            AccountTxtBox.Texts = GameAccount.ToString();
        }

        //Game Name Editing
        private void EditGameNameBTN_Click(object sender, EventArgs e)
        {
            GameNameTxtBox.Visible = true;
            ApproveGameNameChangeBTN.Visible = true;
        }
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

        //Game Path Editing
        private void EditPathBTN_Click(object sender, EventArgs e)
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

                    string GamePathStringUnsplit = game_path;
                    string GamePathParsed = "";

                    if (GamePathStringUnsplit.Length < 65)
                    {
                        GamePathParsed = GamePathStringUnsplit;
                    }
                    else
                    {
                        for (int i = 0; i < 65; i++)
                        {
                            char c = GamePathStringUnsplit[i];
                            GamePathParsed += c;
                        }

                        GamePathParsed += "...";
                    }

                    PathLbl.Text = GamePathParsed;

                }

                else
                {
                    PathError.Visible = true;
                }
            }
        }

        //Game Size Editing
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

                double contents = Convert.ToDouble(GameSizeTxtBox.Texts);
                game_size = contents;

                GameSizeTxtBox.Visible = false;
                GBLabel.Visible = false;
                ApproveGameSizeChangeBTN.Visible = false;

                SizeLbl.Text = contents.ToString() + " GB"; 
            }
            catch (FormatException)
            {
                FormatErrorLbl.Visible = true;
            }
        }

        //Game Playtime Editing
        private void EditPlayTimeBTN_Click(object sender, EventArgs e)
        {
            PlaytimeTxtBox.Visible = true;
            PlaytimeUnitLbl.Visible = true;
            ApprovePlaytimeChangeBTN.Visible = true;
        }
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

        //Game Launcher Editing
        private void EditLauncherBTN_Click(object sender, EventArgs e)
        {
            LauncherTxtBox.Visible = true;
            ApplyLauncherChangeBTN.Visible = true;
        }
        private void ApplyLauncherChangeBTN_Click(object sender, EventArgs e)
        {
            LauncherTxtBox.Visible = false;
            ApplyLauncherChangeBTN.Visible = false;
            game_launcher = LauncherTxtBox.Texts.ToString();
            LauncherLbl.Text = game_launcher.ToString();
        }

        //Game Account Editing
        private void EditAccountBTN_Click(object sender, EventArgs e)
        {
            AccountTxtBox.Visible = true;
            ApplyAccountChangeBTN.Visible = true;
        }
        private void ApplyAccountChangeBTN_Click(object sender, EventArgs e)
        {
            AccountTxtBox.Visible = false;
            ApplyAccountChangeBTN.Visible = false;
            game_account = AccountTxtBox.Texts.ToString();
            AccountLbl.Text = game_account.ToString();
        }

        //Game Cover Editing
        private void ChangePictureBTN_Click(object sender, EventArgs e)
        {
            string infofile = gameinfoPath + "gameinfo" + game_id.ToString() + ".JSON";
            string contents = File.ReadAllText(infofile);

            Game GameToReadFrom = JsonSerializer.Deserialize<Game>(contents)!;
            ImageEdits = Convert.ToInt32(GameToReadFrom.ImageEdits);

            //Creates the OpenFileDialog
            using (OpenFileDialog ofp = new OpenFileDialog())
            {
                string NewPath = completePath + "GameCoverImagesAndIcons\\";
                string filename = NewPath + "GameCover" + game_id.ToString() + "-" + ImageEdits.ToString() + ".png";

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

                    Image img = Image.FromFile(OriginalPath);
                    Bitmap b = new Bitmap(img);
                    Image i = resizeImage(b, new Size(128, 128));

                    i.Save(filename);

                    CoverImagePictureBox.Image = i;

                    b.Dispose();

                    isImageLoaded = true;
                    isImageEdited = true;
                }
            }
        }

        //Used to resize the image to fit the picturebox
        private static Image resizeImage(Image imgToResize, Size size)
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
            return (Image)b;
        }

        private void PreviousPageButton_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void WriteGameInfo()
        {
            Game CurrentGame = new Game();
            CurrentGame.GameID = game_id;
            CurrentGame.GameName = game_name;
            CurrentGame.GamePath = game_path;
            CurrentGame.GameSize = game_size;
            CurrentGame.GamePlaytime = game_playtime;
            CurrentGame.GameLauncher = game_launcher;
            CurrentGame.GameAccount = game_account;
            CurrentGame.GameDescription = game_description;
            CurrentGame.GameCoverImage = completePath + "GameCoverImagesAndIcons\\" + "GameCover" + game_id.ToString() + ".png";


            if (isImageEdited)
            {
                CurrentGame.GameCoverImage = completePath + "GameCoverImagesAndIcons\\" + "GameCover" + game_id.ToString() + "-" + ImageEdits.ToString() + ".png";
                ImageEdits++;
            }

            CurrentGame.ImageEdits = ImageEdits;

            string GameString = JsonSerializer.Serialize(CurrentGame);

            if (!Directory.Exists(gameinfoPath))
            {
                Directory.CreateDirectory(gameinfoPath);
            }

            string ImageToKeep = CurrentGame.GameCoverImage;

            if(ImageEdits != 0)
            {
                string OriginalCover = completePath + "GameCoverImagesAndIcons\\" + "GameCover" + game_id.ToString() + ".png";
                if (File.Exists(OriginalCover))
                {
                    try
                    {
                        File.Delete(OriginalCover);
                    }
                    catch (IOException)
                    {
                    }
                }
            }

            for (int i = 0; i < ImageEdits; i++)
            {
                string filetodelete = completePath + "GameCoverImagesAndIcons\\" + "GameCover" + game_id.ToString() + "-" + i.ToString() + ".png";

                try
                {
                    if (filetodelete != ImageToKeep)
                    {
                        File.Delete(filetodelete);
                    }
                }
                catch (IOException)
                {
                    continue;
                }
                
            }

            File.WriteAllText(gameinfoPath + "GameInfo" + game_id.ToString() + ".JSON", GameString);
        }

        private void ApplyNewGameBTN_Click(object sender, EventArgs e)
        {
            MissingNameError.Visible = false;
            PathError.Visible = false;

            if (GameNameTxtBox.Texts != "" && PathLbl.Text != "...")
            {
                game_description = DescriptionTextBox.Texts.ToString();

                WriteGameInfo();

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
                else if (PathLbl.Text == "...")
                {
                    PathError.Visible = true;
                }
            }
        }
    }
}
