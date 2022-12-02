using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Extensions.Logging;
using OctaneEngine;
using Serilog.Sinks.SystemConsole.Themes;
using Serilog;
using System.Globalization;
using System.Security.Policy;

namespace Project_Black_Pearl
{
    public partial class DLManagerPanel : UserControl
    {
        //Set the configuration for downloader
        static OctaneConfiguration config = new OctaneConfiguration
        {
            Parts = 2,
            BufferSize = 8192,
            ShowProgress = false,
            BytesPerSecond = 1,
            UseProxy = false,
            Proxy = null,
            DoneCallback = x => {
                Console.WriteLine("Done!");
            },
            ProgressCallback = x => {
                Console.WriteLine(x.ToString(CultureInfo.InvariantCulture));
            },
            NumRetries = 10
        };

        //Creates a logger (Using serilog in this case)
        static Serilog.Core.Logger seriLog = new LoggerConfiguration()
             .Enrich.FromLogContext()
             .MinimumLevel.Verbose()
             .WriteTo.File("./OctaneLog.txt")
             .CreateLogger();

        static ILoggerFactory factory = LoggerFactory.Create(logging => {
            logging.AddSerilog(seriLog);
        });


        [Category("Download Info")]
        public List<string> DLURL = new List<string>();
        public List<string> DownloadURL
        {
            get { return DLURL; }
            set { SetDLURL(value); }
        }
        public void SetDLURL(List<string> url)
        {
            DLURL = url;
        }

        [Category("Download Info")]
        public string TitleLabel = "";
        public string Title
        {
            get { return TitleLabel; }
            set { SetTitle(value); }
        }
        public void SetTitle(string Title)
        {
            TitleLabel = Title;

            if (TitleLBL.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        TitleLBL.Text = Title;
                    }));
            }
            else
            {
                TitleLBL.Text = Title;
            }          
        }



        [Category("Misc")]
        public bool Viz = false;
        public bool Vizibility
        {
            get { return Viz; }
            set { SetVibisibility(value); }
        }

        public DLManagerPanel()
        {
            InitializeComponent();
        }


        //Starts the download, had issues with async so ended up creating it on a new thread
        public async Task StartDownload(string url, ILoggerFactory factory, string output, OctaneConfiguration config)
        {
            SetStatusLabel("Downloading...");

            TimeSpan timeout = new TimeSpan(24, 0, 0);
            await Engine.DownloadFile(url, factory, output, config).WaitAsync(timeout);

            SetStatusLabel("Download finished!");
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            foreach(var url in DLURL)
            {
                if (url != string.Empty && url != " " && url != null)
                {
                    string filename = " ";

                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.InitialDirectory = @"C:\";
                    saveFileDialog.Filter = "All files (*.*)|*.*";
                    saveFileDialog.RestoreDirectory = true;

                    var choosestat = saveFileDialog.ShowDialog();

                    if (choosestat == DialogResult.OK)
                    {
                        filename = saveFileDialog.FileName;

                        Thread DLStart = new Thread(async () => await StartDownload(url, factory, filename, config));
                        DLStart.IsBackground = true;
                        DLStart.Start();
                    }
                    else if(choosestat == DialogResult.Cancel)
                    {
                        //Do nothing
                    }                  
                }
            }   
        }

        public void SetStatusLabel(string Status)
        {
            if (StatusLBL.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        StatusLBL.Text = Status;
                    }));
            }
            else
            {
                StatusLBL.Text = Status;
            }
        }

        public void SetVibisibility(bool viz)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(
                    delegate ()
                    {
                        this.Visible = viz;
                    }));
            }
            else
            {
                this.Visible = viz;
            }
        }
    }
}
