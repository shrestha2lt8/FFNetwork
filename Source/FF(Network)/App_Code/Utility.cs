﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace FFNetwork
{
  public static  class Utility
    {
        public static Int32 AdminUserId;
        public static string AdminUserName;

      /// <summary>
      /// Checks given string is number or not 
      /// </summary>
      /// <param name="pNumber"></param>
      /// <returns></returns>
        public static bool IsNumber(string pNumber )
        {
            int Num;
            bool isNum = int.TryParse(pNumber, out Num);
            return isNum;
        }

      /// <summary>
        /// Checks given string is decimal or not 
      /// </summary>
      /// <param name="pNumber"></param>
      /// <returns></returns>
        public static bool IsDecimal(string pNumber)
        {
            decimal Num;
            bool isNum = decimal.TryParse(pNumber, out Num);
            return isNum;
        }

      /// <summary>
      /// Converting image to byte
      /// </summary>
      /// <param name="pFilePath"></param>
      /// <returns></returns>
        public static byte[] GetPhotoByte(string pFilePath)
        {
            if (pFilePath != "")
            {
                Image img = Image.FromFile(pFilePath);
                MemoryStream tmpStream = new MemoryStream();
                img.Save(tmpStream, ImageFormat.Png); // change to other format
                return tmpStream.ToArray();
            }
            else
                return null;
        }

      /// <summary>
      /// Converting byte to image
      /// </summary>
      /// <param name="pPhoto"></param>
      /// <returns></returns>
        public static Image GetPhotoFromByte(byte[] pPhoto)
        {
            Image image = Image.FromStream(new System.IO.MemoryStream(pPhoto));
            return image;
        }

      /// <summary>
      /// Converts string (dd/MM/yyyy) to date
      /// </summary>
      /// <param name="pDate"></param>
      /// <returns></returns>
        public static DateTime? GetConvertedDate(String pDate)
        {
            DateTime? dt;
            if (pDate.Trim() == "/  /")
                return null;
            else
            {
                try
                {
                    string[] dateArray = pDate.Split('/');
                    if (dateArray.Length != 3)
                        return null;
                    else
                    {
                        try
                        {
                            dt = new DateTime(Convert.ToInt32(dateArray[2]), Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[0]));
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            return null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Converts string (dd/MM/yyyy) to date
        /// </summary>
        /// <param name="pDate"></param>
        /// <returns></returns>
        public static DateTime GetDate(String pDate)
        {
                    string[] dateArray = pDate.Split('/');
                    if (dateArray.Length != 3)
                        throw new Exception("Invalid format of date");
                    else
                    {
                        try
                        {
                          DateTime  dt = new DateTime(Convert.ToInt32(dateArray[2]), Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[0]));
                            return dt;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }

        }

      /// <summary>
      /// Checks given string(dd/MM/yyyy) is correct date or not
      /// </summary>
      /// <param name="pDate"></param>
      /// <returns></returns>
        public static bool IsValidDate(string pDate)
        {
            if (pDate.Trim() == "/  /")
                return true;
            else
            {
                string[] dateArray = pDate.Split('/');
                if (dateArray.Length != 3)
                    return false;
                else
                {
                    try
                    {
                        DateTime dt= new DateTime(Convert.ToInt32(dateArray[2]), Convert.ToInt32(dateArray[1]), Convert.ToInt32(dateArray[0]));
                        return true;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }
                }
            }
        }
    }

    /// <summary>
    /// Enum type for lookup
    /// </summary>
     public enum LookupType
      {
          Area,
          Customer,
          Product,
          Order
      }


}
