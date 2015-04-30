using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LeaftletSample.Models;

namespace LeaftletSample.Controllers
{
    public class MappingController : Controller
    {
        // GET: Mapping
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoadAllAreaGuide()
        {
            List<AreaGuide> results = new List<AreaGuide>();

            using (SqlConnection conn = new SqlConnection("Data Source=RaviPC;Initial Catalog=jqGridDB;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT AreaID FROM dbo.AreaGuide";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AreaGuide ag = new AreaGuide();
                            ag.AreaID = reader["AreaID"].ToString();
                            results.Add(ag);
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

            using (SqlConnection conn = new SqlConnection("Data Source=RaviPC;Initial Catalog=jqGridDB;Integrated Security=True"))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT AreaID FROM dbo.AreaGuide WHERE AreaID = '{0}'",areaID);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AreaGuide ag = new AreaGuide();
                            ag.AreaID = reader["AreaID"].ToString();
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