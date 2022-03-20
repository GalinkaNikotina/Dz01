using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zd01
{
    class Drobi
    {
        int ch;
        int zn;
        public Drobi(int a)
        {
            ch = a;
            zn = 1;
        }
        public Drobi(int a, int b)
        {
            ch = a;
            zn = b;
        }
        public Drobi(int a, int b, int z)
        {
            zn = b;
            ch = z * b + a;
        }
        public double Pool()
        {
            return (double)(ch) / zn;
        }
        public static Drobi operator +(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn + y.ch * x.zn, x.zn * y.zn);
        }
        public static Drobi operator -(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn - y.ch * x.zn, x.zn * y.zn);
        }
        public static Drobi operator *(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.ch, x.zn * y.zn);
        }
        public static Drobi operator /(Drobi x, Drobi y)
        {
            return new Drobi(x.ch * y.zn, x.zn * y.ch);
        }

        public void Znaki()
        {
            double result = ch / zn;
            if (Math.Sign(result) == 1)
            {
                Console.WriteLine("Знак дроби '+'");
            }
            else if (Math.Sign(result) == -1)
            {
                Console.WriteLine("Знак дроби '-'");
            }
            else
            {
                Console.WriteLine("Неверный ввод!");
            }
        }

        public delegate void Glin(Drobi a, int b); /*определяется делегат*/

        public event Glin EventGlin; /*определяется событие с именем*/
        public int Ch
        {
            get { return ch; }
            set
            {
                EventGlin(this, value);
                ch = value;
            }
        }
        public void GetDrobe(Drobi a)
        {
            Console.WriteLine(a.ch + "/" + a.zn);
        }
        public int this[int index] //Индексатор подобен стандартному свойству.
                                   //Во-первых, для индексатора определяется тип в данном случае тип int.
                                   //Тип индексатора определяет, какие объекты будет получать и возвращать индексатор.
                                   //Во-вторых, для индексатора определен параметр int index,
                                   //через который обращаемся к элементам внутри объекта drobi//
        {
            get { return (index == 0) ? ch : zn; }
        }
    }
    class Method
    {
        public static void MyRes(Drobi a, int x)
        {
            Console.WriteLine("Дробь изменена");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Drobi drob1 = new Drobi(4, 2);
            Drobi drob2 = new Drobi(2, 5);

            drob1.GetDrobe(drob1);
            drob1.Znaki();
            Console.WriteLine(drob2[1]);

            double deciatChicl = drob1.Pool();
            Console.WriteLine(deciatChicl);

            Drobi drobResult = drob1 + drob2;
            Console.WriteLine(drobResult.Ch);

            drob1.EventGlin += Method.MyRes;
            drob1.Ch = 7;

            Console.ReadKey();
        }
    }
}
