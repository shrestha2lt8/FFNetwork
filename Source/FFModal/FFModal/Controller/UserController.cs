using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFModal.Controller
{
   public class UserController
    {
        /// <summary>
        /// Get Tax setting 
        /// </summary>
        /// <param name="pMembershipId"></param>
        /// <returns></returns>
        public static User GetUser(string pUserName,string pPassword )
        {
            using (NetworkEntities context = new NetworkEntities())
            {
               var query= from c in context.Users where c.UserName==pUserName && c.Password==pPassword select c;
               return query.ToList().SingleOrDefault();
            }
        }
    }
}
