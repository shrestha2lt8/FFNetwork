using System;
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
      /// <returns></returns>
       public static bool Add(String pMembershipID,String pIntroducerID,String pReferenceID,String pCustomerName,String pBenificiaryName,String pGender,DateTime pDateOfBirth,DateTime pCreatedDate,Int32 pCreatedBy,String pMaratialStatus,String pNationality,String  pCitizenshipID,String  pLicenseID,String pPassportID,String pCountry,String pCity,String pMunicipality,String pDistrict, String pStreet,String pHomeNumber,String pAreaCode,String pAddress,String pHomeTelephone,String pMobile,String pEmailAddress,Byte[] pPhoto)
       {
           using (NetworkEntities context = new NetworkEntities())
           {
               FFModal.Customer objCustomer = new FFModal.Customer();
                        objCustomer.MembershipID = pMembershipID;
                        objCustomer.IntroducerID=pIntroducerID;
                        objCustomer.ReferenceID=pReferenceID;
                        objCustomer.CustomerName=pCustomerName;
                        objCustomer.BenificiaryName=pBenificiaryName;
                        objCustomer.Gender=pGender;
                        objCustomer.DateOfBirth  =pDateOfBirth;
                        objCustomer.CreatedDate=pCreatedDate; 
                        objCustomer.MaratialStatus=pMaratialStatus;
                        objCustomer.Nationality  =pNationality;
                        objCustomer.CitizenshipID=pCitizenshipID;
                        objCustomer.LicenseID=pLicenseID;
                        objCustomer.PassportID=pPassportID;
                        objCustomer.Country=pCountry;
                        objCustomer.City=pCity;
                        objCustomer.Municipality=pMunicipality;
                        objCustomer.District=pDistrict;
                        objCustomer.Street=pStreet;
                        objCustomer.HomeNumber=pHomeNumber;
                        objCustomer.AreaCode=pAreaCode;
                        objCustomer.Address=pAddress;
                        objCustomer.HomeTelephone=pHomeTelephone;
                        objCustomer.Mobile=pMobile;
                        objCustomer.EmailAddress=pEmailAddress;
                        objCustomer.Photo=pPhoto;
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
      /// <returns></returns>
       public static bool Edit(String pMembershipID,String pIntroducerID,String pReferenceID,String pCustomerName,String pBenificiaryName,String pGender,DateTime pDateOfBirth,DateTime pCreatedDate,Int32 pCreatedBy,String pMaratialStatus,String pNationality,String  pCitizenshipID,String  pLicenseID,String pPassportID,String pCountry,String pCity,String pMunicipality,String pDistrict, String pStreet,String pHomeNumber,String pAreaCode,String pAddress,String pHomeTelephone,String pMobile,String pEmailAddress,Byte[] pPhoto)
       {
           using (NetworkEntities context = new NetworkEntities())
           {
               FFModal.Customer objCustomer =context.Customers.FirstOrDefault(x=>x.MembershipID==pMembershipID);
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
      /// Get All customers from database
      /// </summary>
      /// <param name="pMembershipId"></param>
      /// <returns></returns>
       public static List<Customer> GetAll(String pMembershipId)
       {
           using (NetworkEntities context = new NetworkEntities())
           {
               return context.Customers.ToList();
           }
       }
   }
}

