using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project_Black_Pearl
{
    public partial class PreferencesScreen : UserControl
    {
        public static string systemPath = System.Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string completePath = Path.Combine(systemPath, "Project Black Pearl\\");
        public static string ConfigPath = completePath + "Config.json";

        public string AccentColorIndex = "Red";
        public Color AccentColor;
        public int PreviousSelected = 1;
        public int CurrentSelected = 1;

        public PreferencesScreen()
        {
            InitializeComponent();
            Thread.Sleep(100);
        }        

        //Grab the RGB value from the Index string
        public static Color GetColorRGB(string Index)
        {
            switch (Index)
            {
                case "Red":
                    return Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
                case "Orange":
                    return Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(128)))), ((int)(((byte)(25)))));
                case "Yellow":
                    return Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(25)))));
                case "Green":
                    return Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(25)))));
                case "Mint":
                    return Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(128)))));
                case "Cyan":
                    return Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
                case "Blue":
                    return Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(60)))), ((int)(((byte)(230)))));
                case "Purple":
                    return Color.FromArgb(((int)(((byte)(162)))), ((int)(((byte)(25)))), ((int)(((byte)(230)))));
                case "Pink":
                    return Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(25)))), ((int)(((byte)(162)))));
                default: return Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(25)))), ((int)(((byte)(25)))));
            }
        }

        private void customizableButton1_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Red";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 1;
            UpdateSelected();
            WriteToFile();
        }

        private void customizableButton2_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Orange";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 2;
            UpdateSelected();
            WriteToFile();
        }

        private void customizableButton3_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Yellow";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 3;
            UpdateSelected();
            WriteToFile();
        }

        private void customizableButton4_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Green";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 4;
            UpdateSelected();
            WriteToFile();
        }

        private void customizableButton5_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Mint";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 5;
            UpdateSelected();
            WriteToFile();
        }

        private void customizableButton6_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Cyan";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 6;
            UpdateSelected();
            WriteToFile();
        }

        private void customizableButton7_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Blue";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 7;
            UpdateSelected();
            WriteToFile();
        }

        private void customizableButton8_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Purple";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 8;
            UpdateSelected();
            WriteToFile();
        }

        private void customizableButton9_Click(object sender, EventArgs e)
        {
            AccentColorIndex = "Pink";
            AccentColor = GetColorRGB(AccentColorIndex);
            CurrentSelected = 9;
            UpdateSelected();
            WriteToFile();
        }

        //Writes the files into Config.json
        public void WriteToFile()
        {
            if (!Directory.Exists(completePath))
            {
                Directory.CreateDirectory(completePath);
            }

            if (!File.Exists(ConfigPath))
            {
                File.Create(ConfigPath);
            }

            Config Config = new Config();
            Config.Rcolor = AccentColor.R.ToString();
            Config.Gcolor = AccentColor.G.ToString();
            Config.Bcolor = AccentColor.B.ToString();

            string ConfigJsonString = JsonSerializer.Serialize(Config);

            File.WriteAllText(ConfigPath, ConfigJsonString);
        }

        //Adds a white contour border to the selected color's button
        public void UpdateSelected()
        {
            switch (CurrentSelected)
            {
                case 1:
                    customizableButton1.BorderSize = 1;
                    break;
                case 2:
                    customizableButton2.BorderSize = 1;
                    break;
                case 3:
                    customizableButton3.BorderSize = 1;
                    break;
                case 4:
                    customizableButton4.BorderSize = 1;
                    break;
                case 5:
                    customizableButton5.BorderSize = 1;
                    break;
                case 6:
                    customizableButton6.BorderSize = 1;
                    break;
                case 7:
                    customizableButton7.BorderSize = 1;
                    break;
                case 8:
                    customizableButton8.BorderSize = 1;
                    break;
                case 9:
                    customizableButton9.BorderSize = 1;
                    break;
                case 10:
                    customizableButton10.BorderSize = 1;
                    break;
            }

            if(PreviousSelected != CurrentSelected)
            {
                switch (PreviousSelected)
                {
                    case 1:
                        customizableButton1.BorderSize = 0;
                        break;
                    case 2:
                        customizableButton2.BorderSize = 0;
                        break;
                    case 3:
                        customizableButton3.BorderSize = 0;
                        break;
                    case 4:
                        customizableButton4.BorderSize = 0;
                        break;
                    case 5:
                        customizableButton5.BorderSize = 0;
                        break;
                    case 6:
                        customizableButton6.BorderSize = 0;
                        break;
                    case 7:
                        customizableButton7.BorderSize = 0;
                        break;
                    case 8:
                        customizableButton8.BorderSize = 0;
                        break;
                    case 9:
                        customizableButton9.BorderSize = 0;
                        break;
                    case 10:
                        customizableButton10.BorderSize = 0;
                        break;
                }
            }
            PreviousSelected = CurrentSelected;
        }

        //Lets you pick a custom color
        private void customizableButton10_Click(object sender, EventArgs e)
        {
            if(CustomColorDialog.ShowDialog() == DialogResult.OK)
            {
                AccentColor = CustomColorDialog.Color;
                CurrentSelected = 10;
                customizableButton10.BackColor = AccentColor;
                UpdateSelected();
                WriteToFile();
            }           
        }
    }
}
