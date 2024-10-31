using Hello__world_Prague_parking_v3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_VG
{
    public class Bike : ParkingSpot
    {
        public Bike(string regNumber) : base(regNumber, VehicleType.Bike) { }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //FindAvalibleSpotBike
        public static int FindAvailableSpot(List<List<ParkingSpot>> spots)              //method to find an available spot for a motorcycle
        {
            return ParkingSpotPointCalculator.CalculateTotalPointsBike(spots);
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //MoveBike
        public static void Move(List<List<ParkingSpot>> parkingSpots, int spotIndex, string regNumber, int i)
        {
            ParkingSpot newBike = new ParkingSpot(regNumber, VehicleType.Bike, spotIndex);
            parkingSpots[spotIndex].Add(newBike);

            var BikeToRemove = parkingSpots[i].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bike);

            if (BikeToRemove != null)
            {
                parkingSpots[i].Remove(BikeToRemove);
            }
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static bool IsAvailableSpot(List<List<ParkingSpot>> spots, int spotIndex)
        {
            int totalPoints = 0;
            List<ParkingSpot> spotList = spots[spotIndex];

            if (spotList == null || spotList.Count == 0)
            {
                return true;  // Return the index of the null or empty list
            }

            // Loop through each ParkingSpot in the inner list using a for loop
            for (int j = 0; j < spotList.Count; j++)
            {
                ParkingSpot spot = spotList[j];

                totalPoints += spot.Points;
                if ((j == spotList.Count - 1) && (totalPoints <= 3))
                {
                    return true;
                }
            }
            return false;
        }
    }





}
