using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMatchForm.Models;
using MySql.Data.MySqlClient;

namespace TestMatchForm.Controllers
{
    public class MatchFormController : Controller
    {
        // GET: MatchForm
        public ActionResult TestMchForm()
        {
            return View();
        }

        public JsonResult Insertplayers(PlayerModel MachDta)
        {
            int MatchId = 1; // we can write logic for match ID

            string constr = ConfigurationManager.ConnectionStrings["TestCon"].ConnectionString;
            using (MySqlConnection conn = new MySqlConnection(constr))
            {
                string query = "insert into testmatch.tbl_match (MatchId, MatchName, matchDate, team1, team2, StartTime, Address) value('" + MatchId + "','" + MachDta.MName + "','" + MachDta.Mdate + "','" + MachDta.TeamOne + "','" + MachDta.Teamtwo + "','" + MachDta.MTime + "','" + MachDta.MAddr + "')";

                //Response.Write(query);
                using (MySqlCommand cmmd = new MySqlCommand(query))
                {
                    cmmd.Connection = conn;
                    conn.Open();
                    try { cmmd.ExecuteNonQuery(); }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }

                }
                conn.Close();
            }


            string plyrNm = "", Batsman = "", PlyrPostion = "", PlyrCnty = "";
            string[] tblRow = MachDta.MPlyr.Split('|');
            foreach (string RoCOl in tblRow)
            {
                int i = 0;
                string[] RC = RoCOl.Split('`');
                foreach (string cel in RC)
                {
                    if (i == 0) { plyrNm = cel; }
                    if (i == 1) { Batsman = cel; }
                    if (i == 2) { PlyrPostion = cel; }
                    if (i == 3) { PlyrCnty = cel; }
                    i++;

                }

                using (MySqlConnection conn = new MySqlConnection(constr))
                {
                    string query = "insert into testmatch.match_players(MatchId, PlyrName, PlyrType, PlyrPostion, team) value('" + MatchId + "','" + plyrNm + "','" + Batsman + "','" + PlyrPostion + "','" + PlyrCnty + "')";

                    using (MySqlCommand cmmd = new MySqlCommand(query))
                    {
                        cmmd.Connection = conn;
                        conn.Open();

                        try { cmmd.ExecuteNonQuery(); }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    conn.Close();
                }

            }




            return Json("Success");
        }
    }
}