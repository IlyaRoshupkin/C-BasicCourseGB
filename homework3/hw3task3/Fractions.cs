using System;

namespace hw3task3
{
    class Fractions
    {
        private int Numerator { get; set; }
        private int Denominator { get; set; }
        private double Dec { get; }

        public Fractions()
        {
            Numerator = 1;
            Denominator = 1;
        }
        public Fractions(int numerator, int denominator)
        {
            if (denominator == 0) throw new ArgumentException("Знаменатель не может быть равен 0");
            this.Numerator = numerator;
            this.Denominator = denominator;
            this.Dec = (double)numerator / (double)denominator;
        }

        /// <summary>
        /// Метод сокращения дробей. 0н встроен
        /// в переопределённый метод ToString()
        /// </summary>
        /// <param name="numerator"></param>
        /// <param name="denominator"></param>
        /// <returns></returns>
        private int[] Reduction(int numerator, int denominator)
        {
            if (denominator == 0) 
                throw new ArgumentException("Знаменатель не может быть равен 0");
            int divider = 2;
            while (divider <= numerator || divider <= numerator)
            {
                if (numerator % divider == 0 && denominator % divider == 0)
                {
                    numerator /= divider;
                    denominator /= divider;
                }
                else
                    divider++;
            }
            return new[] { numerator, denominator };
        }

        public static void Demonsration()
        {
            bool work = true;
            int choise;
            while (work)
            {
                Console.Write("\nВыберете пункт:\n" +
                    "1 - Сложение дробей\n" +
                    "2 - Вычитание дробей\n" +
                    "3 - Умножение дробей\n" +
                    "4 - Деление дробей\n" +
                    "5 - Десятичное представление\n" + 
                    "6 - Сокращённое десятичное представление\n" +
                    "7 - Начать заново\n" +
                    "0 - Выход\n");
                bool bChoise;
                do
                {
                    bChoise = int.TryParse(Console.ReadLine(), out choise);
                } while (!bChoise || choise < 0 || choise > 7);
                switch (choise)
                {
                    case 1:
                        Fractions[] fractions = GetFractions();
                        Addition(fractions);
                        break;
                    case 2:
                        fractions = GetFractions();
                        Subtraction(fractions);
                        break;
                    case 3:
                        fractions = GetFractions();
                        Multiplication(fractions);
                        break;
                    case 4:
                        fractions = GetFractions();
                        Division(fractions);
                        break;
                    case 5:
                        Fractions fraction = GetNewFract();
                        PrintDec(fraction);
                        break;
                    case 6:
                        fraction = GetNewFract();
                        PrintDecRed(fraction);
                        break;
                    case 7:
                        Console.Clear();
                        break;
                    case 0:
                        Console.WriteLine("Программа завершила свою работу.");
                        work = false;
                        break;
                }
            }
        }
        /// <summary>
        /// Десятичное представление, две цифры после знака
        /// </summary>
        /// <param name="fraction"></param>
        private static void PrintDecRed(Fractions fraction)
        {
            Console.WriteLine("{0} = {1:N}",fraction, fraction.Dec);
        }

        /// <summary>
        /// Выводит на экран число в десятичном представлении
        /// </summary>
        /// <param name="fractions"></param>
        private static void PrintDec(Fractions fraction)
        {
            Console.WriteLine("{0} = {1}",fraction, fraction.Dec);
        }

        private static void Division(Fractions[] fractions)
        {
            Fractions newFract = new Fractions
            {
                Numerator = fractions[0].Numerator * fractions[1].Denominator,
                Denominator = fractions[0].Denominator * fractions[1].Numerator
            };
            Console.WriteLine(" ( " + fractions[0] + " ) / ( " + fractions[1] + " )" +
                " = " + newFract);
        }

        private static void Multiplication(Fractions[] fractions)
        {
            Fractions newFract = new Fractions
            {
                Numerator = fractions[0].Numerator * fractions[1].Numerator,
                Denominator = fractions[0].Denominator * fractions[1].Denominator
            };
            Console.WriteLine(" ( " + fractions[0] + " ) * ( " + fractions[1] + " )" +
                " = " + newFract);
        }

        private static void Subtraction(Fractions[] fractions)
        {
            Fractions newFract = new Fractions
            {
                Numerator = fractions[0].Numerator * fractions[1].Denominator -
                fractions[1].Numerator * fractions[0].Denominator,
                Denominator = fractions[0].Denominator * fractions[1].Denominator
            };
            Console.WriteLine(" ( " + fractions[0] + " ) - ( " + fractions[1] + " )" +
                " = " + newFract);
        }

        private static void Addition(Fractions[] fractions)
        {
            Fractions newFract = new Fractions
            {
                Numerator = fractions[0].Numerator * fractions[1].Denominator +
                fractions[1].Numerator * fractions[0].Denominator,
                Denominator = fractions[0].Denominator * fractions[1].Denominator
            };
            Console.WriteLine(" ( " + fractions[0] + " ) + ( " + fractions[1] + " )" +
                " = " + newFract);
        }

        private static Fractions[] GetFractions()
        {
            Console.WriteLine("Введите две дроби:\nПервая дробь:");
            Fractions firstFract = GetNewFract();
            Console.WriteLine("Вторая дробь: ");
            Fractions secondFract = GetNewFract();
            return new[] { firstFract, secondFract };
        }

        private static Fractions GetNewFract()
        {
            Console.Write("Введите числитель: ");
            bool blNum;
            int num;
            do
            {
                blNum = int.TryParse(Console.ReadLine(), out num);
            } while (!blNum);
            Console.Write("Введите знаменатель: ");
            bool blDenom;
            int denom;
            do
            {
                blDenom = int.TryParse(Console.ReadLine(), out denom);
            } while (!blDenom);
            return new Fractions(num, denom);
        }

        public override string ToString()
        {
            int[] fract = Reduction(Numerator, Denominator);
            return fract[0] + "/" + fract[1];
        }
    }
}
