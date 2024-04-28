using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyInventories.Models
{
    public class UserLogged
    {
        public useraccount UserAccount { get; set; }
        public userinformation UserInformation { get; set; }
    }
}