using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFModal.Controller
{
   public class UserController
    {

       /// <summary>
       /// Get user by username and password
       /// </summary>
       /// <param name="pUserName"></param>
       /// <param name="pPassword"></param>
       /// <returns></returns>
        public static User GetUser(string pUserName,string pPassword )
        {
            using (NetworkEntities context = new NetworkEntities())
            {
               var query= from c in context.Users where c.UserName==pUserName && c.Password==pPassword select c;
               return query.ToList().SingleOrDefault();
            }
        }

       /// <summary>
       /// Changing password
       /// </summary>
       /// <param name="pUserName"></param>
       /// <param name="pNewPassword"></param>
       /// <returns></returns>
       public static bool ChangePassword(string pUserName,string pNewPassword)
       {
           using (NetworkEntities context = new NetworkEntities())
           {
               FFModal.User objUser = context.Users.FirstOrDefault(x => x.UserName == pUserName);
               if (objUser != null)
               {
                   objUser.Password=pNewPassword;
                   context.SaveChanges();
                   return true;
               }
               else
               {
                  return false;
               }
           }
       }

    }
}
