﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace FFModal.Controller
{
    public static class CustomerController
    {

        /// <summary>
        /// Insert Customer on database
        /// </summary>
        /// <param name="pMembershipID"></param>
        /// <param name="pIntroducerID"></param>
        /// <param name="pReferenceID"></param>
        /// <param name="pCustomerName"></param>
        /// <param name="pBenificiaryName"></param>
        /// <param name="pGender"></param>
        /// <param name="pDateOfBirth"></param>
        /// <param name="pCreatedDate"></param>
        /// <param name="pCreatedBy"></param>
        /// <param name="pMaratialStatus"></param>
        /// <param name="pNationality"></param>
        /// <param name="pCitizenshipID"></param>
        /// <param name="pLicenseID"></param>
        /// <param name="pPassportID"></param>
        /// <param name="pCountry"></param>
        /// <param name="pCity"></param>
        /// <param name="pMunicipality"></param>
        /// <param name="pDistrict"></param>
        /// <param name="pStreet"></param>
        /// <param name="pHomeNumber"></param>
        /// <param name="pAreaCode"></param>
        /// <param name="pAddress"></param>
        /// <param name="pHomeTelephone"></param>
        /// <param name="pMobile"></param>
        /// <param name="pEmailAddress"></param>
        /// <param name="pPhoto"></param>
        /// <param name="pCustomerTypeID"></param>
        /// <param name="pMROrientationDate"></param>
 
        /// <returns></returns>
        public static bool Add(String pMembershipID, String pIntroducerID, String pReferenceID, String pCustomerName, 
            String pBenificiaryName, String pGender, DateTime? pDateOfBirth, DateTime? pCreatedDate, Int32 pCreatedBy,
            String pMaratialStatus, String pNationality, String pCitizenshipID, String pLicenseID, String pPassportID, 
            String pCountry, String pCity, String pMunicipality, String pDistrict, String pStreet, String pHomeNumber,
            String pAreaCode, String pAddress, String pHomeTelephone, String pMobile, String pEmailAddress, byte[] pPhoto, Int32 pCustomerTypeID, DateTime? pMROrientationDate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Customer objCustomer = new FFModal.Customer();
                objCustomer.MembershipID = pMembershipID;
                objCustomer.IntroducerID = pIntroducerID;
                objCustomer.ReferenceID = pReferenceID;
                objCustomer.CustomerName = pCustomerName;
                objCustomer.BenificiaryName = pBenificiaryName;
                objCustomer.Gender = pGender;
                objCustomer.DateOfBirth = pDateOfBirth;
                objCustomer.CreatedDate = DateTime.Now;
                objCustomer.MaratialStatus = pMaratialStatus;
                objCustomer.Nationality = pNationality;
                objCustomer.CitizenshipID = pCitizenshipID;
                objCustomer.LicenseID = pLicenseID;
                objCustomer.PassportID = pPassportID;
                objCustomer.Country = pCountry;
                objCustomer.City = pCity;
                objCustomer.Municipality = pMunicipality;
                objCustomer.District = pDistrict;
                objCustomer.Street = pStreet;
                objCustomer.HomeNumber = pHomeNumber;
                objCustomer.AreaCode = pAreaCode;
                objCustomer.Address = pAddress;
                objCustomer.HomeTelephone = pHomeTelephone;
                objCustomer.Mobile = pMobile;
                objCustomer.EmailAddress = pEmailAddress;
                if (pPhoto != null)
                {
                    objCustomer.Photo =pPhoto;
                }
                objCustomer.CreatedBy = pCreatedBy;
                objCustomer.CustomerTypeID = pCustomerTypeID;
                objCustomer.MROrientationDate = pMROrientationDate;
                context.Customers.AddObject(objCustomer);
                context.SaveChanges();
            }
            return true;
        }

        /// <summary>
        /// Edit customer on database
        /// </summary>
        /// <param name="pMembershipID"></param>
        /// <param name="pIntroducerID"></param>
        /// <param name="pReferenceID"></param>
        /// <param name="pCustomerName"></param>
        /// <param name="pBenificiaryName"></param>
        /// <param name="pGender"></param>
        /// <param name="pDateOfBirth"></param>
        /// <param name="pCreatedDate"></param>
        /// <param name="pCreatedBy"></param>
        /// <param name="pMaratialStatus"></param>
        /// <param name="pNationality"></param>
        /// <param name="pCitizenshipID"></param>
        /// <param name="pLicenseID"></param>
        /// <param name="pPassportID"></param>
        /// <param name="pCountry"></param>
        /// <param name="pCity"></param>
        /// <param name="pMunicipality"></param>
        /// <param name="pDistrict"></param>
        /// <param name="pStreet"></param>
        /// <param name="pHomeNumber"></param>
        /// <param name="pAreaCode"></param>
        /// <param name="pAddress"></param>
        /// <param name="pHomeTelephone"></param>
        /// <param name="pMobile"></param>
        /// <param name="pEmailAddress"></param>
        /// <param name="pPhoto"></param>
        /// <param name="pCustomerRypeID"></param>
        /// <param name="pMROrientationDate"></param>
        /// <returns></returns>
        public static bool Edit(String pMembershipID, String pIntroducerID, String pReferenceID, String pCustomerName, 
            String pBenificiaryName, String pGender, DateTime? pDateOfBirth, DateTime? pCreatedDate, Int32 pCreatedBy,
            String pMaratialStatus, String pNationality, String pCitizenshipID, String pLicenseID, String pPassportID, 
            String pCountry, String pCity, String pMunicipality, String pDistrict, String pStreet, String pHomeNumber,
            String pAreaCode, String pAddress, String pHomeTelephone, String pMobile, String pEmailAddress, byte[] pPhoto, Int32 pCustomerTypeID, DateTime? pMROrientationDate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Customer objCustomer = context.Customers.FirstOrDefault(x => x.MembershipID == pMembershipID);
                if (objCustomer != null)
                {
                    objCustomer.MembershipID = pMembershipID;
                    objCustomer.IntroducerID = pIntroducerID;
                    objCustomer.ReferenceID = pReferenceID;
                    objCustomer.CustomerName = pCustomerName;
                    objCustomer.BenificiaryName = pBenificiaryName;
                    objCustomer.Gender = pGender;
                    objCustomer.DateOfBirth = pDateOfBirth;
                    objCustomer.CreatedDate = pCreatedDate;
                    objCustomer.MaratialStatus = pMaratialStatus;
                    objCustomer.Nationality = pNationality;
                    objCustomer.CitizenshipID = pCitizenshipID;
                    objCustomer.LicenseID = pLicenseID;
                    objCustomer.PassportID = pPassportID;
                    objCustomer.Country = pCountry;
                    objCustomer.City = pCity;
                    objCustomer.Municipality = pMunicipality;
                    objCustomer.District = pDistrict;
                    objCustomer.Street = pStreet;
                    objCustomer.HomeNumber = pHomeNumber;
                    objCustomer.AreaCode = pAreaCode;
                    objCustomer.Address = pAddress;
                    objCustomer.HomeTelephone = pHomeTelephone;
                    objCustomer.Mobile = pMobile;
                    objCustomer.EmailAddress = pEmailAddress;
                    objCustomer.Photo = pPhoto;
                    objCustomer.CreatedBy = 1;
                    objCustomer.CustomerTypeID = pCustomerTypeID;
                    objCustomer.MROrientationDate = pMROrientationDate;
                    context.SaveChanges();
                }
            }
            return true;
        }

        /// <summary>
        /// Delete customer from databaes
        /// </summary>
        /// <param name="pMembershipID"></param>
        /// <returns></returns>
        public static bool Delete(String pMembershipID)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Customer objCustomer = context.Customers.FirstOrDefault(x => x.MembershipID == pMembershipID);
                if (objCustomer != null)
                {
                    context.Customers.DeleteObject(objCustomer);
                    context.SaveChanges();
                }
            }
            return true;
        }

        /// <summary>
        /// Get Customer by Membership id
        /// </summary>
        /// <param name="pMembershipId"></param>
        /// <returns></returns>
        public static Customer GetCustomer(String pMembershipId)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.Customers.SingleOrDefault(x => x.MembershipID == pMembershipId);
            }
        }

        /// <summary>
        /// Get Customer by Membership id
        /// </summary>
        /// <param name="pMembershipId"></param>
        /// <returns></returns>
        public static Customer GetCustomer(String pMembershipId,out int pOrderCount)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
 
               Customer objCustomer= context.Customers.SingleOrDefault(x => x.MembershipID == pMembershipId);
               pOrderCount = objCustomer.Orders.Count;
               return objCustomer;

            }
        }

        /// <summary>
        /// Get All customers from database
        /// </summary>
        /// <param name="pMembershipId"></param>
        /// <returns></returns>
        public static List<Customer> GetAll()
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.Customers.ToList();
            }
        }

        /// <summary>
        /// Get next membership id
        /// </summary>
        /// <param name="pAreaCode"></param>
        /// <returns></returns>
        public static string GetNextMembershipId(string pAreaCode)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                double rec = 1;
                var query = from c in context.Customers where c.MembershipID.StartsWith(pAreaCode) select c;

                List<FFModal.Customer> lstCustomers = query.ToList();
                if (lstCustomers.Count>0)
                {
                    return pAreaCode + "-" +  (Convert.ToInt32(lstCustomers[lstCustomers.Count - 1].MembershipID.Replace(pAreaCode + "-", "")) + 1).ToString("00000");
                }
                else
                {
                    return pAreaCode + "-" + rec.ToString("00000"); 
                }
            }
        }

        /// <summary>
        /// Check given membershipid is valid or not
        /// </summary>
        /// <param name="pMembershipID"></param>
        /// <returns></returns>
        public static bool IsValidReferenceMemberID(string pMembershipID)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                var query = from c in context.Customers where c.ReferenceID==pMembershipID select c;
                int MaxNode = context.ComissionSettings.ToList()[0].MaxNode;
                if (MaxNode <= query.ToList().Count)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static List<CustomerType> GetCustomerType()
        {

            using (NetworkEntities context = new NetworkEntities())
            {
                return context.CustomerTypes.ToList();
            }

        }

    }
}

