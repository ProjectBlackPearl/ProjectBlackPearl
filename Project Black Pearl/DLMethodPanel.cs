using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Black_Pearl
{
    public partial class DLMethodPanel : UserControl
    {
        public DLMethodPanel()
        {
            InitializeComponent();
        }

        [Category("Data")]
        //Sets the download method
        public int DLIndex = 1;
        public int DLMethodIndex
        {
            get { return DLIndex; }
            set { SetDLMethod(value); }
        }
        public void SetDLMethod(int index)
        {
            switch (index)
            {
                case 1:
                    DownloadMethodLabel.Text = "Torrent";
                    TorrentPicBox.Visible = true;
                    MultiUpBox.Visible = false;
                    ZippyPicBox.Visible = false;
                    OneDriveBox.Visible = false;
                    DLIndex = 1;
                    break;
                case 2:
                    DownloadMethodLabel.Text = "MultiUpload";
                    MultiUpBox.Visible = true;
                    TorrentPicBox.Visible = false;
                    ZippyPicBox.Visible = false;
                    OneDriveBox.Visible = false;
                    DLIndex = 2;
                    break;
                case 3:
                    DownloadMethodLabel.Text = "Zippyshare";
                    ZippyPicBox.Visible = true;
                    TorrentPicBox.Visible = false;
                    MultiUpBox.Visible = false;
                    OneDriveBox.Visible = false;
                    DLIndex = 3;
                    break;
                case 4:
                    DownloadMethodLabel.Text = "OneDrive";
                    OneDriveBox.Visible = true;
                    ZippyPicBox.Visible = false;
                    TorrentPicBox.Visible = false;
                    MultiUpBox.Visible = false;
                    DLIndex = 4;
                    break;
            }
        }

        [Category("Data")]
        //Sets the availability
        public bool Available = false;
        public bool AvailabilityIndex
        {
            get { return Available; }
            set { SetAvailability(value); }
        }
        public void SetAvailability(bool index)
        {
            if(index == true)
            {
                Available = true;
                ReadyPicBox.Visible = true;
                UnreadyPicBox.Visible = false;                
            }
            else
            {
                Available = false;
                ReadyPicBox.Visible = false;
                UnreadyPicBox.Visible = true;               
            }
        }

        [Category("Data")]
        //Sets the download URI
        public List<string> DLUri;
        public List<string> DownloadURI
        {
            get { return DLUri; }
            set { DLUri = value; }
        }

        //Copies the URI to Clipboard
        private void CopyClipboardBTN_Click(object sender, EventArgs e)
        {
            /*
            if(DLUri != "")
            {
                Clipboard.Clear();
                Clipboard.SetText(DLUri);
            }*/
        }

        //Opens the link in browser
        private void DownloadClientBTN_Click(object sender, EventArgs e)
        {
            /*if(DLUri != "")
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = DLUri,
                    UseShellExecute = true
                });
            }*/
        }
    }
}
