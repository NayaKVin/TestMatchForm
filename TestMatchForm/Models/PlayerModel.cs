using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMatchForm.Models
{
    public class PlayerModel
    {
        public string MatchId { get; set; }
        public string MName { get; set; }
        public string TeamOne { get; set; }
        public string Teamtwo { get; set; }
        public DateTime Mdate { get; set; }
        public DateTime MTime { get; set; }
        public string MAddr { get; set; }
        public string plyrNm { get; set; }
        public string PlyrType { get; set; }
        public string PlyrPostion { get; set; }
        public string PlyrCnty { get; set; }
        public string MPlyr { get; set; }

        //public List<PlayerTbl> MPlyr { get; set; }
    }

    public class PlayerTbl
    {
        public string plyrNm { get; set; }
        public string PlyrType { get; set; }
        public string PlyrPostion { get; set; }
        public string PlyrCnty { get; set; }
    }
}