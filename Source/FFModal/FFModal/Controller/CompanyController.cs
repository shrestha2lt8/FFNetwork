using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFModal.Controller
{
    public static class CompanyController
    {
        /// <summary>
        /// Insert new record on Company tabel
        /// </summary>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Add(string pName,string pAddress,string pRegistrationNumber,string pPanNumber,string pPhoneNumber ,string pFax ,string pEmail,string pWebsite, string pContactPerson)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Company objCompany = new FFModal.Company();
                objCompany.Name = pName;
                objCompany.Address = pAddress;
                objCompany.RegistrationNumber = pRegistrationNumber;
                objCompany.PanNumber = pPanNumber;
                objCompany.PhoneNumber = pPhoneNumber;
                objCompany.Fax = pFax;
                objCompany.Email = pEmail;
                objCompany.Website = pWebsite;
                objCompany.ContactPerson = pContactPerson;
                context.Companies.AddObject(objCompany);
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Edit record on Company table
        /// </summary>
        /// <param name="pTaxID"></param>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Edit(string pName, string pAddress, string pRegistrationNumber, string pPanNumber, string pPhoneNumber, string pFax, string pEmail, string pWebsite, string pContactPerson)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                if (context.Companies.Count() > 0)
                {
                    FFModal.Company objCompany = context.Companies.FirstOrDefault();
                    objCompany.Name = pName;
                    objCompany.Address = pAddress;
                    objCompany.RegistrationNumber = pRegistrationNumber;
                    objCompany.PanNumber = pPanNumber;
                    objCompany.PhoneNumber = pPhoneNumber;
                    objCompany.Fax = pFax;
                    objCompany.Email = pEmail;
                    objCompany.Website = pWebsite;
                    objCompany.ContactPerson = pContactPerson;
                    context.SaveChanges();
                }
                else
                {
                    Add(pName, pAddress, pRegistrationNumber, pPanNumber, pPhoneNumber, pFax, pEmail, pWebsite, pContactPerson);
                }
                return true;
            }
        }

        /// <summary>
        /// Get Company by ID
        /// </summary>
        /// <param name="pAreaCode"></param>
        /// <returns></returns>
        public static Company GetByID(int pCompanyID)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Company objCompany = context.Companies.FirstOrDefault(x => x.ID == pCompanyID);
                return objCompany;
            }
        }

        /// <summary>
        /// Get Company by ID
        /// </summary>
        /// <param name="pAreaCode"></param>
        /// <returns></returns>
        public static Company Get()
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Company objCompany = context.Companies.FirstOrDefault();
                return objCompany;
            }
        }

      
        /// <summary>
        /// Get all Company
        /// </summary>
        /// <returns></returns>
        public static List<Company> GetAll()
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.Companies .ToList();
            }
        }
    }
}
