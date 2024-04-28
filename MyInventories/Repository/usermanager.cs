using MyInventories.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyInventories.Repository
{
    public class usermanager
    {
        private BaseRepository<useraccount> _userAcc;
        private BaseRepository<userinformation> _userInf;
        public usermanager()
        {
            _userAcc = new BaseRepository<useraccount>();
            _userInf = new BaseRepository<userinformation>();
        }
        public useraccount GetUserById(int Id)
        {
            return _userAcc.Get(Id);
        }
        public useraccount GetUserByUserId(String userId)
        {
            return _userAcc._table.Where(m => m.userid == userId).FirstOrDefault();
        }
        public useraccount GetUserByUsername(String username)
        {
            return _userAcc._table.Where(m => m.username == username).FirstOrDefault();
        }
        public useraccount GetUserByEmail(String email)
        {
            return _userAcc._table.Where(m => m.email == email).FirstOrDefault();
        }
        public ErrorCode SignIn(String username, String password, ref String errMsg)
        {
            var userSignIn = GetUserByUsername(username);
            if (userSignIn == null)
            {
                errMsg = "User not exist!";
                return ErrorCode.Error;
            }

            if (!userSignIn.password.Equals(password))
            {
                errMsg = "Password is Incorrect";
                return ErrorCode.Error;
            }

            // user exist
            errMsg = "Login Successful";
            return ErrorCode.Success;
        }
        public ErrorCode SignUp(useraccount ua, ref String errMsg)
        {
            ua.userId = Utilities.gUid;
            ua.code = Utilities.code.ToString();
            ua.date_created = DateTime.Now;
            ua.status = (Int32)Status.InActive;

            if (GetUserByUsername(ua.username) != null)
            {
                errMsg = "Username Already Exist";
                return ErrorCode.Error;
            }

            if (GetUserByEmail(ua.email) != null)
            {
                errMsg = "Email Already Exist";
                return ErrorCode.Error;
            }

            if (_userAcc.Create(ua, out errMsg) != ErrorCode.Success)
            {
                return ErrorCode.Error;
            }

            // use the generated code for OTP "ua.code"
            // send email or sms here...........

            return ErrorCode.Success;
        }
    }
}