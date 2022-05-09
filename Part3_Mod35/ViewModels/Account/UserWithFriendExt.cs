using Part3_Mod35.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part3_Mod35.ViewModels.Account
{
    public class UserWithFriendExt: User
    {
        public bool IsFriendWithCurrent { get; set; }
    }
}
