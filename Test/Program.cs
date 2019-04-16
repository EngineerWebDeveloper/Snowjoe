using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
   public class Base
    {
        public virtual void Print()
        {
            Console.WriteLine("base here");
        }

    }
    public class Child:Base
    {
        public override void Print()
        {
            Console.WriteLine("child here");
        }

    }
    public class Hidder:Base
    {
        public new void Print()
        {
            Console.WriteLine("hidder here");
        }

    }
    class Program
    {
        public static void Main(string[] args)
        {
            Base a = new Base();
            Base b = new Child();
            Base c = new Hidder();
            a.Print();
            b.Print();
            c.Print();
            Console.ReadKey();
        }
    }
}
