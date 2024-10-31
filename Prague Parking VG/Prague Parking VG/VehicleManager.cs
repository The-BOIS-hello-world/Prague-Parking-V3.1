using Prague_Parking_VG;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hello__world_Prague_parking_v3._0
{
    public class VehicleManager
    {
        //metod checkfor symbol and already exisiting regnumber
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool CharCheck(string regNumber)
        {
            bool hasSymbol = regNumber.Any(c => !char.IsLetterOrDigit(c));
            return hasSymbol;
        }
        public bool RegExists(string regNumber, List<List<ParkingSpot>> parkingSpots)
        {
            for (int i = 1; i < parkingSpots.Count; i++)
            {
                for (int j = 0; j < parkingSpots[i].Count; j++)
                {
                    if (parkingSpots[i][j].RegNumber == regNumber)
                    {
                        Console.WriteLine("Reg number already exists ");
                        return true;
                    }
                }
            }
            return false;
        }
        private bool IsValidRegistration(string regNumber, List<List<ParkingSpot>> parkingSpots)
        {
            return regNumber.Length >= 4 && regNumber.Length <= 10
                && !string.IsNullOrEmpty(regNumber)
                && !CharCheck(regNumber)
                && !RegExists(regNumber, parkingSpots);
        }
      
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //AddVehicle
        public void AddVehicle(List<List<ParkingSpot>> spots, int vehicleChoice)                       // Method to add a car
        {
            Console.Write("Please enter the registration number: ");
            string regNumber = Console.ReadLine()?.ToUpper();

            while (!IsValidRegistration(regNumber, spots))
            {
                Console.WriteLine(@"Reg is invalid. Retry or type ""Return"" to go to main menu:");
                Console.Write("Enter your registration number: ");
                regNumber = Console.ReadLine().ToUpper();

                if (regNumber == "RETURN") return;
            }
            if (vehicleChoice == 1)
            {
                int availableSpot = Car.FindAvailableSpot(spots);
                if (availableSpot == -1)
                {
                    Console.WriteLine("No available spots for a car.");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

                ParkingSpot newCar = new ParkingSpot(regNumber, VehicleType.Car, availableSpot);
                spots[availableSpot].Add(newCar);
                Console.WriteLine($"Car with registration number {regNumber} parked at spot {availableSpot}.");
                Console.ReadKey(true);
                Console.Clear();
            }
            else if (vehicleChoice == 2)
            {

                int availableSpot = Mc.FindAvailableSpot(spots);
                if (availableSpot == -1)
                {
                    Console.WriteLine("No available spots for a motorcycle.");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

                ParkingSpot newMc = new ParkingSpot(regNumber, VehicleType.Motorcycle, availableSpot);
                spots[availableSpot].Add(newMc);
                Console.WriteLine($"Motorcycle with registration number {regNumber} parked at spot {availableSpot}.");
                Console.ReadKey(true);
                Console.Clear();
            }
            else if (vehicleChoice == 3)
            {
                int availableSpot = Bike.FindAvailableSpot(spots);
                if (availableSpot == -1)
                {
                    Console.WriteLine("No available spots for a Bike.");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

                ParkingSpot newBike = new ParkingSpot(regNumber, VehicleType.Bike, availableSpot);
                spots[availableSpot].Add(newBike);
                Console.WriteLine($"Bike with registration number {regNumber} parked at spot {availableSpot}.");
                Console.ReadKey(true);
                Console.Clear();
            }
            else if (vehicleChoice == 4)
            {
                int availableSpot = Bus.FindAvailableSpot(spots);
                if (availableSpot == -1)
                {
                    Console.WriteLine("No available spots for a Bus.");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

                ParkingSpot newBus = new ParkingSpot(regNumber, VehicleType.Bus, availableSpot);
                ParkingSpot newBus1 = new ParkingSpot(regNumber, VehicleType.Bus, availableSpot +1);
                ParkingSpot newBus2 = new ParkingSpot(regNumber, VehicleType.Bus, availableSpot +2);
                ParkingSpot newBus3 = new ParkingSpot(regNumber, VehicleType.Bus, availableSpot +3);

                spots[availableSpot].Add(newBus);
                spots[availableSpot + 1].Add(newBus1);
                spots[availableSpot + 2].Add(newBus2);
                spots[availableSpot + 3].Add(newBus3);

                Console.WriteLine($"Bus with registration number {regNumber} parked at spot {availableSpot} + {availableSpot + 1} + {availableSpot +2} + {availableSpot + 3}");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        //RemoveVehicle
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public void RemoveVehicle(List<List<ParkingSpot>> spots, int vehicleChoice)
        {
            Console.Write("Please enter the registration number: ");
            string regNumber = Console.ReadLine().ToUpper();

            if (vehicleChoice == 1)
            {
                for (int i = 1; i < spots.Count; i++)
                {
                    var currentSpot = spots[i];

                    if (currentSpot != null && currentSpot.Any())
                    {
                        var carToRemove = currentSpot.FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Car);

                        if (carToRemove != null)
                        {
                            carToRemove.setTimeOut();          // Set the time the vehicle left
                            carToRemove.CalculateCharge();     // Calculate and display the parking charge
                            currentSpot.Remove(carToRemove);
                            Console.WriteLine($"Car with registration number {regNumber} removed from spot {i}.");
                            Console.WriteLine("Press any key to return to the main menu.");
                            Console.ReadKey(true);
                            Console.Clear();
                            return;
                        }
                    }
                }
            }
            else if (vehicleChoice == 2)
            {
                for (int i = 1; i < spots.Count; i++)
                {
                    var currentSpot = spots[i];

                    if (currentSpot != null && currentSpot.Any())
                    {
                        var mcToRemove = currentSpot.FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Motorcycle);

                        if (mcToRemove != null)
                        {
                            mcToRemove.setTimeOut();          // Set the time the vehicle left
                            mcToRemove.CalculateCharge();     // Calculate and display the parking charge
                            currentSpot.Remove(mcToRemove);
                            Console.WriteLine($"Motorcycle with registration number {regNumber} removed from spot {i}.");
                            Console.WriteLine("Press any key to return to the main menu.");
                            Console.ReadKey(true);
                            Console.Clear();
                            return;
                        }
                    }
                }
                Console.WriteLine($"Motorcycle with registration number {regNumber} was not found in the parking garage.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey(true);
                Console.Clear();
            }
            else if (vehicleChoice == 3)
            {
                for (int i = 1; i < spots.Count; i++)
                {
                    var currentSpot = spots[i];

                    if (currentSpot != null && currentSpot.Any())
                    {
                        var BikeToRemove = currentSpot.FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bike);

                        if (BikeToRemove != null)
                        {
                            BikeToRemove.setTimeOut();          // Set the time the vehicle left
                            BikeToRemove.CalculateCharge();     // Calculate and display the parking charge
                            currentSpot.Remove(BikeToRemove);
                            Console.WriteLine($"Bike with registration number {regNumber} removed from spot {i}.");
                            Console.WriteLine("Press any key to return to the main menu.");
                            Console.ReadKey(true);
                            Console.Clear();
                            return;
                        }
                    }
                }
                Console.WriteLine($"Bike with registration number {regNumber} was not found in the parking garage.");
                Console.WriteLine("Press any key to return to the main menu.");
                Console.ReadKey(true);
                Console.Clear();
            }
            if (vehicleChoice == 4)
            {
                for (int i = 1; i < spots.Count; i++)
                {
                    if (spots[i] != null && spots[i].Any())
                    {
                        var BusToRemove = spots[i].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);
                        var BusToRemove1 = spots[i + 1].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);
                        var BusToRemove2 = spots[i + 2].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);
                        var BusToRemove3 = spots[i + 3].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);

                        if (BusToRemove != null)
                        {
                            BusToRemove.setTimeOut();          // Set the time the vehicle left
                            BusToRemove.CalculateCharge();     // Calculate and display the parking charge
                            spots[i].Remove(BusToRemove);
                            spots[i + 1].Remove(BusToRemove1);
                            spots[i + 2].Remove(BusToRemove2);
                            spots[i + 3].Remove(BusToRemove3);
                            Console.WriteLine($"Bus with registration number {regNumber} removed from spots {i}, {i+1}, {i+2}, {i+3}");
                            Console.WriteLine("Press any key to return to the main menu.");
                            Console.ReadKey(true);
                            Console.Clear();
                            return;
                        }
                    }
                }
            }

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //MoveVehicle
        public void MoveVehicle(List<List<ParkingSpot>> spots, int vehicleChoice)
        {
            int i = 1;
            Console.Write("Please enter the registration number: ");
            string regNumber = Console.ReadLine()?.ToUpper();

            if (vehicleChoice == 1)
            {
                for (i = 1; i < spots.Count; i++)
                {
                    var currentSpot = spots[i];

                    if (currentSpot != null && currentSpot.Any())
                    {
                        var carmove = currentSpot.FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Car);

                        if (carmove != null)
                        {
                            Console.Write($"Your car was found in spot {i}, which spot would you like to move to? Spot: ");
                            break;
                        }
                    }
                    if (i == spots.Count - 1)
                    {
                        Console.WriteLine("A car with this Regnumber was not found you will be returned to the main menu");
                        Console.ReadKey(true);
                        Console.Clear();
                        return;
                    }
                }

                int spotIndex;
                if (int.TryParse(Console.ReadLine(), out spotIndex) && spotIndex >= 1 && spotIndex <= spots.Count) ;
                else
                {
                    Console.WriteLine("Invalid input you will be returned to the main menu");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

                if (spotIndex <= spots.Count && spotIndex >= 1)
                {
                    if (Car.IsAvailableSpot(spots, spotIndex))
                    {
                        Car.Move(spots, spotIndex, regNumber, i);
                        Console.WriteLine($"Your Car was moved to spot number {spotIndex}");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("This was an invalid choice you will be returned to the main menu");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    return;
                }
            }
            if (vehicleChoice == 2)
            { 
                for (i = 1; i < spots.Count; i++)
                {
                    var currentSpot = spots[i];

                    if (currentSpot != null && currentSpot.Any())
                    {
                        var Mcmove = currentSpot.FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Motorcycle);

                        if (Mcmove != null)
                        {
                            Console.Write($"Your Motorcycle was found in spot {i}, which spot would you like to move to? Spot: ");
                            break;
                        }
                    }
                    if (i == spots.Count - 1)
                    {
                        Console.WriteLine("A Motorcycle with this Regnumber was not found you will be returned to the main menu");
                        Console.ReadKey(true);
                        Console.Clear();
                        return;
                    }
                }

                int spotIndex;
                if (int.TryParse(Console.ReadLine(), out spotIndex) && spotIndex >= 1 && spotIndex <= spots.Count) ;
                else
                {
                    Console.WriteLine("Invalid input you will be returned to the main menu");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

                if (spotIndex <= spots.Count && spotIndex >= 1)
                {
                    if (Mc.IsAvailableSpot(spots, spotIndex))
                    {
                        Mc.Move(spots, spotIndex, regNumber, i);
                        Console.WriteLine($"Your Motorcycle was moved to spot number {spotIndex}");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("This was an invalid choice you will be returned to the main menu");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    return;
                }
            }
            if (vehicleChoice == 3)
            {
                for (i = 1; i < spots.Count; i++)
                {
                    var currentSpot = spots[i];

                    if (currentSpot != null && currentSpot.Any())
                    {
                        var Bikemove = currentSpot.FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bike);

                        if (Bikemove != null)
                        {
                            Console.Write($"Your Bike was found in spot {i}, which spot would you like to move to? Spot:  ");
                            break;
                        }
                    }
                    if (i == spots.Count - 1)
                    {
                        Console.WriteLine("A Bike with this Regnumber was not found you will be returned to the main menu");
                        Console.ReadKey(true);
                        Console.Clear();
                        return;
                    }
                }

                int spotIndex;
                if (int.TryParse(Console.ReadLine(), out spotIndex) && spotIndex >= 1 && spotIndex <= spots.Count);
                else
                {
                    Console.WriteLine("Invalid input you will be returned to the main menu");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

                if (spotIndex <= spots.Count && spotIndex >= 1)
                {
                    if (Bike.IsAvailableSpot(spots, spotIndex))
                    {
                        Bike.Move(spots, spotIndex, regNumber, i);
                        Console.WriteLine($"Your Bike was moved to spot number {spotIndex}");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("This was an invalid choice you will be returned to the main menu");
                        Console.ReadKey(true);
                        Console.Clear();
                       
                    }
                    return;

                }
            }
            if (vehicleChoice == 4)
            {
                for (i = 1; i < spots.Count; i++)
                {
                    var currentSpot = spots[i];

                    if (currentSpot != null && currentSpot.Any())
                    {
                        var Busmove = currentSpot.FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);

                        if (Busmove != null)
                        {
                            Console.Write($"Your Bus was found in spots {i}, {i + 1}, {i + 2}, {i + 3}, which starting spot would you like to move to? Make sure that there are 4 empty spots behind it. Spot: ");
                            break;
                        }
                    }
                    if (i == spots.Count - 1)
                    {
                        Console.WriteLine("A Bus with this Regnumber was not found you will be returned to the main menu");
                        Console.ReadKey(true);
                        Console.Clear();
                        return;
                    }
                }

                int spotIndex;
                if (int.TryParse(Console.ReadLine(), out spotIndex) && spotIndex >= 1 && spotIndex <= spots.Count) ;
                else
                {
                    Console.WriteLine("Invalid input you will be returned to the main menu");
                    Console.ReadKey(true);
                    Console.Clear();
                    return;
                }

                if (spotIndex <= spots.Count && spotIndex >= 1)
                {
                    if (Bus.IsAvailableSpot(spots, spotIndex))
                    {
                        Bus.Move(spots, spotIndex, regNumber, i);
                        Console.WriteLine($"Your Bus was moved to spots {spotIndex}, {spotIndex + 1}, {spotIndex + 2}, {spotIndex + 3}");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    else
                    {
                        Console.WriteLine("This was an invalid choice you will be returned to the main menu");
                        Console.ReadKey(true);
                        Console.Clear();
                    }
                    return;
                }
            }
        }
    }
}
