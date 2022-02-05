using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pyatnashki
{
    [Serializable]
    public class GameResult
    {
        //[System.Xml.Serialization.XmlElement("Player")]
        public string Player { get; set; }

        //[System.Xml.Serialization.XmlElement("BeginTime")]
        public DateTime BeginTime { get; set; }

        //[System.Xml.Serialization.XmlElement("CollectTime")]
        public int CollectTime { get; set; }

       // [System.Xml.Serialization.XmlElement("StepNumber")]
        public int StepNumber { get; set; }
        public GameResult()
        { }
        public GameResult(string player, DateTime begTime, int collTime, int step)
        {
            Player = player;
            BeginTime = begTime;
            CollectTime = collTime;
            StepNumber = step;
        }
    }
}
