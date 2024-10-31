using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Hello__world_Prague_parking_v3._0
{
    public static class Json
    {
        public static List<List<ParkingSpot>> spots = InitializeParkingStructure();
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static List<List<ParkingSpot>> InitializeParkingStructure()                                   // Initializes the parking structure with 101 spots, each as an empty list
        {
            var parkingSpots = new List<List<ParkingSpot>>(new List<ParkingSpot>[101]);                // 1 list instance
            for (int i = 0; i < 101; i++)
            {
                parkingSpots[i] = new List<ParkingSpot>();                                              // makes a nested list with the nested being called parkingspot
            }
            return parkingSpots;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       public static void SaveToJson(List<List<ParkingSpot>> spots, string filePath)                   // Saves parking spots to a JSON file
       {
            var flatList = new List<ParkingSpot>();                                                     // maipulerar nested list så att json kan spara all info och behålla data i nested listor 

            for (int i = 0; i < spots.Count; i++)
            {
                if (spots[i] != null)                                                            //går egenom varje index av listan och sparar individuellt readall va inte tillräckligt detalierat
                {
                    foreach (var spot in spots[i])
                    {
                        spot.SpotIndex = i;
                        flatList.Add(spot);                                                             // saves all nested list with index point to find easier when d 
                    }
                }
            }

            string jsonString = JsonSerializer.Serialize(flatList);                                               // samma som det gamla
            File.WriteAllText(filePath, jsonString);
            AnsiConsole.MarkupLine("[green]Parking spots saved successfully.[/]");
       }
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        public static List<List<ParkingSpot>> LoadFromJson(string filePath)                                          // Loads parking spots from a JSON file
        {
            if (!File.Exists(filePath))
            {
                AnsiConsole.MarkupLine("[yellow]File not found. Starting with a new parking lot.[/]");
                return InitializeParkingStructure();                                                          // goes through and makes new 
            }

            string jsonString = File.ReadAllText(filePath);
            var flatList = JsonSerializer.Deserialize<List<ParkingSpot>>(jsonString);

            int maxSpotIndex = 100;

            foreach (var spot in flatList)                                                                  // lägger tillbaka individuell index till slut då KAN DET INTE BLI FEL!!!!!
            {
                if (spot.SpotIndex > maxSpotIndex)
                {
                    maxSpotIndex = spot.SpotIndex;
                }
            }
            var spots = new List<List<ParkingSpot>>(new List<ParkingSpot>[maxSpotIndex + 1]);
            for (int i = 0; i <= maxSpotIndex; i++)
            {
                spots[i] = new List<ParkingSpot>();
            }
            foreach (var spot in flatList)
            {
                spots[spot.SpotIndex].Add(spot);
            }
            return spots;
        }
    }
}
