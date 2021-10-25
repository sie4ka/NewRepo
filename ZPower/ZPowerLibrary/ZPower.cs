using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZPowerLibrary
{
    public struct ZPower
    {
        public double Base;
        public int Exponent;
        public readonly double Value;

        public ZPower (double b, int exponent)
        {
            if (exponent % 1 != 0)
            {
                throw new Exception("Показатель степени должен быть целым числом");
            }
            Base = b;
            Exponent = exponent;
            Value = Math.Pow(Base, Exponent);

        }
        public static ZPower Read()
        {
            double b;
            int e;

            while (true)
            {
                Console.WriteLine("Введите основание степени:");
                b = double.Parse(Console.ReadLine());

                Console.WriteLine("Введите показатель степени:");
                e = int.Parse(Console.ReadLine());

                if (e % 1 != 0)
                {
                    Console.WriteLine("Показатель степени должен быть целым числом");
                }
                else
                {
                    break;
                }
            }

            return new ZPower(b, e);
        }

        public override string ToString()
        {
            return $"{Base}E{Exponent}";
        }

        public override bool Equals(object obj)
        {
            if (obj is ZPower)
            {
                ZPower p = (ZPower)obj;

                return Value * Math.Pow(10, -13) == p.Value * Math.Pow(10, -13);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Base.GetHashCode() ^ Exponent.GetHashCode();
        }
        public void Display()
        {
            Console.WriteLine($"Структура ZPower, {Base}E{Exponent}");
        }
        public static ZPower operator * (ZPower p1, ZPower p2)
        {
            if (p1.Base == p2.Base)
            {
                return new ZPower(p2.Base, p1.Exponent + p2.Exponent);
            }
            else
            {
                throw new Exception("Для выполнения операции основания должны быть одинаковыми");
            }
         }
        public static ZPower operator / (ZPower p1, ZPower p2)
        {
            if (p1.Base == p2.Base)
            {
                return new ZPower(p1.Base, p1.Exponent - p2.Exponent);
            }
            else
            {
                throw new Exception("Для выполнения операции основания должны быть одинаковыми");
            }
        }

    }
}
