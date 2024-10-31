using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hello__world_Prague_parking_v3._0
{
    public class ParkingSpot
    {

        [JsonInclude] // lägger till att den ska spara med mer info om till ex plats osv
        public string RegNumber { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]                   // Serialize enum as  string
        [JsonInclude]
        public VehicleType Type { get; set; }

        [JsonInclude]
        public int Points { get; set; }

        [JsonInclude]
        public DateTime CurrentTimeIn { get; set; }

        [JsonInclude]
        public DateTime? CurrentTimeOut { get; set; }

        [JsonInclude]
        public int SpotIndex { get; set; }


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        [JsonConstructor]                                     // for individual json saving of all the different things in the nested list(spliits them individually for easier save
        public ParkingSpot(string regNumber, VehicleType type, int spotIndex = -1)
        {
            RegNumber = regNumber;
            Type = type;
            SpotIndex = spotIndex;
            CurrentTimeIn = DateTime.Now;
            CurrentTimeOut = null;


            Points = type switch     // Assign points based on vehicle type
            {
                VehicleType.Car => 4,
                VehicleType.Motorcycle => 2,
                VehicleType.Bike => 1,
                VehicleType.Bus => 4,  //  tar 4 platser
                _ => 0,                      // no type = 0 must have for json 
            };
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void setTimeOut()
        {
            CurrentTimeOut = DateTime.Now;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void CalculateCharge()
        {
            if (CurrentTimeOut == null)
            {
                Console.WriteLine("Error: Vehicle is still parked.");
                return;
            }

            TimeSpan parkingDuration = CurrentTimeOut.Value - CurrentTimeIn;    // Kalkulerar tot
            double totalHours = Math.Ceiling((parkingDuration.TotalMinutes - 10) / 60);   // första 10 min är graits
            totalHours = Math.Max(totalHours, 0);   // Error check så man ej får negativ summa

            int rate = 
                Type == VehicleType.Car ? 20 : 
                Type == VehicleType.Motorcycle ? 10 : 0;
                // Type == VehicleType.Bus ? 80 :
                // Type == VehicleType.Bike ? 5 ;

            int totalCharge = (int)(totalHours * rate);   // slutkalkulationen

            Console.WriteLine($"Parking fee for vehicle {RegNumber}: {totalCharge} CZK");
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

    }
}
