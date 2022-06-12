using System;
using System.Numerics;

namespace Wielomian4stopnia
{
    internal class Program
    {
        private static void Wynik(double p, double q, double r, double s)
        {
            if (double.IsNaN(p) || double.IsNaN(q))
                Console.WriteLine("Brak miejsc zerowych");
            else
            {
                double xwynik1 = p + q + r - s;
                double xwynik2 = p - q - r - s;
                double xwynik3 = -p + q - r - s;
                double xwynik4 = -p - q + r - s;
                Console.WriteLine(xwynik1);
                Console.WriteLine(xwynik2);
                Console.WriteLine(xwynik3);
                Console.WriteLine(xwynik4);
            }
        }

        private static void Main(string[] args)
        {
            double a = Convert.ToInt32(Console.ReadLine());
            double b = Convert.ToInt32(Console.ReadLine());
            double c = Convert.ToInt32(Console.ReadLine());
            double d = Convert.ToInt32(Console.ReadLine());
            double e = Convert.ToInt32(Console.ReadLine());

            if (a == 0)
            {
                Console.WriteLine("Niepoprawne dane");
                return;
            }

            double f = (c / a) - ((3 * b * b) / (8 * a * a));
            double g = (d / a) + ((b * b * b) / (8 * a * a * a)) - ((b * c) / (2 * a * a));
            double h = (e / a) - ((3 * b * b * b * b) / (256 * a * a * a * a)) + ((b * b * c) / (16 * a * a * a)) - ((b * d) / (4 * a * a));

            double b1 = f / 2;
            double c1 = ((f * f) - (4 * h)) / 16;
            double d1 = -(g * g) / 64;

            //delta
            double p = c1 - b1 * b1 / 3;
            double q = b1 * (2 * b1 * b1 - 9 * c1) / 27 + d1;
            double p3 = p * p * p;
            double delta = q * q + 4 * p3 / 27;
            double subst = -b1 / 3;

            if (delta > 0)
            {
                double p1 = 0.00;
                double q1 = 0.00;
                delta = Math.Sqrt(delta);
                double u = Math.Cbrt((-q + delta) / 2);
                double v = Math.Cbrt((-q - delta) / 2);
                double rzecz = (-0.5) * (u + v) + subst;
                double urojona = (Math.Sqrt(3) / 2) * (u - v);
                double x1 = (u + v + subst);
                Complex zespolona1 = new Complex(rzecz, urojona);
                Complex zespolona2 = new Complex(rzecz, -urojona);
                p1 = Complex.Sqrt(zespolona1).Magnitude;
                q1 = Complex.Sqrt(zespolona2).Magnitude;

                double r = -((g) / (8 * p1 * q1));
                double s = b / (4 * a);

                Wynik(p1, q1, r, s);

                // Console.WriteLine("Otrzymujemy trzy pierwiastki. Jeden pierwiastek rzeczywisty x1 oraz dwa urojone x2 oraz x3:");
            }
            else if (delta < 0) // trzy pierwiastki rzeczywiste
            {
                double u = 2 * Math.Sqrt(-p / 3);
                double v = Math.Acos(-Math.Sqrt(-27 / p3) * q / 2) / 3;
                double x1 = u * Math.Cos(v) + subst;
                double x2 = u * Math.Cos(v + 2 * Math.PI / 3) + subst;
                double x3 = u * Math.Cos(v + 4 * Math.PI / 3) + subst;
                double y1 = 0.00;
                double y2 = 0.00;

                if (x1 > 0 && x2 > 0)
                {
                    y1 = x1;
                    y2 = x2;
                }
                else if (x1 > 0 && x3 > 0)
                {
                    y1 = x1;
                    y2 = x3;
                }
                else if (x2 > 0 && x3 > 0)
                {
                    y1 = x2;
                    y2 = x3;
                }
                else
                {
                    Console.WriteLine("Brak rozwiazan");
                    return;
                }

                double p1 = Math.Sqrt(y1);
                double q1 = Math.Sqrt(y2);
                double r = -((g) / (8 * p1 * q1));
                double s = b / (4 * a);

                Wynik(p1, q1, r, s);
            }
            else if (delta == 0)
            {
                double u = -Math.Cbrt(q / 2);
                double x1 = 2 * u + subst;
                double x2 = -u + subst;
                double y1;
                double y2;
                y1 = x1;
                y2 = x2;

                double p1 = Math.Sqrt(y1);
                double q1 = Math.Sqrt(y2);

                double r = -((g) / (8 * p1 * q1));
                double s = b / (4 * a);

                Wynik(p1, q1, r, s);
            }
        }
    }
}