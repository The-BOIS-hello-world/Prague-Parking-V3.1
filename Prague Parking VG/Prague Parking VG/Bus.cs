using Hello__world_Prague_parking_v3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_VG
{
    public class Bus : ParkingSpot
    {
        public Bus(string regNumber) : base(regNumber, VehicleType.Bus) { }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //FindAvalibleSpotBus
        public static int FindAvailableSpot(List<List<ParkingSpot>> spots)       //method to find an available spot for a motorcycle
        {
            return ParkingSpotPointCalculator.CalculateTotalPointsBus(spots);

        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        //IsAvailableSpotBus
        public static bool IsAvailableSpot(List<List<ParkingSpot>> parkingSpots, int spotIndex)
        {
            if (parkingSpots[spotIndex].Count == 0 && parkingSpots[spotIndex + 1].Count == 0 && parkingSpots[spotIndex + 2].Count == 0 && parkingSpots[spotIndex + 3].Count == 0 && (spotIndex + 3) < 51)
            {
                return true;
            }
            return false;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        //MoveBus
        public static void Move(List<List<ParkingSpot>> parkingSpots, int spotIndex, string regNumber, int i)
        {
            ParkingSpot newBus = new ParkingSpot(regNumber, VehicleType.Bus, spotIndex);
            ParkingSpot newBus1 = new ParkingSpot(regNumber, VehicleType.Bus, spotIndex + 1);
            ParkingSpot newBus2 = new ParkingSpot(regNumber, VehicleType.Bus, spotIndex + 2);
            ParkingSpot newBus3 = new ParkingSpot(regNumber, VehicleType.Bus, spotIndex + 3);

            parkingSpots[spotIndex].Add(newBus);
            parkingSpots[spotIndex + 1].Add(newBus1);
            parkingSpots[spotIndex + 2].Add(newBus2);
            parkingSpots[spotIndex + 3].Add(newBus3);

            var BusToRemove = parkingSpots[i].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);
            var BusToRemove1 = parkingSpots[i + 1].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);
            var BusToRemove2 = parkingSpots[i + 2].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);
            var BusToRemove3 = parkingSpots[i + 3].FirstOrDefault(vehicle => vehicle.RegNumber == regNumber && vehicle.Type == VehicleType.Bus);

            if (BusToRemove != null)
            {
                parkingSpots[i].Remove(BusToRemove);
                parkingSpots[i + 1].Remove(BusToRemove1);
                parkingSpots[i + 2].Remove(BusToRemove2);
                parkingSpots[i + 3].Remove(BusToRemove3);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------------
    }
}
