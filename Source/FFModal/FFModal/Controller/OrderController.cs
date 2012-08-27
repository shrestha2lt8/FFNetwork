using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FFModal;

namespace FFModal.Controller
{
    public static class OrderController
    {

        public enum DateType
	    {
	        OrderDate =0,
            DeliveryDate
	    }

        public enum LogicalOperator
	    {
	        AND =0,
            OR
	    }
                
        /// <summary>
        /// Insert new record on Order tabel
        /// </summary>
        /// <param name="pMemberID">String</param>
        /// <param name="pAmount">Decimal</param>
        /// <param name="pDescription">String</param>
        /// <param name="pRemarks">Remarks</param>
        /// <returns></returns>
        public static bool Add(string pMemberID,decimal pAmount,string pDescription, string pRemarks)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                Order objOder = new Order();
                
                objOder.MembershipID = pMemberID;
                objOder.OrderDate = DateTime.Now;
                objOder.Amount = pAmount;
                objOder.IsDelivered = false;
                objOder.Description = pDescription;
                objOder.Remarks = pRemarks;
                //objOder.DeliveredDate = null;

                context.Orders.AddObject(objOder);
                int status = context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Order> GetAll()
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.Orders;
            }
        }

        //public static IEnumerable<Order> Search(string pMemberID, DateTime pStartDate, DateTime pEndDate, DateType pDateType, LogicalOperator pLogicCase)
        //{
        //    using (NetworkEntities context = new NetworkEntities())
        //    {
        //        //IEnumerable<Order> lstOrder = context.Orders.SelectMany(x => x.MembershipID == pMemberID,IEnumerable<Order>,);
        //    }
        //}
    }
}
