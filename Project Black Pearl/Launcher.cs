using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_Black_Pearl
{
    public partial class LauncherForm : Form
    {
        public static string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string completePath = Path.Combine(systemPath, "Project Black Pearl\\");
        public static string ConfigPath = completePath + "Config.json";
        public static string DownloadsPath = Path.Combine(completePath, "DownloadsInfo");

        public Color AccentColor = Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));

        public int PrevAmountGames = 0;

        //Makes the application draggable
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //Creates rounded corners for the Winform
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public LauncherForm()
        {
            InitializeComponent();
            this.Text = "Project Black Pearl";
            //Gives the winform rounded corners
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));

            //Makes the sidepanel aligned with the first button
            SidePanel.Height = LibrarySideBTN.Height;
            SidePanel.Top = LibrarySideBTN.Top;

            LibraryScreen.BringToFront();

            if (!Directory.Exists(completePath))
            {
                Directory.CreateDirectory(completePath);
            }

            if (!File.Exists(ConfigPath))
            {
                Config FirstStartup = new Config();
                FirstStartup.Rcolor = "230";
                FirstStartup.Gcolor ="25";
                FirstStartup.Bcolor = "25";

                string ConfigJsonString = JsonSerializer.Serialize(FirstStartup);

                File.WriteAllText(ConfigPath, ConfigJsonString);
            }

            Thread UIUpdater = new Thread(new ThreadStart(RefreshColors));
            UIUpdater.IsBackground = true;
            UIUpdater.Start();

            Thread DownloadsChecker = new Thread(new ThreadStart(CheckForNewDownload));
            DownloadsChecker.IsBackground = true;
            DownloadsChecker.Start();
        }

        //Invokable method on mousedown to make the pannel draggable (And thus the whole application)
        private void DraggablePanel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public void CheckForNewDownload()
        {
            int DLCount = Directory.EnumerateFiles(DownloadsPath, "*", SearchOption.TopDirectoryOnly).Count();

            if (DLCount > PrevAmountGames)
            {
                List<List<string>>  EK = DLManager.DownloadURLs; 
                List<string> EG = DLManager.GameName;

                string[] filePaths = Directory.GetFiles(DownloadsPath, "*.json",
                                         SearchOption.TopDirectoryOnly);

                string debugtxt = "";

                foreach(string filePath in filePaths)
                {
                    string jsonString = File.ReadAllText(filePath);
                    DownloadsQueryClass downloadsQuery = JsonSerializer.Deserialize<DownloadsQueryClass>(jsonString)!;

                    EK.Add(downloadsQuery.URLs);
                    EG.Add(downloadsQuery.GameTitle);       
                }

                foreach (var lst in EK)
                {
                    foreach(string link in lst)
                    {
                        debugtxt += link;
                    }                  
                }

                DLManager.DownloadURLs = EK;
                DLManager.GameName = EG;

                PrevAmountGames = DLCount;

                Thread.Sleep(3000);
                CheckForNewDownload();
            }
            else
            {
                Thread.Sleep(3000);
                CheckForNewDownload();
            }            
        }

        //Exits the app on button click
        private void ShutDownBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Minimizes the app on button click
        private void MinimizeBTN_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Aligns the sidepanel with Library side button
        private void LibrarySideBTN_Click(object sender, EventArgs e)
        {
            SidePanel.Height = LibrarySideBTN.Height-1;
            SidePanel.Top = LibrarySideBTN.Top;

            DownloadsPage.Visible = false;
            PreferencesScreen.Visible = false;
            DLManager.Visible = false;

            LibraryScreen.Visible = true;
            LibraryScreen.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = BrowseSideBTN.Height - 1;
            SidePanel.Top = BrowseSideBTN.Top;

            LibraryScreen.Visible = false;
            PreferencesScreen.Visible = false;
            DLManager.Visible = false;

            DownloadsPage.Visible = true;
            DownloadsPage.BringToFront();
        }

        private void PreferencesBtn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = PreferencesBtn.Height - 1;
            SidePanel.Top = PreferencesBtn.Top;

            LibraryScreen.Visible = false;
            DownloadsPage.Visible = false;
            DLManager.Visible = false;

            preferencesScreen1.Visible = true;
            preferencesScreen1.BringToFront();
        }

        //Changes the UI color
        public void RefreshColors()
        {
            if (File.Exists(ConfigPath))
            {
                string contents = File.ReadAllText(ConfigPath);
                Config Config = JsonSerializer.Deserialize<Config>(contents)!;

                int RColor = Convert.ToInt32(Config.Rcolor);
                int GColor = Convert.ToInt32(Config.Gcolor);
                int BColor = Convert.ToInt32(Config.Bcolor);

                AccentColor = Color.FromArgb(((int)(((byte)(RColor)))), ((int)(((byte)(GColor)))), ((int)(((byte)(BColor)))));
            }

            panel1.BackColor = AccentColor;
            LibraryScreen.UIColor = AccentColor;
            DownloadsPage.UIColor = AccentColor;

            Thread.Sleep(1000);
            RefreshColors();
        }

        private void DownloadsSideBTN2_Click(object sender, EventArgs e)
        {
            SidePanel.Height = DownloadsSideBTN2.Height - 1;
            SidePanel.Top = DownloadsSideBTN2.Top;

            LibraryScreen.Visible = false;
            DownloadsPage.Visible = false;
            preferencesScreen1.Visible = false;

            DLManager.Visible = true;
        }
    }
    
}
