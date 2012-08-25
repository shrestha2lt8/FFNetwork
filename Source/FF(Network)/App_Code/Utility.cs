using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FFNetwork
{
  public static  class Utility
    {
        public static bool IsNumber(string pNumber )
        {
            int Num;
            bool isNum = int.TryParse(pNumber, out Num);
            return isNum;
        }

        public static bool IsDecimal(string pNumber)
        {
            decimal Num;
            bool isNum = decimal.TryParse(pNumber, out Num);
            return isNum;
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
