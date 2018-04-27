using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Flight1
{
    class Airline
    {
        public FlightCode FlightCode { get; set; }
        public string Name { get; set; }

        public Airline()
        {
            Airline chosen = AirlineAssociations.SelectAirline();   
            this.FlightCode = chosen.FlightCode;
            this.Name = chosen.Name;
        }

        public Airline(FlightCode FlightCode, string Name)
        {
            this.FlightCode = FlightCode;
            this.Name = Name;
        }
    }

    enum FlightCode
    {
        EI, FR, VIR, LO, W6
    }

    static class AirlineAssociations
    { 
        private static List<Airline> airlines = new List<Airline>
        {
            new Airline(FlightCode.EI, "Aer Lingus"),
            new Airline(FlightCode.FR, "Ryanair"),
            new Airline(FlightCode.VIR,"Virgin Atlantic"),
            new Airline(FlightCode.LO, "LOT - Polskie Linie Lotnicze"),
            new Airline(FlightCode.W6, "Wizzair - Hungary")
        };

        public static Airline SelectAirline()
        {
            int random = Randomiser.Randomise(airlines.Count);
            return airlines[random] as Airline;
        }
    }

    class Randomiser
    {
        private static Random randomiser = new Random();
        public static int Randomise(int maxValue)
        {
            return randomiser.Next(maxValue);
        }

        public static int Randomise(int minValue, int maxValue)
        {
            return randomiser.Next(minValue, maxValue);
        }
    }
}
