using Hello__world_Prague_parking_v3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prague_Parking_VG
{
    internal class ParkingSpotPointCalculator
    {// Bike
        public static int CalculateTotalPointsBike(List<List<ParkingSpot>> spots)
        {
            for (int i = 1; i < spots.Count; i++)
            {
                int totalPoints = 0;
                List<ParkingSpot> spotList = spots[i];

                if (spotList == null || spotList.Count == 0)
                {
                    return i;  // Return the index of the null or empty list
                }

                // Loop through each ParkingSpot in the inner list using a for loop
                for (int j = 0; j < spotList.Count; j++)
                {
                    ParkingSpot spot = spotList[j];
                   
                    totalPoints += spot.Points;
                    if ((j == spotList.Count - 1) && (totalPoints <= 3))
                    {
                        return i;
                    }
                    if (totalPoints == 4)
                    {
                        totalPoints = 0;
                        break;
                    }
                }
            }
            return -1;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Mc
        public static int CalculateTotalPointsMc(List<List<ParkingSpot>> spots)
        {
            for (int i = 1; i < spots.Count; i++)
            {
                int totalPoints = 0;
                List<ParkingSpot> spotList = spots[i];

                if (spotList == null || spotList.Count == 0)
                {
                    return i;  // Return the index of the null or empty list
                }

                // Loop through each ParkingSpot in the inner list using a for loop
                for (int j = 0; j < spotList.Count; j++)
                {
                    ParkingSpot spot = spotList[j];

                    totalPoints += spot.Points;
                    if ((j == spotList.Count - 1) && (totalPoints <= 2) && j != 0)
                    {
                        return i;
                    }
                    if (totalPoints == 4)
                    {
                        totalPoints = 0;
                        break;
                    }
                }
            }
            return -1;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Bus
        public static int CalculateTotalPointsBus(List<List<ParkingSpot>> spots)
        {
            int totalPoints = 0;

            for (int i = 1; i < 51; i++)
            {
                List<ParkingSpot> spotList = spots[i];
                List<ParkingSpot> spotList1 = spots[i + 1];
                List<ParkingSpot> spotList2 = spots[i + 2];
                List<ParkingSpot> spotList3 = spots[i + 3];

                if(i == 47 || i == 48 || i == 49 || i == 50)
                {
                    return -1;
                }

                if ((spotList.Count == 0) && (spotList1.Count == 0) && (spotList2.Count == 0) && (spotList3.Count == 0))
                {
                    return i;  // Return the index of the null or empty list
                }
            }
            return -1;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        // Car
        public static int CalculateTotalPointsCar(List<List<ParkingSpot>> spots)
        {
            for (int i = 1; i < spots.Count; i++)
            {
                List<ParkingSpot> spotList = spots[i];

                if (spotList == null || spotList.Count == 0)
                {
                    return i;  // Return the index of the null or empty list
                }
            }
                return -1;
        }
    }
}
