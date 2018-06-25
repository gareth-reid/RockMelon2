using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockMelon.Tools.Extension
{
    public static class BoolExtension
    {
        /// <summary>
        /// Parses any object and handles all errors 
        /// </summary>
        /// <param name="boolValue"></param>
        /// <returns>value parsed</returns>
        public static bool ToBool(this object boolValue)
        {
            try
            {
                if (Equals(boolValue, "1")) 
                    return true;
                if (Equals(boolValue, "Y"))
                    return true;
                return Convert.ToBoolean(boolValue);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Converts a bool to a Y or N string
        /// </summary>
        /// <param name="boolValue"></param>
        /// <returns></returns>
        public static string ToYesNo(this object boolValue)
        {
            try
            {
                return bool.Parse(boolValue.ToString()) ? "Y" : "N";
            }
            catch
            {
                return "N";
            }
        }
    }
}
