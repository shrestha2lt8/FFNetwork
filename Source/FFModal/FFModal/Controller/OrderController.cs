﻿using System;
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
            OrderDate = 0,
            DeliveryDate
        }

        public enum LogicalOperator
        {
            AND = 0,
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
        public static bool Add(string pOrderId,string pMemberID, decimal pAmount, string pDescription, string pRemarks, DateTime pOrderDate, bool pIsDelivered, bool pIsPaid, DateTime? pDeliveredDate,DateTime? pPaidDate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                Order objOder = new Order();
                objOder.OrderID = pOrderId;
                objOder.MembershipID = pMemberID;
                objOder.OrderDate = Convert.ToDateTime(pOrderDate);
                objOder.Amount = pAmount;
                objOder.IsDelivered = false;
                objOder.Description = pDescription;
                objOder.Remarks = pRemarks;
                objOder.IsDelivered = pIsDelivered;
                objOder.DeliveredDate = pDeliveredDate;
                objOder.IsPaid = pIsPaid;
                objOder.PaidDate = pPaidDate;
                
                context.Orders.AddObject(objOder);
                int status = context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <returns></returns>
        public static List<Order> GetAll()
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.Orders.ToList();
            }
        }

        /// <summary>
        /// Get Order by Order Id
        /// </summary>
        /// <param name="pID"></param>
        /// <returns></returns>
        public static Order GetByID(string pID)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.Orders.FirstOrDefault(x => x.OrderID == pID);
            }
        }

        public static List<Order> Search(string pOrderID, string pOrderDate, string pMemberID)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                List<Order> lstOrder = new List<Order>();

                //string expression = "( from o in context.Orders ";

                //if (!string.IsNullOrEmpty(pOrderID))
                //    expression = " where o.OrderID.Equals(Convert.ToInt32(pOrderID)) ";
                //if (!string.IsNullOrEmpty(pOrderDate))
                //{
                //    if (!string.IsNullOrEmpty(expression))
                //    {
                //        expression += " && o.OrderDate.Equals(Convert.ToDateTime(pOrderDate)) ";
                //    }
                //    else
                //    {
                //        expression += " where o.OrderDate.Equals(Convert.ToDateTime(pOrderDate)) ";
                //    }
                //}
                //if (!string.IsNullOrEmpty(pMemberID))
                //{
                //    if (!string.IsNullOrEmpty(expression))
                //        expression += " && o.MembershipID.Equals(pMemberID) ";
                //    else
                //        expression = " where o.MembershipID.Equals(pMemberID) ";
                //}

                //expression += " select o).ToList() ";

                int orderID = string.IsNullOrEmpty(pOrderID) ? 0 : Convert.ToInt32(pOrderID);
                DateTime? orderDate = null;

                string[] arr = pOrderDate.Split('/');

                if (string.IsNullOrWhiteSpace(arr[0]) || string.IsNullOrWhiteSpace(arr[1]) || string.IsNullOrWhiteSpace(arr[2]))
                {
                    orderDate = null;
                }
                else
                {
                    orderDate = Convert.ToDateTime(pOrderDate);
                }

              //  lstOrder = (from o in context.Orders where o.OrderID >= orderID || o.OrderDate.Equals(orderDate) || o.MembershipID.Equals(pMemberID) select o).ToList();
                return lstOrder;
            }
        }

        /// <summary>
        /// Edit record on Order table
        /// </summary>
        /// <param name="pOrderID"></param>
        /// <param name="pTaxRatpTaxIDe"></param>
        /// <returns></returns>
        public static bool Edit(string pOrderID,string pMemberID, decimal pAmount, string pDescription, string pRemarks, DateTime pOrderDate, bool pIsDelivered, bool pIsPaid, DateTime? pDeliveredDate,DateTime? pPaidDate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {

                Order objOrder = context.Orders.FirstOrDefault(x => x.OrderID == pOrderID);
               
                objOrder.MembershipID = pMemberID;
                objOrder.OrderDate = pOrderDate;
                objOrder.Amount = pAmount;
                objOrder.Description = pDescription;
                objOrder.Remarks = pRemarks;
                objOrder.OrderDate = pOrderDate;
                objOrder.IsDelivered = pIsDelivered;
                objOrder.DeliveredDate = pDeliveredDate;
                objOrder.IsPaid = pIsPaid;
                objOrder.PaidDate = pPaidDate;

                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Delete Area by area code
        /// </summary>
        /// <param name="PAreaCode"></param>
        /// <returns></returns>
        public static bool Delete(string pOrderID)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Order objOrder = context.Orders.FirstOrDefault(x => x.OrderID == pOrderID);
                if (objOrder == null)
                    return false;
                else
                {
                    context.Orders.DeleteObject(objOrder);
                    context.SaveChanges();
                    return true;
                }
            }
        }
    }
}
