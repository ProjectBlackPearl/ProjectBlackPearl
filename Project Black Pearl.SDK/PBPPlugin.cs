using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Black_Pearl.SDK
{
    public interface PBPPlugin
    {
        //Any title works, please choose a unique one as you could crash the app if 2 plugins have the same Title
        public string Title { get; }
        //Either "Binary" or "Python" (secondary scraper type if this is a prefetch plugin)
        public string Type { get; }


        //ONLY USE THESE ENTRIES IF YOU'RE GONNA USE A PREFETCH PLUGIN, BE SURE TO SET THE "isPrefetch" TO FALSE IF YOU AREN'T


        //True if your plugin is a Prefetch, MUST SET AS FALSE IF YOU'RE NOT USING A PREFETCH
        public bool isPrefetch { get; }

        //Specify the Prefetch Scraper's path that grabs all the entries
        public string FirstPayloadScraper { get; }
        //Specify if the prefetch scraper is either "Python" or "Binary"
        public string FirstPayloadType { get; }


        //ONLY USE THE ENTRIES ABOVE IF YOU'RE MAKING A PREFETCH SCRAPER, ELSE SET ALL THE VALUES TO "" AND ISPREFETCH TO FALSE


        //Specify the Scraper's Path relative to the plugin DLL if not prefetch
        //Specify the Second Payload scraper if prefetch
        public string ScraperPath { get; }
       


        //Set the URL1's Image path Relative to the plugin DLL
        public string URL1Image { get; }
        //Set the URL1's Title that appears in the DL page
        public string URL1Type { get; }
        //Set the URL1 validator (checks if the provided link matches this validator, sets as unavailable source if a different one is provided by the scraper)
        public string URL1Validator { get; }


        public string URL2Image { get; }
        public string URL2Type { get; }
        public string URL2Validator { get; }


        public string URL3Image { get; }
        public string URL3Type { get; }
        public string URL3Validator { get; }


        public string URL4Image { get; }
        public string URL4Type { get; }
        public string URL4Validator { get; }
    }
}
