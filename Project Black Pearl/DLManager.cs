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
    public partial class DLManager : UserControl
    {
        public DLManager()
        {
            InitializeComponent();
        }

        [Category("Download Info")]
        public List<List<string>> DLURLs = new List<List<string>>();
        public List<List<string>> DownloadURLs
        {
            get { return DLURLs; }
            set { SetDLURL(value); }
        }
        public void SetDLURL(List<List<string>> url)
        {
            //Sets the visibility of the panels based on how many links are passed
            DLURLs = url;
            int AmountOfURLs = DLURLs.Count;

            SetVisiblePanels(AmountOfURLs);
            SetPanelLinks(url, AmountOfURLs);
        }


        [Category("Download Info")]
        public List<string> MainName = new List<string>();
        public List<string> GameName
        {
            get { return MainName; }
            set { SetGameName(value); }
        }
        public void SetGameName(List<string> Name)
        {
            MainName = Name;

            int AmountOfURLs = DLURLs.Count;
            SetPanelLabels(Name, AmountOfURLs);
        }

        //Sets the link for each panel
        public void SetPanelLinks(List<List<string>> URLs, int Amount)
        {
            switch (Amount)
            {
                case 0:
                    break;
                case 1:
                    dlManagerPanel1.DLURL = URLs[0];
                    break;
                case 2:
                    dlManagerPanel1.DLURL = URLs[0];
                    dlManagerPanel2.DLURL = URLs[1];
                    break;
                case 3:
                    dlManagerPanel1.DLURL = URLs[0];
                    dlManagerPanel2.DLURL = URLs[1];
                    dlManagerPanel3.DLURL = URLs[2];
                    break;
                case 4:
                    dlManagerPanel1.DLURL = URLs[0];
                    dlManagerPanel2.DLURL = URLs[1];
                    dlManagerPanel3.DLURL = URLs[2];
                    dlManagerPanel4.DLURL = URLs[3];
                    break;
                case 5:
                    dlManagerPanel1.DLURL = URLs[0];
                    dlManagerPanel2.DLURL = URLs[1];
                    dlManagerPanel3.DLURL = URLs[2];
                    dlManagerPanel4.DLURL = URLs[3];
                    dlManagerPanel5.DLURL = URLs[4];
                    break;
                case 6:
                    dlManagerPanel1.DLURL = URLs[0];
                    dlManagerPanel2.DLURL = URLs[1];
                    dlManagerPanel3.DLURL = URLs[2];
                    dlManagerPanel4.DLURL = URLs[3];
                    dlManagerPanel5.DLURL = URLs[4];
                    dlManagerPanel6.DLURL = URLs[5];
                    break;
                case 7:
                    dlManagerPanel1.DLURL = URLs[0];
                    dlManagerPanel2.DLURL = URLs[1];
                    dlManagerPanel3.DLURL = URLs[2];
                    dlManagerPanel4.DLURL = URLs[3];
                    dlManagerPanel5.DLURL = URLs[4];
                    dlManagerPanel6.DLURL = URLs[5];
                    dlManagerPanel7.DLURL = URLs[6];
                    break;
            }
        }

        //Sets the panels to the game's name + adds indicator to each part
        public void SetPanelLabels(List<string> MainName, int Amount)
        {
            //Tried using loops but couldn't get them to work, switch case all the way lol (Sorry if you have to deal with this code)

            switch (Amount)
            {
                case 0:
                    break;
                case 1:
                    dlManagerPanel1.Title = MainName[0];
                    break;
                case 2:
                    dlManagerPanel1.Title = MainName[0];
                    dlManagerPanel2.Title = MainName[1];
                    break;
                case 3:
                    dlManagerPanel1.Title = MainName[0];
                    dlManagerPanel2.Title = MainName[1];
                    dlManagerPanel3.Title = MainName[2];
                    break;
                case 4:
                    dlManagerPanel1.Title = MainName[0];
                    dlManagerPanel2.Title = MainName[1];
                    dlManagerPanel3.Title = MainName[2];
                    dlManagerPanel4.Title = MainName[3];
                    break;
                case 5:
                    dlManagerPanel1.Title = MainName[0];
                    dlManagerPanel2.Title = MainName[1];
                    dlManagerPanel3.Title = MainName[2];
                    dlManagerPanel4.Title = MainName[3];
                    dlManagerPanel5.Title = MainName[4];
                    break;
                case 6:
                    dlManagerPanel1.Title = MainName[0];
                    dlManagerPanel2.Title = MainName[1];
                    dlManagerPanel3.Title = MainName[2];
                    dlManagerPanel4.Title = MainName[3];
                    dlManagerPanel5.Title = MainName[4];
                    dlManagerPanel6.Title = MainName[5];
                    break;
                case 7:
                    dlManagerPanel1.Title = MainName[0];
                    dlManagerPanel2.Title = MainName[1];
                    dlManagerPanel3.Title = MainName[2];
                    dlManagerPanel4.Title = MainName[3];
                    dlManagerPanel5.Title = MainName[4];
                    dlManagerPanel6.Title = MainName[5];
                    dlManagerPanel7.Title = MainName[6];
                    break;
            }
        }

        //Uses SetPanels to set the visibility of all the panels based on an integer amount
        public void SetVisiblePanels(int Amount)
        {
            switch (Amount)
            {
                case 0:
                    dlManagerPanel1.Vizibility = false;
                    dlManagerPanel2.Vizibility = false;
                    dlManagerPanel3.Vizibility = false;
                    dlManagerPanel4.Vizibility = false;
                    dlManagerPanel5.Vizibility = false;
                    dlManagerPanel6.Vizibility = false;
                    dlManagerPanel7.Vizibility = false;
                    break;
                case 1:
                    dlManagerPanel1.Vizibility = true;
                    dlManagerPanel2.Vizibility = false;
                    dlManagerPanel3.Vizibility = false;
                    dlManagerPanel4.Vizibility = false;
                    dlManagerPanel5.Vizibility = false;
                    dlManagerPanel6.Vizibility = false;
                    dlManagerPanel7.Vizibility = false;
                    break;
                case 2:
                    dlManagerPanel1.Vizibility = true;
                    dlManagerPanel2.Vizibility = true;
                    dlManagerPanel3.Vizibility = false;
                    dlManagerPanel4.Vizibility = false;
                    dlManagerPanel5.Vizibility = false;
                    dlManagerPanel6.Vizibility = false;
                    dlManagerPanel7.Vizibility = false;
                    break;
                case 3:
                    dlManagerPanel1.Vizibility = true;
                    dlManagerPanel2.Vizibility = true;
                    dlManagerPanel3.Vizibility = true;
                    dlManagerPanel4.Vizibility = false;
                    dlManagerPanel5.Vizibility = false;
                    dlManagerPanel6.Vizibility = false;
                    dlManagerPanel7.Vizibility = false;
                    break;
                case 4:
                    dlManagerPanel1.Vizibility = true;
                    dlManagerPanel2.Vizibility = true;
                    dlManagerPanel3.Vizibility = true;
                    dlManagerPanel4.Vizibility = true;
                    dlManagerPanel5.Vizibility = false;
                    dlManagerPanel6.Vizibility = false;
                    dlManagerPanel7.Vizibility = false;
                    break;
                case 5:
                    dlManagerPanel1.Vizibility = true;
                    dlManagerPanel2.Vizibility = true;
                    dlManagerPanel3.Vizibility = true;
                    dlManagerPanel4.Vizibility = true;
                    dlManagerPanel5.Vizibility = true;
                    dlManagerPanel6.Vizibility = false;
                    dlManagerPanel7.Vizibility = false;
                    break;
                case 6:
                    dlManagerPanel1.Vizibility = true;
                    dlManagerPanel2.Vizibility = true;
                    dlManagerPanel3.Vizibility = true;
                    dlManagerPanel4.Vizibility = true;
                    dlManagerPanel5.Vizibility = true;
                    dlManagerPanel6.Vizibility = true;
                    dlManagerPanel7.Vizibility = false;
                    break;
                case 7:
                    dlManagerPanel1.Vizibility = true;
                    dlManagerPanel2.Vizibility = true;
                    dlManagerPanel3.Vizibility = true;
                    dlManagerPanel4.Vizibility = true;
                    dlManagerPanel5.Vizibility = true;
                    dlManagerPanel6.Vizibility = true;
                    dlManagerPanel7.Vizibility = true;
                    break;
            }
        }             
    }
}
