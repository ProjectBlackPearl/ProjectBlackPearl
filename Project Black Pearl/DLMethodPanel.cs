using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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

        int DLTypeIndex = 0;

        [Category("Data")]
        //Sets the download method
        public string MethodNameSetter = " ";
        public string MethodName
        {
            get { return MethodNameSetter; }
            set { SetDLMethod1Name(value); }
        }
        public void SetDLMethod1Name(string Name)
        {
            MethodNameSetter = Name;
            DownloadMethodLabel.Text = Name;
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
        public List<string> DLUri = new List<string>();
        public List<string> DownloadURI
        {
            get { return DLUri; }
            set { SetDLURI(value); }
        }
        public void SetDLURI(List<string> DLURIsList)
        {
            DLUri = DLURIsList;
            if(DLURIsList == null)
            {
                SetAvailability(false);
                SetDLinClientEnableState(false);
                SetCopyClipboardEnableState(false);

                SetDLLabelType(2);
                DLTypeIndex = 2;
            }
            else if(DLURIsList.Count == 0)
            {
                SetAvailability(false);
                SetDLinClientEnableState(false);
                SetCopyClipboardEnableState(false);

                SetDLLabelType(2);
                DLTypeIndex = 2;
            }
            else if (DLURIsList.Count == 1)
            {
                if (DLURIsList[0].Substring(0, 6).ToLower() == "magnet")
                {
                    SetAvailability(true);
                    SetDLinClientEnableState(true);
                    SetCopyClipboardEnableState(true);

                    SetDLLabelType(1);
                    DLTypeIndex = 1;
                }
                else
                {
                    SetAvailability(true);
                    SetDLinClientEnableState(true);
                    SetCopyClipboardEnableState(true);

                    SetDLLabelType(0);
                    DLTypeIndex = 0;
                }
            }
            else
            {
                SetAvailability(true);
                SetDLinClientEnableState(true);
                SetCopyClipboardEnableState(true);

                SetDLLabelType(0);
                DLTypeIndex = 0;
            }
        }


        [Category("Data")]
        public string ImagePath = " ";
        public string ImageToDisplay
        {
            get { return ImagePath; }
            set { SetImagePath(value); }
        }

        public void SetImagePath(string Path)
        {
            if (Path != null && !string.IsNullOrEmpty(Path) && Path != " " && Path != "")
            {
                ImagePath = Path;
                UnavailableBox.Visible = false;                

                Image img = Image.FromFile(Path);
                Bitmap b = new Bitmap(img);
                Image i = EditGameScreen.resizeImage(b, new Size(64, 64));

                MethodIconBox.Image = i;
                MethodIconBox.Visible = true;
            }
            else
            {
                ImagePath = " ";
                UnavailableBox.Visible = true;
                MethodIconBox.Visible = false;
            }
        }

        public void SetDLinClientEnableState (bool state)
        {
            if (state)
            {
                DownloadClientBTN.Enabled = true;
                DownloadClientBTN.Visible = true;

                InvalidDownloadsBTN.Enabled = false;
                InvalidDownloadsBTN.Visible = false;
            }
            else
            {
                DownloadClientBTN.Enabled = false;
                DownloadClientBTN.Visible = false;

                InvalidDownloadsBTN.Enabled = false;
                InvalidDownloadsBTN.Visible = true;
            }
        }

        public void SetCopyClipboardEnableState(bool state)
        {
            if (state)
            {
                CopyClipboardBTN.Enabled = true;
                CopyClipboardBTN.Visible = true;

                InvalidCopyBTN.Enabled = false; 
                InvalidCopyBTN.Visible = false;
            }
            else
            {
                CopyClipboardBTN.Enabled = false;
                CopyClipboardBTN.Visible = false;

                InvalidCopyBTN.Enabled = false;
                InvalidCopyBTN.Visible = true;
            }
        }

        public void SetDLLabelType(int index)
        {
            switch (index)
            {
                case 0:
                    DLLabel.Text = "Download in client:";
                    break;
                case 1:
                    DLLabel.Text = "Open in browser:";
                    break;
                case 2:
                    DLLabel.Text = "Download not available:";
                    break;
            }
        }

        //Copies the URI to Clipboard
        private void CopyClipboardBTN_Click(object sender, EventArgs e)
        {
            string URLS = "";
            foreach(string URI in DLUri)
            {
                if(URI != null && !string.IsNullOrEmpty(URI))
                {
                    URLS += URI + "\n";
                }
            }

            if (string.IsNullOrEmpty(URLS))
            {
                Clipboard.SetText(" ");
            }
            else
            {
                Clipboard.SetText(URLS);
            }                                
        }


        //Starts the download
        private void DownloadClientBTN_Click(object sender, EventArgs e)
        {
            switch (DLTypeIndex)
            {
                //Download in client
                case 0:
                    //Implement logic later
                    break;

                //Open in browser
                case 1:

                    Process.Start(new ProcessStartInfo(DLUri[0]) { UseShellExecute = true });
                    break;

                //Download not available, do nothing
                case 2:
                    break;
            }
        }
    }
}
