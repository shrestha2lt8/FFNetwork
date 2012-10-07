using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFModal.Controller
{
    public static class TaxController
    {

        /// <summary>
        /// Insert new record on TaxSetting tabel
        /// </summary>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Add(Int32 pTaxRate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.TaxSetting objTax = new FFModal.TaxSetting();
                objTax.TaxRate = pTaxRate;
                context.TaxSettings.AddObject(objTax);
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Edit record on TaxSetting table
        /// </summary>
        /// <param name="pTaxID"></param>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Edit(Int32 pTaxID,Int32 pTaxRate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.TaxSetting objTax = context.TaxSettings.FirstOrDefault(x => x.TaxID == pTaxID);
                objTax.TaxRate = pTaxRate;
                context.SaveChanges();
                return true;
            }
        }

        /// <summary>
        /// Edit record on TaxSetting table
        /// </summary>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Edit(Int32 pTaxRate)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.TaxSetting objTax = context.TaxSettings.FirstOrDefault();
                if (objTax != null)
                {
                    objTax.TaxRate = pTaxRate;
                    context.SaveChanges();
                }
                else
                {
                    Add(pTaxRate);
                }
            }
            return true;
        }

        /// <summary>
        /// Get Tax setting 
        /// </summary>
        /// <param name="pMembershipId"></param>
        /// <returns></returns>
        public static TaxSetting GetTaxSetting()
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.TaxSettings.SingleOrDefault();
            }
        }
    }
}
