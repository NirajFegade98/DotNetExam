using DotNetLabExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetLabExam.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            List<Products> lst = new List<Products>();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DotNetExam;Integrated Security=True";
            sc.Open();
            SqlCommand scm = new SqlCommand();
            scm.Connection = sc;
            scm.CommandType = System.Data.CommandType.StoredProcedure;
            scm.CommandText = "displayProducts";
            SqlDataReader dr = scm.ExecuteReader();
            while (dr.Read())
            {
                lst.Add(new Products { Productid = (int)dr["Productid"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] });
            }
            dr.Close();
            sc.Close();
            return View(lst);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            Products obj = new Products();
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DotNetExam;Integrated Security=True";
            sc.Open();
            SqlCommand scm = new SqlCommand();
            scm.Connection = sc;
            scm.CommandType = System.Data.CommandType.StoredProcedure;
            scm.CommandText = "updatedetails";
            scm.Parameters.AddWithValue("@id",id);
            SqlDataReader dr = scm.ExecuteReader();
            while (dr.Read())
            {
               obj = new Products { Productid = (int)dr["Productid"], ProductName = (string)dr["ProductName"], Rate = (decimal)dr["Rate"], Description = (string)dr["Description"], CategoryName = (string)dr["CategoryName"] };
            }
            dr.Close();
            sc.Close();
            return View(obj);           
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Products obj)
        {
            SqlConnection sc = new SqlConnection();
            sc.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DotNetExam;Integrated Security=True";
            sc.Open();
            SqlCommand scm = new SqlCommand();
            scm.Connection = sc;
            scm.CommandType = System.Data.CommandType.StoredProcedure;
            scm.CommandText = "updateProducts";
            scm.Parameters.AddWithValue("@id", id);
            scm.Parameters.AddWithValue("@ProductName", obj.ProductName);
            scm.Parameters.AddWithValue("@Rate", obj.Rate);
            scm.Parameters.AddWithValue("@Description", obj.Description);
            scm.Parameters.AddWithValue("@CategoryName", obj.CategoryName);
            scm.ExecuteNonQuery();
            sc.Close();
            return RedirectToAction("Index");
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
