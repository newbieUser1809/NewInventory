using MyInventories.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyInventories.Utils
{
    public enum ErrorCode
    {
        Success,
        Error
    }
    public enum Status
    {
        InActive,
        Active
    }

    public enum RoleType
    {
        Customer,
        Staff
    }
    public class Constant
    {
        public const string Role_Customer = "Customer";
        public const string Role_Staff = "Staff";

        public const int ERROR = 1;
        public const int SUCCESS = 0;

        public const string X = "X";
        public const string MINUS = "−";
        public const string PLUS = "+";
    }
    public class Utilities
    {
        public static String gUid
        {
            get
            {
                return Guid.NewGuid().ToString();
            }
        }
        // Return random number for OTP
        public static int code
        {
            get
            {
                Random r = new Random();
                return r.Next(100000, 999999);
            }
        }
        public static List<SelectListItem> ListRole
        {
            get
            {
                BaseRepository<role> role = new BaseRepository<role>();
                var list = new List<SelectListItem>();
                foreach (var item in role.GetAll())
                {
                    var r = new SelectListItem
                    {
                        Text = item.rolename,
                        Value = item.roleid.ToString()
                    };

                    list.Add(r);
                }

                return list;
            }
        }
    }