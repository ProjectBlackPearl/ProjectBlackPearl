using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Project_Black_Pearl
{
    public class Data
    {
        
    }
    public class Game
    {
        public int? GameID { get; set; }
        public string? GameName { get; set; }
        public string? GamePath { get; set; }
        public double? GameSize { get; set; }
        public double? GamePlaytime { get; set; }
        public string? GameLauncher { get; set; }
        public string? GameAccount { get; set; }
        public string? GameDescription { get; set; }
        public string? GameCoverImage { get; set; }
        public string? LastLaunchDate { get; set; }
        public int? ImageEdits { get; set; }
    }
}
