using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLogic;

namespace WindowsApp
{
    class Program
    {
        static void Main()
        {
            Connection connection = new Connection();
            var trommels = connection.Trommels;

            foreach (var trommel in trommels)
            {
                Console.WriteLine(trommel.area);
            }
            Console.Read();
        }
    }
}
