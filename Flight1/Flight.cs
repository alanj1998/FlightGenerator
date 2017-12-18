using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight1
{
    class Flight
    {
        public Airline Airline { get; set; }
        public int FlightNo { get; set; }
        public DateTime Time { get; set; }

        public Flight(Airline airline)
        {
            this.Airline = airline;
            this.FlightNo = Randomiser.Randomise(1, 999);
            this.Time = DateTime.UtcNow.Add(new TimeSpan(0, 0, Randomiser.Randomise(-30, 30)));
        }
        public Flight() : this(new Airline()) { }

        public override string ToString()
        {
            return String.Format("{0}{1}: {2} @ {3}", this.Airline.FlightCode, this.FlightNo, this.Airline.Name, this.Time);
        }
    }
}
