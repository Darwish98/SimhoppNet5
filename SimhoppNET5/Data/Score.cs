using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimhoppNET5.Data
{
    public class Scores
    {
        public int Score_ID { get; set; }
        public float Judge1_result { get; set; }
        public float Judge2_result { get; set; }
        public float Judge3_result { get; set; }
        public float Difficulty { get; set; }
        public float Total_results { get; set; }
    }
}

