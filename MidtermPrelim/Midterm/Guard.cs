using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Midterm
{
    public static class Guard
    {
        public static void IsNullOrEmpty(string input, string paramName)
        {
            if(input == null) throw new ArgumentNullException(paramName);

            if(string.IsNullOrEmpty(input)) throw new ArgumentException(paramName);
        }

    }
}
