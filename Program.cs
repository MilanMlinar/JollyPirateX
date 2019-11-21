using System;
using JollyPirate.controller;
using JollyPirate.model;
using JollyPirate.view;

namespace JollyPirate
{
    [Serializable()]
    class Program
    {
        static void Main(string[] args)
        {
            Database d = new Database();
            MembersRegistry m = new MembersRegistry(d);
            View v = new View();
            Controller c = new Controller(d);
   
            try
            {
                c.run(v, m);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unfortunately something unexpected happened!");
                Console.WriteLine("Please restart the application!");
                Console.WriteLine(ex.Message);
            }
        }
    }
}
