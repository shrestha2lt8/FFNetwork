using System;
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
    }

    /// <summary>
    /// Enum type for lookup
    /// </summary>
     public enum LookupType
      {
          Area,
          Customer,
          Product     
      }

}
