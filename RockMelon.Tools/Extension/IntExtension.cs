using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RockMelon.Tools.Extension
{
    public static class IntExtension
    {
        /// <summary>
        /// Parses any object and handles all errors 
        /// </summary>
        /// <param name="intValue"></param>
        /// <param name="defaultValue">this is the value returned if intvalue does not parse as valid int</param>
        /// <returns>devault value passed</returns>
        public static int ToInt32(this object intValue, int defaultValue)
        {
            try
            {
                int iValue;
                if (int.TryParse(intValue.ToString(), out iValue))
                {
                    return iValue;
                }
                return defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static bool IsPositive(this object intValue)
        {
            return intValue.ToInt32(0) > 0;
        }

        public static bool IsNegative(this object intValue)
        {
            return intValue.ToInt32(0) < 0;
        }

        public static int Add(this object intvalue, int addValue)
        {
            return intvalue.ToInt32(0) + addValue;
        }

        public static int Round(this double dValue)
        {
            if (dValue != null)
            {
                return Math.Round(dValue).ToInt32(0);
            }
            return 0;
        }

        public static int Round(this float fValue)
        {
            if (fValue != null)
            {
                return Math.Round(fValue).ToInt32(0);
            }
            return 0;
        }

        public static int Round(this object value)
        {
            //other then foat, decimal or double
            return 0;
        }

        public static int Round(this decimal dValue)
        {
            if (dValue != null)
            {
                return (int) Math.Round(dValue);
            }
            return 0;
        }

        public static int Increment(this object iValue)
        {
            try
            {
                var iv = (int)iValue;
                return ++iv;
            }
            catch
            {
                return 1;
            }
        }

        public static int Decrement(this object iValue)
        {
            try
            {
                var iv = (int)iValue;
                return --iv;
            }
            catch
            {
                return -1;
            }
        }

        public delegate int Equation(int k);
        private static Dictionary<Tuple<Func<int, int>, int>, int> lambdaHistory = new Dictionary<Tuple<Func<int, int>, int>, int>(); 
        public static int CalculateLambdaWithMemory(this int i, Func<int, int> expression)
        {
            int lookup;
            var key = new Tuple<Func<int, int>, int>(expression, i);
            if (lambdaHistory.TryGetValue(key, out lookup))
            {
                return lookup;
            }
            Equation equation = expression.Invoke;// expression;
            var a = equation(i);
            lambdaHistory[key] = a;
            return a;
        }

        public delegate long EquationLong(int k);
        private static Dictionary<Tuple<EquationLong, int>, long> history = new Dictionary<Tuple<EquationLong, int>, long>();
        public static long CalculateWithMemory(this int i, EquationLong action)
        {
            long lookup;
            var key = new Tuple<EquationLong, int>(action, i);
            if (history.TryGetValue(key, out lookup))
            {
                Console.WriteLine("{0} Found in lookup..........", lookup);
                return lookup;
            }
            EquationLong equation = action.Invoke;
            var a = equation(i);
            history[key] = a;
            Console.WriteLine("{0} Calculated........", a);
            return a;
        }
    }
}
