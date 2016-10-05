using Calc_ikolotov;
using MvcCalc.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MvcCalc.Controllers
{
    public class CalcController : Controller
    {
        public Helper calcHelper { get; set; }
        // GET: /Calc/

        public ActionResult Index(CalcModel data)
        {
            var model = data ?? new CalcModel();


            if (ModelState.IsValid)
            {
                var calcHelper = new Helper();
                //var methods = calcHelper.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
                model.Result = calcHelper.Sum(model.X, model.Y);

                var oper = string.Format("{0} {1} {2} = {3}", model.X, "SUM", model.Y, model.Result);

                AddOperation(oper);
                //foreach (var m in methods)
                //{
                //    //для кажд метода _ свой rb 
                //    model.Action[0] = m.Name;
                //    //m.Name
                //}
                //model.Result = calcHelper.Sum(model.X, model.Y);
            }

            
            
            ViewData.Model = model;
            return View();
        }



        public ActionResult History()
        {
            return View(GetOperation());
        }


        #region work with bd

        private void AddOperation(string oper)
        {
            // connect to db
            //create request
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                var queryString = string.Format("INSERT INTO [dbo].[History] ([Operation]) VALUES (N'{0}')", oper);

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private IEnumerable<string> GetOperation()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            var result = new List<string>();

            using (SqlConnection connection = new SqlConnection(
               connectionString))
            {
                var queryString = "SELECT [Operation] FROM [dbo].[History]";

                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Add(reader.GetString(0));
                        
                    }
                }
                reader.Close();
            }

            return result;
        }
        #endregion
    }
}
