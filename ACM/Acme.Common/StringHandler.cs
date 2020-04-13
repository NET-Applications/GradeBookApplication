using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Common
{
    public static class StringHandler
    {
        #region public extension methods
        /// <summary>
        /// Inserts spaces before each capital letter in a string
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string InsertSpaces(this string source)
        {
            string result = string.Empty;
            if(!string.IsNullOrWhiteSpace(source))
            {
                foreach (char letter in source)
                {
                    if(char.IsUpper(letter))
                    {
                        // Trim any spaces if it is already there
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
            }
            return result.Trim();
        }
        #endregion public extension methods
    }
}
