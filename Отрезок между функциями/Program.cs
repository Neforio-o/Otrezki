using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Отрезок_между_функциями
{
    public interface IGraphics
    {
        double Calculate(double x, int roundValue, int d);
        bool GetGraphics(IGraphics f, double x1, double x2, ref double x, int d);

    }

    public class F : IGraphics
    {
        public double Calculate(double x, int roundValue, int d)
        {
            double a = 0;
            switch (d)
            {
                case 0:
                    a = Math.Round(Math.Exp((2 * x) - 8), roundValue);
                    break;
                case 1:
                    a = Math.Round(2 * Math.Sin(x / 2 + 3), roundValue);
                    break;
                case 2:
                    a = Math.Round(1 / (2 * x - 1), roundValue);
                    break;
                case 3:
                    a = Math.Round(2.5 * Math.Log10(1.7 * x - 1), roundValue);
                    break;
                case 4:
                    a = Math.Round(Math.Exp(2 * x - 8), roundValue);
                    break;
                case 5:
                    a = Math.Round(5 * Math.Log10(2 * x + 2), roundValue);
                    break;
                case 6:
                    a = Math.Round(Math.Pow(10, (-x - 2)), roundValue);
                    break;
                case 7:
                    a = Math.Round(1 / (1.3 * x - 2), roundValue);
                    break;
                case 8:
                    a = Math.Round(0.3 * Math.Cos(Math.Pow(x, 2)) - 2.1, roundValue);
                    break;
                case 9:
                    a = Math.Round(Math.Exp(Math.Pow(-x, 2)), roundValue);
                    break;
                case 10:
                    a = Math.Round(1.7 * Math.Log10(4 * x - 2.5), roundValue);
                    break;
                case 11:
                    a = Math.Round(0.5 * Math.Sin(2 * x - 1), roundValue);
                    break;
                case 12:
                    a = Math.Round(1 / (1 - 0.5 * x), roundValue);
                    break;
                case 13:
                    a = Math.Round(Math.Pow(10, (-0.4 * x - 2.5)), roundValue);
                    break;
                case 14:
                    a = Math.Round(0.4 * Math.Log10(4 * x - 2.5), roundValue);
                    break;
                case 15:
                    a = Math.Round(2 * Math.Cos(1.5 * x - 0.9), roundValue);
                    break;
            }
            return a;
        }

        public bool GetGraphics(IGraphics f, double x1, double x2, ref double x_cross, int d)
        {
            double x;
            for (x = x1; x <= x2; x+= 0.0001)
            {
                if (x == 1.51)
                {
                    Console.WriteLine("Work");
                }
                if (Math.Abs(Calculate(x, 2, d) - f.Calculate(x, 2, d)) < 0.01)
                {
                    Console.WriteLine("Take");
                    x_cross = x;
                    return true;
                }
            }
            return false;
        }
    }

    public class G : IGraphics
    {
        public double Calculate(double x, int roundValue, int d)
        {
            double b = 0;
            switch (d)
            {
                case 0:
                    b = Math.Round(Math.Pow(x, 2) - x - 6, roundValue);
                    break;
                case 1:
                    b = Math.Round(1.5 * Math.Pow(x, 2) - 2.5 * x - 4, roundValue);
                    break;
                case 2:
                    b = Math.Round(0.17 * Math.Pow(x, 3) - 1.5 * Math.Pow(x, 2) + 4 * x + 3, roundValue);
                    break;
                case 3:
                    b = Math.Round(0.25 * Math.Pow(x, 2) - 0.75 * x - 1, roundValue);
                    break;
                case 4:
                    b = Math.Round(Math.Pow(x, 2) - x - 6, roundValue);
                    break;
                case 5:
                    b = Math.Round(Math.Pow(x, 2) - 13 * x - 40, roundValue);
                    break;
                case 6:
                    b = Math.Round(Math.Pow(x, 2) - x - 2, roundValue);
                    break;
                case 7:
                    b = Math.Round(Math.Pow(x, 3) - 7 * x - 6 * Math.Pow(x, 2) - 6, roundValue);
                    break;
                case 8:
                    b = Math.Round(1.4 * Math.Pow(x, 2) + 0.9 * x - 0.5, roundValue);
                    break;
                case 9:
                    b = Math.Round(Math.Pow(x, 2) - 6 * x + 8, roundValue);
                    break;
                case 10:
                    b = Math.Round(0.5 * Math.Pow(x, 2) - 3 * x - 4, roundValue);
                    break;
                case 11:
                    b = Math.Round(0.3 * Math.Pow(x, 2) - 0.05 * x - 1, roundValue);
                    break;
                case 12:
                    b = Math.Round(0.2 * Math.Pow(x, 2) - 1.4 * x + 2, roundValue);
                    break;
                case 13:
                    b = Math.Round(-2 * Math.Pow(x, 2) + 17 * x - 8, roundValue);
                    break;
                case 14:
                    b = Math.Round(0.5 * Math.Pow(x, 2) - 3 * x - 4, roundValue);
                    break;
                case 15:
                    b = Math.Round(0.2 * Math.Pow(x, 3) + 2.8 * x - 3, roundValue);
                    break;
            }
            return b;
        }

        public bool GetGraphics(IGraphics g, double x1, double x2, ref double x_cross, int d)
        {
            double x;
            for (x = x1; x <= x2; x += 0.0001)
            {
                if (Math.Abs(Calculate(x, 2, d) - g.Calculate(x, 2, d)) < 0.01)
                {
                    x_cross = x;
                    return true;
                }
            }
            return false;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер желаемой пары: ");
            int d = 0;
            try
            {
                d = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Введите корректные данные");
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
                Main(args);
            }
            double a = 0;
            double b = 0;
            
            IGraphics f = new F();
            IGraphics g = new G();

            double x1 = 0, x2 = 0, len = 0;
            int p1 = -15, p2 = 0, p3 = 0, p4 = 15;
            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine($"{p1} : {p2} | {p3} : {p4}");
                if (f.GetGraphics(g, p1, p2, ref x1, d))
                {
                    switch (d)
                    {
                        case 0:
                            a = Math.Round(Math.Exp((2 * x1) - 8), 3);
                            break;
                        case 1:
                            a = Math.Round(2 * Math.Sin(x1 / 2 + 3), 3);
                            break;
                        case 2:
                            a = Math.Round(1 / (2 * x1 - 1), 3);
                            break;
                        case 3:
                            a = Math.Round(2.5 * Math.Log10(1.7 * x1 - 1), 3);
                            break;
                        case 4:
                            a = Math.Round(Math.Exp(2 * x1 - 8), 3);
                            break;
                        case 5:
                            a = Math.Round(5 * Math.Log10(2 * x1 + 2), 3);
                            break;
                        case 6:
                            a = Math.Round(Math.Pow(10, (-x1 - 2)), 3);
                            break;
                        case 7:
                            a = Math.Round(1 / (1.3 * x1 - 2), 3);
                            break;
                        case 8:
                            a = Math.Round(0.3 * Math.Cos(Math.Pow(x1, 2)) - 2.1, 3);
                            break;
                        case 9:
                            a = Math.Round(Math.Exp(Math.Pow(-x1, 2)), 3);
                            break;
                        case 10:
                            a = Math.Round(1.7 * Math.Log10(4 * x1 - 2.5), 3);
                            break;
                        case 11:
                            a = Math.Round(0.5 * Math.Sin(2 * x1 - 1), 3);
                            break;
                        case 12:
                            a = Math.Round(1 / (1 - 0.5 * x1), 3);
                            break;
                        case 13:
                            a = Math.Round(Math.Pow(10, (-0.4 * x1 - 2.5)), 3);
                            break;
                        case 14:
                            a = Math.Round(0.4 * Math.Log10(4 * x1 - 2.5), 3);
                            break;
                        case 15:
                            a = Math.Round(2 * Math.Cos(1.5 * x1 - 0.9), 3);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Такого номера пары нет!");
                            Console.ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            Main(args);
                            break;
                    }
                    if (f.GetGraphics(g, p3, p4, ref x2, d))
                    {
                        switch (d)
                        {
                            case 0:
                                b = Math.Round(Math.Pow(x2, 2) - x2 - 6, 3);
                                break;
                            case 1:
                                b = Math.Round(1.5 * Math.Pow(x2, 2) - 2.5 * x2 - 4, 3);
                                break;
                            case 2:
                                b = Math.Round(0.17 * Math.Pow(x2, 3) - 1.5 * Math.Pow(x2, 2) + 4 * x2 + 3, 3);
                                break;
                            case 3:
                                b = Math.Round(0.25 * Math.Pow(x2, 2) - 0.75 * x2 - 1, 3);
                                break;
                            case 4:
                                b = Math.Round(Math.Pow(x2, 2) - x2 - 6, 3);
                                break;
                            case 5:
                                b = Math.Round(Math.Pow(x2, 2) - 13 * x2 - 40, 3);
                                break;
                            case 6:
                                b = Math.Round(Math.Pow(x2, 2) - x2 - 2, 3);
                                break;
                            case 7:
                                b = Math.Round(Math.Pow(x2, 3) - 7 * x2 - 6 * Math.Pow(x2, 2) - 6, 3);
                                break;
                            case 8:
                                b = Math.Round(1.4 * Math.Pow(x2, 2) + 0.9 * x2 - 0.5, 3);
                                break;
                            case 9:
                                b = Math.Round(Math.Pow(x2, 2) - 6 * x2 + 8, 3);
                                break;
                            case 10:
                                b = Math.Round(0.5 * Math.Pow(x2, 2) - 3 * x2 - 4, 3);
                                break;
                            case 11:
                                b = Math.Round(0.3 * Math.Pow(x2, 2) - 0.05 * x2 - 1, 3);
                                break;
                            case 12:
                                b = Math.Round(0.2 * Math.Pow(x2, 2) - 1.4 * x2 + 2, 3);
                                break;
                            case 13:
                                b = Math.Round(-2 * Math.Pow(x2, 2) + 17 * x2 - 8, 3);
                                break;
                            case 14:
                                b = Math.Round(0.5 * Math.Pow(x2, 2) - 3 * x2 - 4, 3);
                                break;
                            case 15:
                                b = Math.Round(0.2 * Math.Pow(x2, 3) + 2.8 * x2 - 3, 3);
                                break;
                        }
                        Console.WriteLine("X1 = " + Math.Round(x1, 3));
                        Console.WriteLine("Y1 = " + a);
                        Console.WriteLine("X2 = " + Math.Round(x2, 3));
                        Console.WriteLine("Y2 = " + b);
                        break;
                    }
                }
                p1 += 1;
                p2 += 1;
                p3 += 1;
                p4 += 1;
            }
            
            Console.WriteLine("Первая точка пересечения : a[" + Math.Round(x1, 3) + ";" + a + "]");
            Console.WriteLine("Вторая точка пересечения : a[" + Math.Round(x2, 3) + ";" + b + "]");
            len = Math.Sqrt(Math.Pow(x2 - x1,2) + Math.Pow(b - a,2));
            Console.WriteLine("Длина отрезка ab: " + Math.Round(len, 3));
            Console.ReadKey(true);
            Console.Clear();
            Main(args);
        }
    }
}
