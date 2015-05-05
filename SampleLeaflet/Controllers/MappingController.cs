using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SampleLeaflet.Models;
using System.Configuration;

namespace SampleLeaflet.Controllers
{
    public class MappingController : Controller
    {
        // GET: Mapping
        public ActionResult Index()
        {
            return PartialView();
        }

        public JsonResult LoadAllAreaGuide()
        {
            List<AreaGuide> results = new List<AreaGuide>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBAreaGuide"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT AreaID,Type,AvgPrice,Rating,Notes FROM dbo.AreaGuide";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AreaGuide ag = new AreaGuide();
                            ag.AreaID = reader["AreaID"].ToString();
                            results.Add(ag);
                            ag.Type = reader["Type"].ToString();
                            ag.AvgPrice = Decimal.Parse(reader["AvgPrice"].ToString());
                            ag.Rating = Byte.Parse(reader["Rating"].ToString());
                            ag.Notes = reader["Notes"].ToString();
                        }
                        reader.Dispose();
                    }
                    cmd.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }

            return Json(results,JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadAreaGuide(string areaID)
        {
            List<AreaGuide> results = new List<AreaGuide>();

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DBAreaGuide"].ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT AreaID,Type,AvgPrice,Rating,Notes FROM dbo.AreaGuide WHERE AreaID = '{0}'",areaID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AreaGuide ag = new AreaGuide();
                            ag.AreaID = reader["AreaID"].ToString();
                            ag.Type = reader["Type"].ToString();
                            ag.AvgPrice = Decimal.Parse(reader["AvgPrice"].ToString());
                            ag.Rating = Byte.Parse(reader["Rating"].ToString());
                            ag.Notes = reader["Notes"].ToString();
                            results.Add(ag);
                        }
                        reader.Dispose();
                    }
                    cmd.Dispose();
                }
                conn.Close();
                conn.Dispose();
            }

            return Json(results, JsonRequestBehavior.AllowGet);
        }
    }
}