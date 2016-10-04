using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc_ikolotov
{
    public class Helper
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }

        //деление
        public int Divide(int x, int y)
        {
            //if (y == 0)
            //{
            //    return 0;
            //}

            return x / y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        //возведение в степень
        public int Pow(int x, int y)
        {
            var result = x;
            if (y == 0)
            {
                return result = 1;
            }
            else
            {
                if (y == 1)
                {
                    return result = x;
                }
            }

            for (int i = 1; i < y; i++)
            {
                result = result * x;
            }

            return result;
        }

        //subtraction вычитание
        public int Sub(int x, int y)
        {
            return x - y;
        }
    }
}
