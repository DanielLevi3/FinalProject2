using System;
using System.Collections.Generic;
using FinalProject2;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
          //  Flights f = new Flights();
            FlightsDAOPGSQL f1 = new FlightsDAOPGSQL();
           //List<Flights> f_list =f1.GetAll();
          //  f_list.ForEach((_) => Console.WriteLine(_));
          //  UsersDAOPGSQL us1 = new UsersDAOPGSQL();
           // List<Users> u = new List<Users>();
           // u = us1.GetAll();
          //  u.ForEach((_) => Console.WriteLine(_));
            // f = f1.GetById(1);
            //Console.WriteLine(f);
            /*
             try
            {
              IList<Flights> f_list2 = f1.GetFlightsByOriginCountry(2);
                foreach (var item in f_list2)
                {
                    Console.WriteLine(item);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
           */

        }
    }
}
