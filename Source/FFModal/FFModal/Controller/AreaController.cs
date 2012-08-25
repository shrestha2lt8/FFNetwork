using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFModal.Controller
{
    public static class AreaController
    {
        /// <summary>
        /// Insert new record on TaxSetting tabel
        /// </summary>
        /// <param name="pTaxRate"></param>
        /// <returns></returns>
        public static bool Add(string pAreaCode,string pAreaName)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Area objArea = new FFModal.Area();
                objArea.AreaCode = pAreaCode;
                objArea.AreaDescription = pAreaName;
                context.Areas.AddObject(objArea);
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
        public static bool Edit(string pAreaCode, string pAreaName)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Area objArea = context.Areas.FirstOrDefault(x => x.AreaCode == pAreaCode);
                objArea.AreaCode = pAreaCode; ;
                objArea.AreaDescription = pAreaName;
                context.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// Get Area by area code
        /// </summary>
        /// <param name="pAreaCode"></param>
        /// <returns></returns>
        public static Area GetAreaByCode(string pAreaCode)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Area objArea = context.Areas.FirstOrDefault(x => x.AreaCode == pAreaCode);
                return objArea;
            }
        }

        /// <summary>
        /// Get Area by area name
        /// </summary>
        /// <param name="pAreaCode"></param>
        /// <returns></returns>
        public static Area GetAreaByName(string pAreaName)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Area objArea = context.Areas.FirstOrDefault(x => x.AreaDescription == pAreaName);
                return objArea;
            }
        }

        /// <summary>
        /// Delete Area by area code
        /// </summary>
        /// <param name="PAreaCode"></param>
        /// <returns></returns>
        public static bool Delete(string pAreaCode)
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                FFModal.Area objArea = context.Areas.FirstOrDefault(x => x.AreaCode == pAreaCode);
                if (objArea.Customers.Count > 0)
                    return false;
                else
                {
                    context.Areas.DeleteObject(objArea);
                    return true;
                }
            }
        }

        /// <summary>
        /// Get all areas
        /// </summary>
        /// <returns></returns>
        public static List<Area> GetAll()
        {
            using (NetworkEntities context = new NetworkEntities())
            {
                return context.Areas.ToList();
            }
        }
    }
}
