using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wStoreData.Model;

namespace wStoreWebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        public ActionResult Knockout()
        {
            ViewBag.Title = "Knockout";

            return View("Knockout");
        }

        public ActionResult Angular()
        {
            ViewBag.Title = "Angular";

            return View("Angular");
        }
        public ActionResult Others()
        {
            ViewBag.Title = "Others";

            var data = new System.Collections.Generic.List<CustomerModel>();
            //get data from source
            data = ReturnData();
            //retrn data to view using model directive
            return View("Others", data);

        }

        public List<CustomerModel> ReturnData()
        {
            //get file path from server
            string xmldata = Server.MapPath("~/App_Data/Customer.xml");
            DataSet ds = new DataSet();
            //read the xml data from file using dataset
            ds.ReadXml(xmldata);
            //get data from dataset,convert and store it in list. 
            var customerlist = new List<CustomerModel>();
            customerlist = (from rows in ds.Tables[0].AsEnumerable()
                            select new CustomerModel
                            {
                                CustomerID = Convert.ToInt32(rows[0].ToString()),
                                CustomerName = rows[1].ToString(),
                                Contact = Convert.ToInt32(rows[2].ToString()),
                                DateOfPurchase = Convert.ToDateTime(rows[3].ToString()),
                                Address = rows[3].ToString()
                            }).ToList();
            return customerlist;
        }


        //loads the child files based on list
        public void GetTreeView(List<TFileStructure> list, TFileStructure current, ref List<TFileStructure> returnlist)
        {
            var childs = list.Where(a => a.ParentID == current.FileID).ToList();
            current.Childs = new List<TFileStructure>();
            current.Childs.AddRange(childs);
            foreach (var i in childs)
            {
                GetTreeView(list, i, ref returnlist);
            }
        }
        //bulids the tree 
        public List<TFileStructure> BuildTree(List<TFileStructure> list)
        {
            List<TFileStructure> returnList = new List<TFileStructure>();
            var topLevels = list.Where(a => a.ParentID == list.OrderBy(b => b.ParentID).FirstOrDefault().ParentID);
            returnList.AddRange(topLevels);
            foreach (var i in topLevels)
            {
                GetTreeView(list, i, ref returnList);
            }
            return returnList;
        }
        //Sends the data to TreeView in JSON format
        public JsonResult GetFileStructure()
        {
            List<TFileStructure> list = new List<TFileStructure>();
            using (var db = new Entities())
            {
                list = db.TFileStructures.OrderBy(a => a.FileName).ToList();
            }

            List<TFileStructure> treelist = new List<TFileStructure>();
            if (list.Count > 0)
            {
                treelist = BuildTree(list);
            }

            return new JsonResult { Data = new { treeList = treelist }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}

