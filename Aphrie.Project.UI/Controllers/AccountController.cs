using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aphrie.project.BLL.Mangers;
using Aphrie.project.BLL.Concert;
using Aphrie.Project.DAL.SQLServer.model;
using Aphrie.Project.UI.Models;
using System.Web.Security;
using System.IO;
using System.Net;

namespace Aphrie.Project.UI.Controllers
{
    public class AccountController : Controller
    {

        private readonly Authentication authentication;
        private readonly UnitOfWork unitOfWork;
        public AccountController(UnitOfWork _unitOfWork, Authentication _authentication)
        {

            this.authentication = _authentication;
            this.unitOfWork = _unitOfWork;

           
        }
        // GET: Account
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(Account account)
        {
            if (ModelState.IsValid)
            {
                if (authentication.CheackLogin(account.Name, account.Password))
                {
                    FormsAuthentication.SetAuthCookie(account.Name, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Username  or password  is  error ");
                return View();
               
            }
            return View();
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegesterViewModel regesterView)
        {   

            Users user = new Users()
            {
                Password = regesterView.Password,
                Username = regesterView.Username,
                Phone = regesterView.Phone
            };
            unitOfWork.UserManger.Add(user);
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [Authorize]
        public ActionResult CreatPost()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreatPost(PostViewModel model, HttpPostedFileBase ImageFile)
        {
            if (ImageFile != null && ImageFile.ContentLength > 0)
            {
                string FileName = Path.GetFileName(ImageFile.FileName);
                string ImagePath = Path.Combine(Server.MapPath("~/images/"), FileName);
                ImageFile.SaveAs(ImagePath);
            }
            Post MyPost = new Post
            {
                Image = "/images/" + ImageFile.FileName,
                //ImageFile = postViewModel.ImageFile,
                //Imagepath = postViewModel.Imagepath,
                content = model.Content,
                //Photo = postViewModel.PhotoUrl,
                creatby = HttpContext.User.Identity.Name,
                creatdate = DateTime.Now,
                Users_Id = unitOfWork.UserManger.GetId()
            };

            unitOfWork.postManger.Add(MyPost);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult PostList()
        {
            int Id = unitOfWork.UserManger.GetAllBind().SingleOrDefault(u => u.Username == HttpContext.User.Identity.Name).Id;
            List<AddFriend> list = unitOfWork.AddFriendManger.GetAll().Where(u => u.SenderId == Id).ToList();
            List<Post> Mylist = new List<Post>();
            foreach (var item in list)
            {
               Mylist.AddRange(unitOfWork.postManger.GetAllBind().Where(u => u.Isarchived == false && u.Users_Id == item.ReceiverId).ToList());
            };
            //List<PostViewModel> MyPostViewModel = new List<PostViewModel>();
            List<PostViewModel> MyPostViewModel = Mylist.Select(u => new PostViewModel {
                Id = u.Id, 
                Content = u.content,
                createBy = u.creatby,
                CreatedDate = u.creatdate,
                Image = u.Image,
                Isarchived = u.Isarchived 
            }).ToList();
            return View(MyPostViewModel);
        }

        [Authorize]
        public ActionResult PersonalPage()
        {

            int myUserId =unitOfWork.UserManger.GetId();
            List<Post> MylistOfPosts = unitOfWork.postManger.GetAll().Where(u => u.Users_Id == myUserId).ToList();
            List<PostViewModel> MypostListViewModel = MylistOfPosts.Where(u => u.Isarchived == false)
                .Select(u => new PostViewModel {
                Id = u.Id,
                Image = u.Image,
                Isarchived = u.Isarchived,
                Content = u.content, 
                createBy = u.creatby,
                CreatedDate = u.creatdate
            }).ToList();
            return View(MypostListViewModel);
        }

        public ActionResult Delete(int Id)
        {
            Post MyPost = unitOfWork.postManger.GetAllBind().FirstOrDefault(u => u.Id == Id);

            PostViewModel Model = new PostViewModel {
                Content = MyPost.content, 
                createBy = MyPost.creatby, 
                CreatedDate = MyPost.creatdate, 
                Image = MyPost.Image, 
                Isarchived = MyPost.Isarchived, 
                Id = MyPost.Id 
            };
            return View(Model);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Delete(PostViewModel Model)
        {
            Post MyPost = unitOfWork.postManger.GetAllBind().FirstOrDefault(u => u.Id == Model.Id);
            MyPost.Isarchived = true;
            unitOfWork.Save();
            return RedirectToAction("PersonalPage", "Account");
        }


    }
}