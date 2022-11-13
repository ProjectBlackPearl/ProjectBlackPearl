using Microsoft.VisualBasic;
using Project_Black_Pearl.SDK;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using Microsoft.Scripting;
using static IronPython.Modules._ast;
using System.Reflection.Emit;
using System.Security.Policy;

namespace Project_Black_Pearl
{
    public partial class DownloadsPage : UserControl
    {
        //Gets appdata folder
        public static string systemPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        //Gets the PBP temp folder
        public static string completePath = Path.Combine(systemPath, "Project Black Pearl\\");
        //Gets the scrapers folder
        public static string scrapersPath = Path.Combine(completePath, "Scraper Results\\");
        //Gets the extensions folder (Plugins go here)
        public static string pluginsPath = Path.Combine(completePath, "Extensions\\");
        //Gets the Query folder
        public static string QueryPath = Path.Combine(completePath, "Query\\");

        public static string PrefetchQueryPath = QueryPath + "Prefetch\\";

        public static string PrefetchQueryPath0 = PrefetchQueryPath + "Query0\\";
        public static string PrefetchQueryPath1 = PrefetchQueryPath + "Query1\\";
        public static string PrefetchQueryPath2 = PrefetchQueryPath + "Query2\\";
        public static string PrefetchQueryPath3 = PrefetchQueryPath + "Query3\\";
        public static string PrefetchQueryPath4 = PrefetchQueryPath + "Query4\\";
        public static string PrefetchQueryPath5 = PrefetchQueryPath + "Query5\\";

        public static string Done0Path = PrefetchQueryPath0 + "Done.txt";
        public static string Done1Path = PrefetchQueryPath1 + "Done.txt";
        public static string Done2Path = PrefetchQueryPath2 + "Done.txt";
        public static string Done3Path = PrefetchQueryPath3 + "Done.txt";
        public static string Done4Path = PrefetchQueryPath4 + "Done.txt";
        public static string Done5Path = PrefetchQueryPath5 + "Done.txt";

        public static string ScraperPath;       

        public string TypeOfScrape = "";

        public string SanitizationLevel = "Medium";

        //Stores the plugins 
        static List<PBPPlugin> _plugins = null;

        //Method that reads the plugins from Assembly
        static List<PBPPlugin> ReadExtensions()
        {
            var pluginsLists = new List<PBPPlugin>();       

            //Read DLL files from the extensions folder
            var files = Directory.GetFiles(pluginsPath, "*.dll");

            //Read assembly from DLLs
            foreach(var file in files)
            {
                try
                {
                    var assembly = Assembly.LoadFile(Path.Combine(pluginsPath, file));

                    //Extract all the types that implement PBPPlugin
                    var pluginTypes = assembly.GetTypes().Where(t => typeof(PBPPlugin).IsAssignableFrom(t) && !t.IsInterface).ToArray();

                    foreach (var pluginType in pluginTypes)
                    {
                        //Create instance from the extracted type
                        var pluginInstance = Activator.CreateInstance(pluginType) as PBPPlugin;
                        pluginsLists.Add(pluginInstance);
                    }
                }
                catch (ReflectionTypeLoadException)
                {
                    continue;
                }                
            }

            return pluginsLists;
        }

        //Store plugin name
        public List<string> SearchFilters = new List<string>();
        //Store scraper path
        public List<string> ScraperPaths = new List<string>();
        //Store scraper type (Binary or Python)
        public List<string> ScraperTypes = new List<string>();
        //Store scraper output files
        public List<string> ScraperOutputFiles = new List<string>();
        //Store scraper output folders
        public List<string> ScraperOutputFolders = new List<string>();

        //Stores Prefetch Status
        public List<bool> isPrefetchStates = new List<bool>();
        public List<string> PrefetchScraperPaths = new List<string>();
        public List<string> PrefetchOutputFiles = new List<string>();
        public List<string> PrefetchScraperType = new List<string>();
        public List<string> PrefetchTempFolders = new List<string>();

        //URL 1 Storage
        public List<string> URL1Images = new List<string>();
        public List<string> URL1Types = new List<string>();
        public List<string> URL1Validators = new List<string>();


        //URL 2 Storage
        public List<string> URL2Images = new List<string>();
        public List<string> URL2Types = new List<string>();
        public List<string> URL2Validators = new List<string>();


        //URL 3 Storage
        public List<string> URL3Images = new List<string>();
        public List<string> URL3Types = new List<string>();
        public List<string> URL3Validators = new List<string>();


        //URL 4 Storage
        public List<string> URL4Images = new List<string>();
        public List<string> URL4Types = new List<string>();
        public List<string> URL4Validators = new List<string>();

        public string ScraperToUse = "";

        public List<string> GameTitles = new List<string>();
        public List<string> ForumLinks = new List<string>();

        public bool ReadySecondScraper = false;

        public int CurrentGame = 0;

        public int CurrentIndex = 0;

        public bool DoneWithCombining = false;

        //Sets the UI's color
        [Category("Config")]
        public Color UIColor
        {
            get { return GetUIColor(); }
            set { SetUIColor(value); }
        }
        public void SetUIColor(Color UIColor)
        {
            SearchTextBox.BorderColor = UIColor;
            SearchTextBox.BorderFocusColor = UIColor;

            SearchBTN.BackColor = UIColor;
            SearchBTN.BackgroundColor = UIColor;
        }
        public Color GetUIColor()
        {
            return SearchTextBox.BorderColor;
        }

        //Constructor
        public DownloadsPage()
        {
            InitializeComponent();

            DirectoryCreator(completePath);
            DirectoryCreator(pluginsPath);
            DirectoryCreator(scrapersPath);
            DirectoryCreator(QueryPath);
            DirectoryCreator(pluginsPath + "Scrapers\\");
            DirectoryCreator(pluginsPath + "Images\\");

            //Startup thread, also runs the prefetc scrapers
            Thread OnStartThread = new Thread(new ThreadStart(FirstLoad));
            OnStartThread.IsBackground = true;
            OnStartThread.Start();
        }

        //Runs the search on search button click
        private void SearchBTN_Click(object sender, EventArgs e)
        {
            RunSearch();
        }

        public void RunSearch()
        {
            try
            {
                InitialMSG.Text = "Searching...";

                //Grabs the user's Query
                string query = SearchTextBox.Texts;

                //Gets the selected plugin's index
                int FilterIdx = ScraperTypeList.SelectedIndex;

                //Grabs the name of the scraper that should be used
                if (ScraperTypeList.SelectedItem != null && ScraperTypeList.SelectedItem.ToString() != "")
                {
                    ScraperToUse = ScraperTypeList.SelectedItem.ToString();
                }
                else
                {
                    ScraperToUse = "None";
                }

                DLPanel1.GameSource = ScraperToUse;
                DLPanel2.GameSource = ScraperToUse;
                DLPanel3.GameSource = ScraperToUse;
                DLPanel4.GameSource = ScraperToUse;
                DLPanel5.GameSource = ScraperToUse;
                DLPanel6.GameSource = ScraperToUse;

                bool PrefetchStat = isPrefetchStates[FilterIdx];

                if (PrefetchStat)
                {
                    string PrecacheFile = PrefetchOutputFiles[FilterIdx];
                    string PrefetchScraper = PrefetchScraperPaths[FilterIdx];
                    string TypeOfPrefetchScraper = PrefetchScraperType[FilterIdx];

                    if (!File.Exists(PrecacheFile))
                    {
                        RunPrefetchFirstPayload(PrefetchScraper, PrecacheFile, TypeOfPrefetchScraper);
                    }

                    string PostFetchScraper = ScraperPaths[FilterIdx];
                    string OutputFile = ScraperOutputFolders[FilterIdx] + ScraperOutputFiles[FilterIdx];
                    string PostFetchType = ScraperTypes[FilterIdx];
                    string TempPrefetchFolder = PrefetchTempFolders[FilterIdx];

                    DirectoryCreator(PrefetchQueryPath0);
                    DirectoryCleaner(PrefetchQueryPath0);

                    DirectoryCreator(PrefetchQueryPath1);
                    DirectoryCleaner(PrefetchQueryPath1);

                    DirectoryCreator(PrefetchQueryPath2);
                    DirectoryCleaner(PrefetchQueryPath2);

                    DirectoryCreator(PrefetchQueryPath3);
                    DirectoryCleaner(PrefetchQueryPath3);

                    DirectoryCreator(PrefetchQueryPath4);
                    DirectoryCleaner(PrefetchQueryPath4);

                    DirectoryCreator(PrefetchQueryPath5);
                    DirectoryCleaner(PrefetchQueryPath5);


                    FileDeletor(OutputFile);

                    DirectoryCreator(TempPrefetchFolder);

                    DirectoryInfo di = new DirectoryInfo(TempPrefetchFolder);

                    foreach (FileInfo file in di.GetFiles())
                    {
                        file.Delete();
                    }

                    RunPostfetchScraper(query, PrecacheFile, PostFetchScraper, OutputFile, PostFetchType, TempPrefetchFolder);
                    RetrievePrefetchResults(OutputFile);
                }
                else
                {
                    string OutputFolder = ScraperOutputFolders[FilterIdx];
                    string OutputFile = OutputFolder + ScraperOutputFiles[FilterIdx];
                    string ScraperType = ScraperTypes[FilterIdx];
                    string ScraperToUsePath = ScraperPaths[FilterIdx];

                    RunNonPrefetchScraper(OutputFolder, OutputFile, query, ScraperType, ScraperToUsePath);
                    RetrieveNonPrefetchResults(OutputFile);
                }
                InitialMSG.Visible = false;
                InitialMSG.Text = "Please run a search!";
            }
            catch
            {
                Console.WriteLine("You have no valid plugins!");
            }
        }

        public void RunNonPrefetchScraper(string OutputFolder, string OutputFile, string Query, string ScraperType, string ScraperPath)
        {
            if (!Directory.Exists(OutputFolder))
            {
                Directory.CreateDirectory(OutputFolder);
            }

            List<string> Args = new List<string>();
            Args.Add(Query);
            Args.Add(OutputFile);

            if (ScraperType == "Binary")
            {
                RunBinary(ScraperPath, Args);
            }
            else if (ScraperType == "Python Binary")
            {
                string NonPrefetchQueries = QueryPath + "Non-Prefetch\\";

                if (!Directory.Exists(QueryPath))
                {
                    Directory.CreateDirectory(QueryPath);
                }

                if (!Directory.Exists(NonPrefetchQueries))
                {
                    Directory.CreateDirectory(NonPrefetchQueries);
                }

                string SearchKeyword = NonPrefetchQueries + "Query.txt";
                string OutputTextPath = NonPrefetchQueries + "OutputFile.txt";

                if (!Directory.Exists(Path.GetDirectoryName(OutputFile)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(OutputFile));
                }

                File.WriteAllText(SearchKeyword, Query);
                File.WriteAllText(OutputTextPath, OutputFile);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ScraperPath;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                }
            }
        }

        public void RunPostfetchScraper(string Query, string PrefetchCache, string PostFetchScraperPath, string OutputFile, string PostFetchScraperType, string TempPrefetchFolder)
        {
            JsonParser(Query, PrefetchCache);
            RunSecondScraper(PostFetchScraperPath, ForumLinks, PostFetchScraperType, TempPrefetchFolder, GameTitles);

            Thread CombinerThread = new Thread(() => CombinePrefetchOutputs(TempPrefetchFolder, OutputFile));
            CombinerThread.IsBackground = true;
            CombinerThread.Start();
        }

        public void DirectoryCreator(string Path)
        {
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }

        public void DirectoryCleaner(string Path)
        {
            DirectoryInfo di = new DirectoryInfo(Path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }

        public void FileDeletor(string Path)
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }

        public void RunSecondScraper(string SecondScraperPath, List<string> URLsList, string ScraperType, string TempPrefetchFolder, List<string> TitlesList)
        {
            CurrentIndex = 0;
            List<string> LinksCopy = URLsList;
            int idx = 0;           

            DirectoryCreator(TempPrefetchFolder);
           
            for (int i = 0; i <= LinksCopy.Count -1 ; i++)
            {
                string Filename = TempPrefetchFolder + idx.ToString() + ".json";
                string DonePath = "";

                CurrentGame = i;

                switch (CurrentGame)
                {
                    case 0:
                        DonePath = Done0Path;
                        break;
                    case 1:
                        DonePath = Done1Path;
                        break;
                    case 2:
                        DonePath = Done2Path;
                        break;
                    case 3:
                        DonePath = Done3Path;
                        break;
                    case 4:
                        DonePath = Done4Path;
                        break;
                    case 5:
                        DonePath = Done5Path;
                        break;
                }

                Thread ScrapingThread = new Thread(() => RunPrefetchSecondPayload(SecondScraperPath, LinksCopy[i], Filename, ScraperType, TitlesList[i], DonePath));
                ScrapingThread.IsBackground = true;
                ScrapingThread.Start();
                Thread.Sleep(2000);

                string DebugPath = "C:/Users/DissTract/Downloads/Debugging" + CurrentIndex.ToString() + ".txt";
                File.WriteAllText(DebugPath, "Threading Worked");

                idx++;
                CurrentIndex++;               
            }
        }

        public void RunPrefetchSecondPayload(string ScraperPath, string URL, string PrefetchTempFile, string ScraperType, string GameName, string DonePath)
        {
            List<string> Args = new List<string>();
            Args.Add(URL);
            Args.Add(PrefetchTempFile);
            Args.Add(GameName);
            Args.Add(DonePath);

            if (ScraperType == "Binary")
            {

                RunBinary(ScraperPath, Args);
                File.WriteAllText("C:/Users/DissTract/Downloads/BinaryExecuted.txt", string.Format("Scraper Path:{0} \nURL:{1} \nPrefetchTempFile:{2} \nGameName:{3} \nDonePath:{4} \n ", ScraperPath, URL, PrefetchTempFile, GameName, DonePath));

            }
            /*
            else if(ScraperType == "Python Binary")
            {
                string CurrentFileTextPath = PrefetchQueryPath + "CurrentIndex.txt";
                File.WriteAllText(CurrentFileTextPath, CurrentGame.ToString());

                string PrefetchCurrentGame = QueryPath + "Prefetch\\" + "Query" + CurrentGame.ToString() + "\\";

                string URLTextPath = PrefetchCurrentGame + "URL.txt";
                string PrefetchTempFileTextPath = PrefetchCurrentGame + "PrefetchTempFile.txt";
                string GameNameTextPath = PrefetchCurrentGame + "GameName.txt";

                File.WriteAllText(URLTextPath, URL);
                File.WriteAllText(PrefetchTempFileTextPath, PrefetchTempFile);
                File.WriteAllText(GameNameTextPath, GameName);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ScraperPath;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;

                using (Process process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                }
            }*/
        }

        public void CombinePrefetchOutputs(string TempOutputsFolder, string ReadyOutputsFile)
        {
            bool Done0 = false;
            bool Done1 = false;
            bool Done2 = false;
            bool Done3 = false;
            bool Done4 = false;
            bool Done5 = false;        

            int AmountOfGames = ForumLinks.Count - 1;
           
            switch (AmountOfGames)
            {
                case 0:                 
                    Done0 = GetReadyStatus(Done0Path);
                    Done1 = true;
                    Done2 = true;
                    Done3 = true;
                    Done4 = true;
                    Done5 = true;
                    break;
                case 1:
                    Done0 = GetReadyStatus(Done0Path);
                    Done1 = GetReadyStatus(Done1Path);
                    Done2 = true;
                    Done3 = true;
                    Done4 = true;
                    Done5 = true;
                    break;
                case 2:
                    Done0 = GetReadyStatus(Done0Path);
                    Done1 = GetReadyStatus(Done1Path);
                    Done2 = GetReadyStatus(Done2Path);
                    Done3 = true;
                    Done4 = true;
                    Done5 = true;
                    break;
                case 3:
                    Done0 = GetReadyStatus(Done0Path);
                    Done1 = GetReadyStatus(Done1Path);
                    Done2 = GetReadyStatus(Done2Path);
                    Done3 = GetReadyStatus(Done3Path);
                    Done4 = true;
                    Done5 = true;
                    break;
                case 4:
                    Done0 = GetReadyStatus(Done0Path);
                    Done1 = GetReadyStatus(Done1Path);
                    Done2 = GetReadyStatus(Done2Path);
                    Done3 = GetReadyStatus(Done3Path);
                    Done4 = GetReadyStatus(Done4Path);
                    Done5 = true;
                    break;
                case 5:
                    Done0 = GetReadyStatus(Done0Path);
                    Done1 = GetReadyStatus(Done1Path);
                    Done2 = GetReadyStatus(Done2Path);
                    Done3 = GetReadyStatus(Done3Path);
                    Done4 = GetReadyStatus(Done4Path);
                    Done5 = GetReadyStatus(Done5Path);
                    break;
            }
           
            if (Done0 && Done1 && Done2 && Done3 && Done4 && Done5)
            {
                //Gets a list of all Jsons in the Output folder 
                string[] filePaths = Directory.GetFiles(TempOutputsFolder, "*.json",
                                         SearchOption.TopDirectoryOnly);

                PrefetchQueryResults prefetchQuery = new PrefetchQueryResults();
                prefetchQuery.response = new List<TempResults>();

                foreach (string filePath in filePaths)
                {
                    string contentJson = File.ReadAllText(filePath);
                    TempResults TemporaryFileContent = JsonSerializer.Deserialize<TempResults>(contentJson)!;
                    prefetchQuery.response.Add(TemporaryFileContent);
                }

                string QueryString = JsonSerializer.Serialize(prefetchQuery);
                File.WriteAllText(ReadyOutputsFile, QueryString);

                DoneWithCombining = true;
            }
            else
            {
                DoneWithCombining = false;
                Thread.Sleep(3000);
                CombinePrefetchOutputs(TempOutputsFolder, ReadyOutputsFile);
            }

            //string DebuggerPath = QueryPath + "Debug.txt";      
        }

        private bool GetReadyStatus(string ReadyStatusFilePath)
        {
            if (File.Exists(ReadyStatusFilePath))
            {
                string ReadyStatus = File.ReadAllText(ReadyStatusFilePath);

                if (ReadyStatus == "True" || ReadyStatus == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Searches for query in Input Json file and returns the titles that matches in GameTitles list with their respective links in ForumLinks
        public void JsonParser(string Query, string InputJSONPath)
        {
            GameTitles = new List<string>();
            ForumLinks = new List<string>();

            string JsonContent = File.ReadAllText(InputJSONPath);
            PrefetchQuery SearchResults = JsonSerializer.Deserialize<PrefetchQuery>(JsonContent)!;


            List<string> ListOfTitles = new List<string>();
            List<string> ListOfLinks = new List<string>();

            for (int i = 0; i < SearchResults.response.Count; i++)
            {
                ListOfTitles.Add(SearchResults.response[i].Title);
                ListOfLinks.Add(SearchResults.response[i].URL);
            }

            List<string> TitlesContainingQuery = null;


            TitlesContainingQuery = ListOfTitles.Where(x => x.Contains(Query)).ToList();

            if (TitlesContainingQuery == null || TitlesContainingQuery.Count == 0)
            {
                TitlesContainingQuery.Add("None");

            }

            List<int> PrevDex = new List<int>();

            foreach (string Title in TitlesContainingQuery)
            {
                int index = ListOfTitles.IndexOf(Title);
                PrevDex.Add(index);
            }

            var Dexes = PrevDex.GroupBy(x => x)
                                   .Where(g => g.Count() > 1)
                                   .Select(y => y.Key)
                                   .ToList();

            List<int> FilteredDexes = new List<int>();

            bool alreadyappended = false;

            foreach (var item in PrevDex)
            {
                if (Dexes.Contains(item))
                {
                    if (!alreadyappended)
                    {
                        FilteredDexes.Add(item);
                        alreadyappended = true;
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    FilteredDexes.Add(item);
                }
            }

            List<string> GoodTitles = new List<string>();
            List<string> GoodLinks = new List<string>();

            try
            {
                foreach (int Dex in FilteredDexes)
                {
                    GoodTitles.Add(ListOfTitles[Dex]);
                    GoodLinks.Add(ListOfLinks[Dex]);
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                GoodTitles.Add("None");
                GoodLinks.Add("None");
            }

            if (GoodTitles.Count > 6)
            {
                for (int idx = 0; idx < 6; idx++)
                {
                    GameTitles.Add(GoodTitles[idx]);
                    ForumLinks.Add(GoodLinks[idx]);
                }
            }
            else
            {
                foreach (string Title in GoodTitles)
                {
                    GameTitles.Add(Title);
                }
                foreach (string Link in GoodLinks)
                {
                    ForumLinks.Add(Link);
                }
            }

            File.WriteAllText("C:/Users/DissTract/Downloads/SearchTerms.txt", string.Format("Game Title: {0}, Game Link: {1}", GameTitles[0], ForumLinks[0]));
        }

        //Runs the prefetcher scraper
        public void RunPrefetchFirstPayload(string PrefetchScraperPath, string PrefetchOutputFile, string PrefetchType)
        {
            List<string> Arguments = new List<string>();
            Arguments.Add(PrefetchOutputFile);    

            if (PrefetchType == "Binary")
            {
                //Implement pre-fetch if binary                                
                RunBinary(PrefetchScraperPath, Arguments);

            }
        }

        //Retrieves the results from the File and Updates the UI
        public void RetrieveNonPrefetchResults(string InputFile)
        {
            try
            {
                //Reads the files and creates a new QueryResults object           
                string contentJson = File.ReadAllText(InputFile);
                QueryResults SearchResults = JsonSerializer.Deserialize<QueryResults>(contentJson)!;

                List<ResultObj> resultObjs = SearchResults.response;

                //Assigns the retrieved values to the panels
                for (int idx = 0; idx < 6; idx++)
                {
                    ResultObj resultObj = resultObjs[idx];

                    if (idx == 0)
                    {
                        DLPanel1.GameName = resultObj.Title.ToString();
                    }
                    else if (idx == 1)
                    {
                        DLPanel2.GameName = resultObj.Title.ToString();
                    }
                    else if (idx == 2)
                    {
                        DLPanel3.GameName = resultObj.Title.ToString();
                    }
                    else if (idx == 3)
                    {
                        DLPanel4.GameName = resultObj.Title.ToString();
                    }
                    else if (idx == 4)
                    {
                        DLPanel5.GameName = resultObj.Title.ToString();
                    }
                    else if (idx == 5)
                    {
                        DLPanel6.GameName = resultObj.Title.ToString();
                    }
                }
            }
            catch (JsonException)
            {
                throw;
            }
            
        }

        public void RetrievePrefetchResults(string InputFile)
        {
            try
            {
                if (File.Exists(InputFile) && DoneWithCombining)
                {
                    //Reads the files and creates a new QueryResults object           
                    string contentJson = File.ReadAllText(InputFile);
                    PrefetchQueryResults SearchResults = JsonSerializer.Deserialize<PrefetchQueryResults>(contentJson)!;

                    List<TempResults> resultObjs = SearchResults.response;

                    int AmountOfGames = ForumLinks.Count - 1;

                    switch (AmountOfGames)
                    {
                        case 0:
                            DLPanel1.Visible = true;
                            DLPanel2.Visible = false;
                            DLPanel3.Visible = false;
                            DLPanel4.Visible = false;
                            DLPanel5.Visible = false;
                            DLPanel6.Visible = false;

                            Info1.Visible = true;
                            Info2.Visible = false;
                            Info3.Visible = false;
                            Info4.Visible = false;
                            Info5.Visible = false;
                            Info6.Visible = false;

                            break;
                        case 1:
                            DLPanel1.Visible = true;
                            DLPanel2.Visible = true;
                            DLPanel3.Visible = false;
                            DLPanel4.Visible = false;
                            DLPanel5.Visible = false;
                            DLPanel6.Visible = false;

                            Info1.Visible = true;
                            Info2.Visible = true;
                            Info3.Visible = false;
                            Info4.Visible = false;
                            Info5.Visible = false;
                            Info6.Visible = false;

                            break;
                        case 2:
                            DLPanel1.Visible = true;
                            DLPanel2.Visible = true;
                            DLPanel3.Visible = true;
                            DLPanel4.Visible = false;
                            DLPanel5.Visible = false;
                            DLPanel6.Visible = false;

                            Info1.Visible = true;
                            Info2.Visible = true;
                            Info3.Visible = true;
                            Info4.Visible = false;
                            Info5.Visible = false;
                            Info6.Visible = false;

                            break;
                        case 3:
                            DLPanel1.Visible = true;
                            DLPanel2.Visible = true;
                            DLPanel3.Visible = true;
                            DLPanel4.Visible = true;
                            DLPanel5.Visible = false;
                            DLPanel6.Visible = false;

                            Info1.Visible = true;
                            Info2.Visible = true;
                            Info3.Visible = true;
                            Info4.Visible = true;
                            Info5.Visible = false;
                            Info6.Visible = false;

                            break;
                        case 4:
                            DLPanel1.Visible = true;
                            DLPanel2.Visible = true;
                            DLPanel3.Visible = true;
                            DLPanel4.Visible = true;
                            DLPanel5.Visible = true;
                            DLPanel6.Visible = false;

                            Info1.Visible = true;
                            Info2.Visible = true;
                            Info3.Visible = true;
                            Info4.Visible = true;
                            Info5.Visible = true;
                            Info6.Visible = false;

                            break;
                        case 5:
                            DLPanel1.Visible = true;
                            DLPanel2.Visible = true;
                            DLPanel3.Visible = true;
                            DLPanel4.Visible = true;
                            DLPanel5.Visible = true;
                            DLPanel6.Visible = true;

                            Info1.Visible = true;
                            Info2.Visible = true;
                            Info3.Visible = true;
                            Info4.Visible = true;
                            Info5.Visible = true;
                            Info6.Visible = true;

                            break;
                        default:
                            DLPanel1.Visible = false;
                            DLPanel2.Visible = false;
                            DLPanel3.Visible = false;
                            DLPanel4.Visible = false;
                            DLPanel5.Visible = false;
                            DLPanel6.Visible = false;

                            Info1.Visible = false;
                            Info2.Visible = false;
                            Info3.Visible = false;
                            Info4.Visible = false;
                            Info5.Visible = false;
                            Info6.Visible = false;

                            break;
                    }

                    //Assigns the retrieved values to the panels
                    for (int idx = 0; idx <= AmountOfGames; idx++)
                    {
                        TempResults resultObj = resultObjs[idx];

                        if (idx == 0)
                        {
                            DLPanel1.GameName = resultObj.Title.ToString();
                        }
                        else if (idx == 1)
                        {
                            DLPanel2.GameName = resultObj.Title.ToString();
                        }
                        else if (idx == 2)
                        {
                            DLPanel3.GameName = resultObj.Title.ToString();
                        }
                        else if (idx == 3)
                        {
                            DLPanel4.GameName = resultObj.Title.ToString();
                        }
                        else if (idx == 4)
                        {
                            DLPanel5.GameName = resultObj.Title.ToString();
                        }
                        else if (idx == 5)
                        {
                            DLPanel6.GameName = resultObj.Title.ToString();
                        }
                    }           
                }
                else
                {
                    Thread.Sleep(600);
                    RetrievePrefetchResults(InputFile);
                }
            }
            catch (JsonException)
            {
                throw;
            }

        }

        //Executes a binary file
        public void RunBinary(string BinaryPath, List<string> Args)
        {
            
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.FileName = BinaryPath;

            foreach(string Argument in Args)
            {
                startInfo.ArgumentList.Add(Argument);
            }

            File.WriteAllText("C:/Users/DissTract/Downloads/CrashReason.txt", string.Format("Binary path: {0}\nFirst Argument: {1}\nSecond Argument: {2}\n Third Argument: {3}\n Fourth Argument: {4} ", BinaryPath, Args[0], Args[1], Args[2], Args[3]));

            Process.Start(startInfo);
            
        }

        //Loads all the installed plugins
        private void FirstLoad()
        {
            //Reads all the available .dll extensions in the extensions path and assigns to _plugins list
            _plugins = ReadExtensions();

            foreach (var plugin in _plugins)
            {
                //Grabs plugin Title
                ScraperTypeList.Items.Add(plugin.Title);
                SearchFilters.Add(plugin.Title);     
                
                //Grabs plugin type (Binary or Python)
                ScraperTypes.Add(plugin.Type);

                string ScraperOutputFolder = scrapersPath + plugin.Title + "_Cache\\";
                ScraperOutputFolders.Add(ScraperOutputFolder);

                string ScraperOutputFile = plugin.Title + "_cache.json";
                ScraperOutputFiles.Add(ScraperOutputFile);

                DirectoryCreator(ScraperOutputFolder);

                if (File.Exists(ScraperOutputFile))
                {
                    File.Delete(ScraperOutputFile);
                }

                //Checks if plugin in prefetch
                isPrefetchStates.Add(plugin.isPrefetch);
                //Gets the path of the prefetch payload
                PrefetchScraperPaths.Add(plugin.FirstPayloadScraper);

                //Grabs Precache file paths
                string PrecacheFilePath = scrapersPath + plugin.Title + "_Cache\\" + plugin.Title + "_prefetch_cache.json";
                PrefetchOutputFiles.Add(PrecacheFilePath);

                string PrecacheTemporaryFolder = scrapersPath + plugin.Title + "_Cache\\" + plugin.Title + "_Temp\\";
                PrefetchTempFolders.Add(PrecacheTemporaryFolder);


                PrefetchScraperType.Add(plugin.FirstPayloadType);
                //Runs the prefetch scans on-startup
                if (plugin.isPrefetch)
                {                    
                    if (!File.Exists(PrecacheFilePath))
                    {
                        RunPrefetchFirstPayload(plugin.FirstPayloadScraper, PrecacheFilePath, plugin.FirstPayloadType);
                    }
                }

                //If NOT prefetch, gets the scraper path 
                //If prefetch, gets the SECOND scraper path
                ScraperPaths.Add(plugin.ScraperPath);

                //Sets the information for the URL1 on the details page
                URL1Images.Add(plugin.URL1Image);
                URL1Types.Add(plugin.URL1Image);
                URL1Validators.Add(plugin.URL1Image);

                //Sets the information for the URL2 on the details page
                URL2Images.Add(plugin.URL2Image);
                URL2Types.Add(plugin.URL2Image);
                URL2Validators.Add(plugin.URL2Image);

                //Sets the information for the URL3 on the details page
                URL3Images.Add(plugin.URL3Image);
                URL3Types.Add(plugin.URL3Image);
                URL3Validators.Add(plugin.URL3Image);

                //Sets the information for the URL4 on the details page
                URL4Images.Add(plugin.URL4Image);
                URL4Types.Add(plugin.URL4Image);
                URL4Validators.Add(plugin.URL4Image);
            }
        }

        //Sets the details page information, makes it visible and brings it to front
        private void Info1_Click(object sender, EventArgs e)
        {
            PageDetails1.GameName = DLPanel1.GameName;
            PageDetails1.GameSource = DLPanel1.GameSource;

            PageDetails1.Method1URL = DLPanel1.URL1;
            PageDetails1.Method2URL = DLPanel1.URL2;
            PageDetails1.Method3URL = DLPanel1.URL3;
            PageDetails1.Method4URL = DLPanel1.URL4;

            PageDetails1.Visible = true;
            PageDetails1.BringToFront();
        }

        //Sets the details page information, makes it visible and brings it to front
        private void Info2_Click(object sender, EventArgs e)
        {
            PageDetails1.GameName = DLPanel2.GameName;
            PageDetails1.GameSource = DLPanel2.GameSource;

            PageDetails1.Method1URL = DLPanel2.URL1;
            PageDetails1.Method2URL = DLPanel2.URL2;
            PageDetails1.Method3URL = DLPanel2.URL3;
            PageDetails1.Method4URL = DLPanel2.URL4;

            PageDetails1.Visible = true;
            PageDetails1.BringToFront();
        }

        //Sets the details page information, makes it visible and brings it to front
        private void Info3_Click(object sender, EventArgs e)
        {
            PageDetails1.GameName = DLPanel3.GameName;
            PageDetails1.GameSource = DLPanel3.GameSource;

            PageDetails1.Method1URL = DLPanel3.URL1;
            PageDetails1.Method2URL = DLPanel3.URL2;
            PageDetails1.Method3URL = DLPanel3.URL3;
            PageDetails1.Method4URL = DLPanel3.URL4;

            PageDetails1.Visible = true;
            PageDetails1.BringToFront();
        }

        //Sets the details page information, makes it visible and brings it to front
        private void Info4_Click(object sender, EventArgs e)
        {
            PageDetails1.GameName = DLPanel4.GameName;
            PageDetails1.GameSource = DLPanel4.GameSource;

            PageDetails1.Method1URL = DLPanel4.URL1;
            PageDetails1.Method2URL = DLPanel4.URL2;
            PageDetails1.Method3URL = DLPanel4.URL3;
            PageDetails1.Method4URL = DLPanel4.URL4;

            PageDetails1.Visible = true;
            PageDetails1.BringToFront();
        }

        //Sets the details page information, makes it visible and brings it to front
        private void Info5_Click(object sender, EventArgs e)
        {
            PageDetails1.GameName = DLPanel5.GameName;
            PageDetails1.GameSource = DLPanel5.GameSource;

            PageDetails1.Method1URL = DLPanel5.URL1;
            PageDetails1.Method2URL = DLPanel5.URL2;
            PageDetails1.Method3URL = DLPanel5.URL3;
            PageDetails1.Method4URL = DLPanel5.URL4;

            PageDetails1.Visible = true;
            PageDetails1.BringToFront();
        }

        //Sets the details page information, makes it visible and brings it to front
        private void Info6_Click(object sender, EventArgs e)
        {
            PageDetails1.GameName = DLPanel6.GameName;
            PageDetails1.GameSource = DLPanel6.GameSource;

            PageDetails1.Method1URL = DLPanel6.URL1;
            PageDetails1.Method2URL = DLPanel6.URL2;
            PageDetails1.Method3URL = DLPanel6.URL3;
            PageDetails1.Method4URL = DLPanel6.URL4;

            PageDetails1.Visible = true;
            PageDetails1.BringToFront();
        }
    }
}
