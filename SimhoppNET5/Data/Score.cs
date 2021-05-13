using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimhoppNET5.Data
{
    public class Scores
    {
        public int SCID { get; set; }
        public float Dive1_Judge1_result { get; set; }
        public float Dive1_Judge2_result { get; set; }
        public float Dive1_Judge3_result { get; set; }
        public float Dive1_Difficulty { get; set; }
        public float Dive1_Total_results { get; set; }

        public float Dive2_Judge1_result { get; set; }
        public float Dive2_Judge2_result { get; set; }
        public float Dive2_Judge3_result { get; set; }
        public float Dive2_Difficulty { get; set; }
        public float Dive2_Total_results { get; set; }

        public float Dive3_Judge1_result { get; set; }
        public float Dive3_Judge2_result { get; set; }
        public float Dive3_Judge3_result { get; set; }
        public float Dive3_Difficulty { get; set; }
        public float Dive3_Total_results { get; set; }

        public float Final_Total { get; set; }

    }
}

