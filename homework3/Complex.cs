using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw3task1
{
    struct Complex
    {
        double im { get; set; }
        double re { get; set; }

        public Complex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }

        internal static void Demonsration()
        {
            bool work = true;
            Complex[] complexNums = GetComplexNumbers();
            int choise;
            while(work)
            {
                Console.Write("Выберете необходимое:\n" +
                    "1 - Сложение комплексных чисел\n" +
                    "2 - Вычитание комплексных чисел\n" +
                    "3 - Умножение комплексных чисел\n" +
                    "4 - Начать заново\n" +
                    "0 - Выход\n");
                bool bChoise;
                do
                {
                    bChoise = int.TryParse(Console.ReadLine(), out choise);
                } while (!bChoise || choise < 0 || choise > 4);
                switch (choise)
                {
                    case 1:
                        Addition(complexNums);
                        break;
                    case 2:
                        Subtraction(complexNums);
                        break;
                    case 3:
                        Multiplication(complexNums);
                        break;
                    case 4:
                        Console.Clear();
                        complexNums = GetComplexNumbers();
                        break;
                    case 0:
                        Console.WriteLine("Программа завершила свою работу.");
                        work = false;
                        break;
                } 
            } 
        }

        private static Complex[] GetComplexNumbers()
        {
            Console.WriteLine("Введите два комплексных числа:\nПервое число:");
            Complex firstComplex = GetNewComplex();
            Console.WriteLine("Второе число: ");
            Complex secondComplex = GetNewComplex();
            return new[] { firstComplex, secondComplex };

        }

        private static void Multiplication(Complex[] complexNums)
        {
            Complex newComplex = complexNums[0].By(complexNums[1]);
            Console.WriteLine(" ( " + complexNums[0] + " ) * ( " + complexNums[1] + " ) = " + newComplex);
        }

        private Complex By(Complex secondComplex)
        {
            Complex newComplex = new Complex
            {
                re = re * secondComplex.re - secondComplex.im * im,
                im = re*secondComplex.im + secondComplex.re+im
            };
            return newComplex;
        }

        private static void Subtraction(Complex[] complexNums)
        {
            Complex newComplex = complexNums[0].Minus(complexNums[1]);
            Console.WriteLine(" ( " + complexNums[0] + " ) - ( " + complexNums[1] + " ) = " + newComplex);
        }

        private static void Addition(Complex[] complexNums)
        {
            Complex newComplex = complexNums[0].Plus(complexNums[1]);
            Console.WriteLine(" ( " + complexNums[0] + " ) + ( " + complexNums[1] + " ) = " + newComplex);
        }

        private static Complex GetNewComplex()
        {
            Console.Write("Введите действительную часть комплексного числа: ");
            bool blRe;
            double re;
            do
            {
                blRe = double.TryParse(Console.ReadLine(), out re);
            } while (!blRe);
            Console.Write("Введите мнимую часть комплексного числа: ");
            bool blIm;
            double im;
            do
            {
                blIm = double.TryParse(Console.ReadLine(), out im);
            } while (!blIm);
            return new Complex(re, im);
        }

        /// <summary>
        /// Переопределение ToString() для вывода комплексных чисел
        /// </summary>
        public override string ToString()
        {
            if (im > 0) return re + " + " + im + "i";
            else if (im == 0) return re + "";
            else if (re == 0) return im + "i";
            else return re + " - " + im + "i";
        }

        public Complex Plus(Complex secondComplex)
        {
            Complex newComplex = new Complex
            {
                re = secondComplex.re + re,
                im = secondComplex.im + im
            };
            return newComplex;
        }

        public Complex Minus(Complex secondComplex)
        {
            Complex newComplex = new Complex
            {
                re = re - secondComplex.re,
                im = secondComplex.im - im
            };
            return newComplex;
        }

    }
}
