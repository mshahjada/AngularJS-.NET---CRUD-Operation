using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AngularBasic.Models;

namespace AngularBasic.Controllers
{
    public class HomeController : Controller
    {
        
        

        //private void DataKeep(List<Customer> customer)
        //{
        //    if(Session["Data"] == null)
        //    {
        //        Session["Data"] = DataSet.GetAllCustomer();
        //    }
        //    else
        //    {
        //        Session["Data"] = customer;

        //    }
        //}

        public ActionResult Index()
        {
            DataSet.Initialize();
            ViewBag.Customers = DataSet.GetAllCustomer();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        public JsonResult Get(int id)
        {
            Customer customer = new Customer();
            try
            {
               var result = DataSet.GetAllCustomer().Where(x => x.CustomerId == id).ToList();
                if (result.Any())
                    customer = result.First();
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                Response.StatusDescription = e.Message.ToString();
            }
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Save(Customer customer)
        {
            try
            {
                if (customer.CustomerId <=0 )
                    throw new Exception("Invalid Id.");
                else if (customer.CustomerName.Trim() == "")
                    throw new Exception("Customer Name Required.");
                else if (customer.Address.Trim() == "")
                    throw new Exception("Customer Address Required.");

                DataSet.AddCustomer(customer);

                var x = DataSet.GetAllCustomer();
                x.Add(customer);

                var t = Session["Data"];
                Session["Data"] = x;

                
            }
            catch(Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Response.StatusDescription = e.Message.ToString();
            }
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult Edit(Customer customer)
        {
            try
            {
                if (!DataSet.GetAllCustomer().Where(x => x.CustomerId == customer.CustomerId).Any())
                    throw new Exception("Invalid Customer, Unable to Edit.");
                else if (customer.CustomerName.Trim() == "")
                    throw new Exception("Customer Name Required.");
                else if (customer.Address.Trim() == "")
                    throw new Exception("Customer Address Required.");

                DataSet.EditCustomer(customer);
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.Forbidden;
                Response.StatusDescription = e.Message.ToString();
            }
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult Delete(Customer customer)
        {
            bool remove = false;
            try
            {
                if (!DataSet.GetAllCustomer().Where(x=>x.CustomerId== customer.CustomerId).Any())
                    throw new Exception("Invalid Customer, Unable to Delete.");

                DataSet.DeleteCustomer(customer);
                remove = true;
            }
            catch (Exception e)
            {
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                Response.StatusDescription = e.Message.ToString();
            }
            return Json(remove, JsonRequestBehavior.AllowGet);
        }

    }
}