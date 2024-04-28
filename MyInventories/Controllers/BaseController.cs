using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyInventories.Repository;

namespace MyInventories.Controllers
{
    public class BaseController : Controller
    {
        public string ErrorMessage;
        public usermanager _usermanager;
        public BaseRepository<useraccount> _userRepo;
        public langEntities _db;

        public String Username { get { return User.Identity.Name; } }
        public String UserId { get { return _usermanager.GetUserByUsername(Username).userid; } }

        public BaseController()
        {
            _usermanager = new usermanager();
            ErrorMessage = String.Empty;
            _db = new langEntities();
            _userRepo = new BaseRepository<useraccount>();

        }
    }
}