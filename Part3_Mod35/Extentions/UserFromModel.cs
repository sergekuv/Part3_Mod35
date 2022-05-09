using Part3_Mod35.Models.Users;
using Part3_Mod35.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part3_Mod35.Extentions
{
    public static class UserFromModel
    {
        public static User Convert(this User user, UserEditViewModel usereditvm)
        {
            user.Image = usereditvm.Image;
            user.LastName = usereditvm.LastName;
            user.MiddleName = usereditvm.MiddleName;
            user.FirstName = usereditvm.FirstName;
            user.Email = usereditvm.Email;
            user.BirthDate = usereditvm.BirthDate;
            user.UserName = usereditvm.UserName;
            user.Status = usereditvm.Status;
            user.About = usereditvm.About;

            return user;
        }
    }
}
