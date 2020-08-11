using Aphrie.project.BLL.Mangers;
using Aphrie.Project.DAL.SQLServer.model;
using Aphrie.Project.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aphrie.Project.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManger userManger;
        private readonly AddFriendManger addFriendManger;


        public HomeController(UserManger _userManger, AddFriendManger _addFriendManger)
        {
            this.userManger = _userManger;
            this.addFriendManger = _addFriendManger;
        }

        public ActionResult Index()
        {
            int Id = userManger.GetAllBind().SingleOrDefault(u => u.Username == HttpContext.User.Identity.Name).Id;
            List<AddFriend> list = addFriendManger.GetAll().Where(u => u.SenderId == Id).ToList();
            List<int> Mylist= new List<int>(); ;
            
            foreach (var item in list)
            {
                //Mylist = new List<int>();
                Mylist.Add(userManger.GetAllBind().SingleOrDefault(u => u.Id == item.ReceiverId).Id);

               
            };
           
            var myuserslist = userManger.GetAll().ToList();
            var mylistOfAccounts = new List<Account>();
            Account acc;
            foreach (var item in myuserslist)
            {
                acc = new Account();
                acc.Name = item.Username;
                acc.Password = item.Password;
                acc.Id = item.Id;
                mylistOfAccounts.Add(acc);
                if (Mylist.Contains(item.Id))
                {
                    acc.AddOrRemove = true;
                }
            }
            return View(mylistOfAccounts);
        }

        public ActionResult SendFriendReq(int id)
        {
            
            AddFriend friend = new AddFriend {SenderId = userManger.GetId(), ReceiverId= id , Status=false};
            Users user = userManger.GetBy(friend.ReceiverId);
            addFriendManger.Add(friend);

            ViewBag.Message = "Your application description page.";
            TempData["message"] = string.Format("{0} was added", user.Username);

            return RedirectToAction("Index");
        }
        public ActionResult RemoveFriendReq(int id)
        {

            AddFriend friend2 = addFriendManger.GetBy( userManger.GetId(), id); 
            addFriendManger.Delete(friend2);
            Users user = userManger.GetBy(id);
            TempData["message"] = string.Format("{0} was deleted", user.Username);

            ViewBag.Message = "Your application description page.";

            return RedirectToAction("Index");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //public ActionResult Cheack()
        //{

        //}
    }
}