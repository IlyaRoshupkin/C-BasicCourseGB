using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace hw1Task6
{
    static class UsefulMethods
    {
        public static void SquareEqualSol(double a, double b, double c, out double x1, out double x2)
        {
            if (a == 0)
            {
                x1 = -c / b;
                x2 = Double.NaN;
            }
            else
            {
                double D = b * b - 4 * a * c;
                if (D == 0)
                {
                    x1 = -b / (2 * a);
                    x2 = Double.NaN;
                }
                else if (D > 0)
                {
                    x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    x2 = (-b - Math.Sqrt(D)) / (2 * a);
                }
                else
                {
                    x1 = x2 = Double.NaN;
                }
            }
        }

        internal static string GeneratePassword(int length)
        {
            Random rnd = new Random();
            string password = "";
            for (int i = 0; i < length; i++)
            {
                int n = rnd.Next(0, 4);
                char[] spec_chars = { '!', '@', '?', '#', '$', '%', '&' };

                switch (n)
                {
                    case 0:
                        {
                            password += rnd.Next(10);
                            break;
                        }
                    case 1:
                        {
                            password += Convert.ToChar(rnd.Next(65, 88));
                            break;
                        }
                    case 2:
                        {
                            password += Convert.ToChar(rnd.Next(97, 122));
                            break;
                        }
                    default:
                        {
                            password += spec_chars[rnd.Next(spec_chars.Length)];
                            break;
                        }
                }
            }
            return password;
        }
    }
}
