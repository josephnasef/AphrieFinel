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

        private readonly postManger postManger;
        private readonly Authentication authentication;
        private readonly UserManger userManger;
        private readonly AddFriendManger addFriendManger;
        public AccountController(postManger _postManger, Authentication _authentication, UserManger _userManger, AddFriendManger _addFriendManger)
        {

            this.postManger = _postManger;
            this.authentication = _authentication;
            this.userManger = _userManger;
            this.addFriendManger = _addFriendManger;
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
            userManger.Add(user);
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
                Users_Id = userManger.GetId()
            };

            postManger.Add(MyPost);

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult PostList()
        {
            int Id = userManger.GetAllBind().SingleOrDefault(u => u.Username == HttpContext.User.Identity.Name).Id;
            List<AddFriend> list = addFriendManger.GetAll().Where(u => u.SenderId == Id).ToList();
            List<Post> Mylist = new List<Post>();
            foreach (var item in list)
            {
               Mylist.AddRange(postManger.GetAllBind().Where(u => u.Isarchived == false && u.Users_Id == item.ReceiverId).ToList());
            };
            List<PostViewModel> MyPostViewModel = new List<PostViewModel>();
            PostViewModel mypost;
            int i = 0;
            foreach (var item in Mylist)
            {
                ViewBag.Id = item.Id;
                mypost = new PostViewModel();
                mypost.Id = item.Id;
                mypost.Content = item.content;
                mypost.Image = item.Image;
                mypost.createBy = item.creatby;
                MyPostViewModel.Insert(i++, mypost);
                var image = item.Image;
            }

            return View(MyPostViewModel);
        }

        [Authorize]
        public ActionResult PersonalPage()
        {

            int myUserId = userManger.GetId();
            List<Post> MylistOfPosts = postManger.GetAll().Where(u => u.Users_Id == myUserId).ToList();
            List<PostViewModel> MypostListViewModel = new List<PostViewModel>();
            PostViewModel Temp;
            foreach (var item in MylistOfPosts)
            {
                if (item.Isarchived == false)
                {
                    Temp = new PostViewModel();
                    Temp.Content = item.content;
                    Temp.createBy = item.creatby;
                    Temp.CreatedDate = item.creatdate;
                    Temp.Image = item.Image;
                    Temp.Id = item.Id;
                    MypostListViewModel.Add(Temp);
                }
            }
            return View(MypostListViewModel);
        }

        public ActionResult Delete(int Id)
        {
            Post MyPost = postManger.GetAllBind().FirstOrDefault(u => u.Id == Id);
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
            Post MyPost = postManger.GetAllBind().FirstOrDefault(u => u.Id == Model.Id);
            MyPost.Isarchived = true;
            postManger.Save();
            return RedirectToAction("PersonalPage", "Account");
        }

        //public ActionResult follow()
        //{

        //    return View();
        //}

        #region Help
       
        
        #endregion

    }
}