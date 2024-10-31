using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello__world_Prague_parking_v3._0
{
    public class ParkingGarage
    {
        private List<List<ParkingSpot>> parkingSpots;
        int n = 101;
        public ParkingGarage(List<List<ParkingSpot>> spots)                                       // constructor for ParkingGarage
        {
            parkingSpots = spots ?? new List<List<ParkingSpot>>(new List<ParkingSpot>[n]);
            for (int i = 0; i < parkingSpots.Count; i++)
            {
                if (parkingSpots[i] == null)
                {
                    parkingSpots[i] = new List<ParkingSpot>();
                }
            }
        }
        
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //ViewParking
        public void ViewParking()
        {
            for (int i = 1; i < parkingSpots.Count; i++)
            {
                if (parkingSpots[i].Count == 0)
                {
                    Console.Write($"|Spot {i}: Empty");                                   // | for breaking between parkinng spots
                    if (i % 5 == 0) { Console.Write("|"); Console.WriteLine(); }
                }
                else
                {
                    Console.Write($"|Spot {i}:");

                    foreach (var vehicle in parkingSpots[i])
                    {
                        if (vehicle.Type == VehicleType.Car)
                        {
                            AnsiConsole.Markup($"[blue] {vehicle.RegNumber} [/]");                  // Spectre.Console used for colour coding car,mc,bike and bus 
                        }
                        else if (vehicle.Type == VehicleType.Motorcycle)
                        {
                            AnsiConsole.Markup($"[red] {vehicle.RegNumber} [/]");
                        }
                        else if (vehicle.Type == VehicleType.Bus)
                        {
                            AnsiConsole.Markup($"[yellow] {vehicle.RegNumber} [/]");
                        }
                        else if (vehicle.Type == VehicleType.Bike)
                        {
                            AnsiConsole.Markup($"[green] {vehicle.RegNumber} [/]");
                        }
                    }
                    if (i % 5 == 0) { Console.Write("|"); Console.WriteLine(); }
                }
            }
            Console.WriteLine("\nPress any key to go back to the main menu");
            Console.ReadKey(true);
            Console.Clear();
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //UpdateParkingSpots
        public void UpdateParkingSpots(List<List<ParkingSpot>> spots)             // method inputs every Pspot individually when json file is loaded so not to mess with the index 
        {
            parkingSpots = spots;
            for (int i = 0; i < parkingSpots.Count; i++)
            {
                if (parkingSpots[i] == null)
                {
                    parkingSpots[i] = new List<ParkingSpot>();
                }
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public void AddParkingSpots(List<List<ParkingSpot>> parkingSpots, string filePath)
        {
            Console.WriteLine("how many parking spots would you like to add? ");
            if (int.TryParse(Console.ReadLine(),out int addSpots))
            {
                for (int i = 0; i < addSpots; i++)
                {
                    parkingSpots.Add(new List<ParkingSpot>());
                }
                Console.WriteLine($"{addSpots} spots added to the Parking Garage. The updated Parking Garage holds {parkingSpots.Count - 1} spots");
            }
        }
    }
}
