using Aphrie.project.BLL.Concert;
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
       
        private readonly UnitOfWork unitOfWork;


        public HomeController( UnitOfWork _unitOfWork)
        {
           
            this.unitOfWork = _unitOfWork;
        }

        public ActionResult Index()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    int Id = unitOfWork.UserManger.GetAllBind().SingleOrDefault(u => u.Username == HttpContext.User.Identity.Name).Id;
                    List<AddFriend> list = unitOfWork.AddFriendManger.GetAll().Where(u => u.SenderId == Id).ToList();
                    List<int> Mylist = new List<int>(); ;

                    foreach (var item in list)
                    {
                        Mylist.Add(unitOfWork.UserManger.GetAllBind().SingleOrDefault(u => u.Id == item.ReceiverId).Id);
                    };

                    var myuserslist = unitOfWork.UserManger.GetAll().ToList().Where(u=>u.Id!=unitOfWork.UserManger.GetId()).Select(u=> new Account {IsFollow= Mylist.Contains(u.Id)?true:false,Id=u.Id,Name=u.Username,Password=u.Password}).OrderBy(u=>u.Name);
                    return View(myuserslist);

                }
                else
                {
                    return View("Error");
                    ViewBag.ErrorMessage = "Enter valid username  or passwor";
                }
            }
            catch (Exception)
            {
                ViewBag.ErrorMessage = "Enter valid username  or passwor";
                return View("Error");
                //throw new System.InvalidOperationException("error in page ");
            }
           
            
        }

        public void toggleFriendReq(int Id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (unitOfWork.AddFriendManger.cheackfrienreq(Id, unitOfWork.UserManger.GetId()))
                    {
                        AddFriend friend2 = unitOfWork.AddFriendManger.GetBy(unitOfWork.UserManger.GetId(), Id);
                        unitOfWork.AddFriendManger.Delete(friend2);
                        Users user = unitOfWork.UserManger.GetBy(Id);
                      
                    }
                    else
                    {
                        AddFriend friend = new AddFriend { SenderId = unitOfWork.UserManger.GetId(), ReceiverId = Id, Status = false };
                        Users user = unitOfWork.UserManger.GetBy(friend.ReceiverId);
                        unitOfWork.AddFriendManger.Add(friend);
                        
                    }
                }
                else
                {
                    throw new System.InvalidOperationException("send requiest is faild");
                }
            }
            catch (Exception)
            {

                throw new System.InvalidOperationException("error in page ");
            }
           
        }

    }
}