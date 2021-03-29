using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FinalProject2;
using FinalProject2.Classes;
using log4net;
using log4net.Config;

namespace ConsoleApp1
{
    class Program
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    

    static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));


            log.Info("Hello logging world!");

            Flights f = new Flights();
            FlightsDAOPGSQL f1 = new FlightsDAOPGSQL();
            List<Flights> f_list =f1.GetAll();
              f_list.ForEach((_) => Console.WriteLine(_));
            Console.WriteLine("================================");
            //  UsersDAOPGSQL us1 = new UsersDAOPGSQL();
            // List<Users> u = new List<Users>();
            // u = us1.GetAll();
            //  u.ForEach((_) => Console.WriteLine(_));
             f = f1.GetById(1);
            Console.WriteLine(f);
            Console.WriteLine("=======================================");
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
           /* List<Administrator> a_list = new List<Administrator>();
            AdministratorDAOPGSQL a1 = new AdministratorDAOPGSQL();
                try
                {
                    a_list = a1.GetAll();
                    a_list.ForEach((_) => Console.WriteLine(_));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

      */      //  Administrator a = a1.GetById(1);
            //Console.WriteLine(a);
            //Flights f_new = new Flights(2,3,3,3, new DateTime(2015, 02, 15, 20, 00, 00), new DateTime(2020, 12, 10, 20, 15, 50, 20), 15,null);
            //f1.Add(f);
            //Flights f2 = new Flights(3,4, 4, 6,new DateTime(2021,12,22,20,00,00),new DateTime(2022,06,12,20,00,00), 23);
            // f1.Update(f2);

            // f1.Add(f_new);
            // f1.Remove(3);
           Administrator a3 = new Administrator("itay", "Levi", 2, 3);
            //a1.Add(a3);
            //  a1.Update(a3);
            Console.WriteLine("=======================================");
            CustomersDAOPGSQL c1 = new CustomersDAOPGSQL();
            List<Customers> c_list = c1.GetAll();
            c_list.ForEach((_) => Console.WriteLine(_));
            Console.WriteLine("=================================");
            AirlineCompaniesDAOPGSQL air1 = new AirlineCompaniesDAOPGSQL();
            List<AirlineCompanies> air_list = air1.GetAll();
            air_list.ForEach((_) => Console.WriteLine(_));
            Console.WriteLine("===========================");
            CountryDAOPGSQL con1 = new CountryDAOPGSQL();
            List<Country> c12_list = con1.GetAll();
            c12_list.ForEach((_) => Console.WriteLine(_));
            Console.WriteLine("========================");
            TicketsDAOPGSQL t1 = new TicketsDAOPGSQL();
            List<Tickets> t_list = t1.GetAll();
            t_list.ForEach((_) => Console.WriteLine(_));
            FlightCenterSystem flightCenter = FlightCenterSystem.GetInstance();
            
         }
    }
}
