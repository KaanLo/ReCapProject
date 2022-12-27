using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleIU
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CarManager carManager = new CarManager(new InMemoryProductDal());

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Id);
            }

        }
    }
}
