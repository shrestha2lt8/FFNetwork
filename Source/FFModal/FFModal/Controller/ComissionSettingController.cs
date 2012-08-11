using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFModal.Controller
{
    public static class ComissionSettingController
    {

        /// <summary>
        /// Insert new record on ComissionSetting tabel
        /// </summary>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Add(Int32 pMaxLevel,Int32 pMaxNode,decimal pPercetage)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.ComissionSetting objComission = new FFModal.ComissionSetting();
                objComission.MaxLevel = pMaxLevel;
                objComission.MaxNode=pMaxNode;
                objComission.ComissionPercentage = pPercetage;
                context.ComissionSettings.AddObject(objComission);
                context.SaveChanges();
                return true;
            }
        }


        /// <summary>
        /// Edit record on TaxSetting table
        /// </summary>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Edit(Int32 pMaxLevel, Int32 pMaxNode, decimal pPercetage)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.ComissionSetting objComission = context.ComissionSettings.FirstOrDefault();
                if (objComission != null)
                {
                    objComission.MaxLevel = pMaxLevel;
                    objComission.MaxNode = pMaxNode;
                    objComission.ComissionPercentage = pPercetage;
                    context.SaveChanges();
                }
                else
                {
                    Add(pMaxLevel,pMaxNode,pPercetage);
                }
            }
            return true;
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
