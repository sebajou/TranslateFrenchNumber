using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToChar
{
    public static class IntExtensions
    {
        public static string Reverse(this int integer)
        {
            char[] charArray = integer.ToString().ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
