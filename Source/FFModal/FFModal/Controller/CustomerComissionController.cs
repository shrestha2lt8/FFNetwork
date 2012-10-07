
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFModal.Controller
{
    public static class CustomerComissionController
    {

        /// <summary>
        /// Insert new record on CustomerComission tabel
        /// </summary>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Add(string pMembershipID,string pOrderID,decimal pAmount,DateTime? pComissionPaidDate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.CustomerComission objComission = new FFModal.CustomerComission();
                objComission.MembershipID = pMembershipID;
                objComission.OrderID = pOrderID;
                objComission.Amount = pAmount;
                objComission.ComissionPaidDate = pComissionPaidDate;
                objComission.IsComissionPaid = false;
                context.CustomerComissions.AddObject(objComission);
                context.SaveChanges();
                return true;
            }
        }


        /// <summary>
        /// Edit record on CustomerComission table
        /// </summary>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Edit(string pMembershipID,string pOrderID,decimal pAmount,bool pIsPaid, DateTime? pComissionPaidDate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.CustomerComission objComission = context.CustomerComissions.FirstOrDefault(x=>x.MembershipID==pMembershipID && x.OrderID==pOrderID);
                if (objComission != null)
                {
                    objComission.MembershipID = pMembershipID;
                    objComission.OrderID = pOrderID;
                    objComission.Amount = pAmount;
                    objComission.IsComissionPaid = pIsPaid;
                    objComission.ComissionPaidDate = pComissionPaidDate;
                    context.SaveChanges();
                }
                else
                {
                    Add(pMembershipID, pOrderID, pAmount, pComissionPaidDate);
                }
            }
            return true;
        }


        /// <summary>
        /// Delete CustomerComission by order id 
        /// </summary>
        /// <param name="PAreaCode"></param>
        /// <returns></returns>
        public static bool Delete(string pOrderId)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                var query = from c in context.CustomerComissions where c.OrderID==pOrderId select c;
                foreach(CustomerComission obj in query)
                {
                    context.CustomerComissions.DeleteObject(obj);
                }
                context.SaveChanges();
                return true;
            }
        }


        /// <summary>
        /// Get Comission setting
        /// </summary>
        /// <returns></returns>
        public static ComissionSetting GetComission()
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.ComissionSettings.FirstOrDefault();
            }
        }
    }
}
