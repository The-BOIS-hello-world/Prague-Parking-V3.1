using Spectre.Console;
using System.Collections.Generic;


namespace Hello__world_Prague_parking_v3._0
{
    internal class MainMenu
    {
        static void Main(string[] args)
        {
            List<List<ParkingSpot>> spots = Json.InitializeParkingStructure();         // need to call on the json initializeparkingstructure to open up the list filled with "spots"
            ParkingGarage garage = new ParkingGarage(spots);                           // creating a list instance which is updted via spots
            string filePath = " ";
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            AnsiConsole.Write(new FigletText("Welcome to Prague Parking").Centered().Color(Color.Aquamarine1));        // Starting menu with Spectre.Console for New or Existing
            var initialChoice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Choose an option:")
                    .PageSize(3)
                    .AddChoices(new[] { "Open New", "Open Existing", "Exit" }));

            switch (initialChoice)
            {
                case "Open New":
                    AnsiConsole.MarkupLine("[green]Creating a new parking lot.[/]");  // lite fint ba 
                    Console.WriteLine("Where would you loke to save this file: ");
                    filePath = (Console.ReadLine() + ".json");
                    Json.SaveToJson(spots, filePath);
                    break;
                case "Open Existing":
                    AnsiConsole.Write("Please enter file name: ");
                    filePath = (Console.ReadLine() + ".json");                                    //OPens existing json file via the updated parking after initializeparking has uppdated the empy list with the json file
                    spots = Json.LoadFromJson(filePath);
                    garage.UpdateParkingSpots(spots);

                    AnsiConsole.MarkupLine("[green]Existing parking data loaded successfully.[/]");
                    break;
                case "Exit":

                    //
                    AnsiConsole.MarkupLine("[green]Exiting...[/]");

                    return;
            }


            while (true)
            {
                AnsiConsole.Write(new FigletText("Welcome to Prague Parking").Centered().Color(Color.Aquamarine1));         // Main parking management

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("\n")
                        .PageSize(10)
                        .AddChoices(new[]
                        {
                            "Park Vehicle", "Remove Vehicle", "Move Vehicle", "View Parking", "Credits", "Exit"
                        }));

                switch (choice)
                {
                    case "Park Vehicle":
                        CarorMcAdd(spots, filePath);
                        break;
                    case "Remove Vehicle":
                        CarorMcRemove(spots, filePath);
                        break;
                    case "Move Vehicle":                                             // lägga till senare
                        MoveVehicle(spots, filePath);
                        break;
                    case "View Parking":
                        garage.ViewParking();
                        break;
                    case "Credits":
                        garage.AddParkingSpots(spots, filePath);
                        Json.SaveToJson(spots, filePath);

                        break;
                    case "Exit":
                        ExitChoice(spots);
                        Environment.Exit(0);
                        return;
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            static void CarorMcAdd(List<List<ParkingSpot>> spots, string filePath)     //adding a vehicle menu
            {
                VehicleManager vehicleManager = new VehicleManager();       //Instace of VehicleManager Class

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select vehicle type to park:")
                        .PageSize(12)
                        .AddChoices(new[] { "Car", "Motorcycle", "Bike", "Bus", "Return" }));

                switch (choice)
                {
                    case "Car":
                        vehicleManager.AddVehicle(spots, 1);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Motorcycle":
                        vehicleManager.AddVehicle(spots, 2);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Bike":
                        vehicleManager.AddVehicle(spots, 3);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Bus":
                        vehicleManager.AddVehicle(spots, 4);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Return":
                        return;
                }
            }
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            static void CarorMcRemove(List<List<ParkingSpot>> spots, string filePath)     //adding a vehicle menu
            {
                VehicleManager vehicleManager = new VehicleManager();       //Instace of VehicleManager Class

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select vehicle type to park:")
                        .PageSize(12)
                        .AddChoices(new[] { "Car", "Motorcycle", "Bike", "Bus" ,"Return" }));

                switch (choice)
                {
                    case "Car":
                        vehicleManager.RemoveVehicle(spots, 1);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Motorcycle":
                        vehicleManager.RemoveVehicle(spots, 2);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Bike":
                        vehicleManager.RemoveVehicle(spots, 3);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Bus":
                        vehicleManager.RemoveVehicle(spots, 4);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Return":
                        return;
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            static void MoveVehicle(List<List<ParkingSpot>> spots, string filePath)
            {
                VehicleManager vehicleManager = new VehicleManager();

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("Select vehicle type to move:")
                        .PageSize(12)
                        .AddChoices(new[] { "Car", "Motorcycle", "Bike", "Bus", "Return" }));

                switch (choice)
                {
                    case "Car":
                        vehicleManager.MoveVehicle(spots, 1);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Motorcycle":
                        vehicleManager.MoveVehicle(spots, 2);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Bike":
                        vehicleManager.MoveVehicle(spots, 3);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Bus":
                        vehicleManager.MoveVehicle(spots, 4);
                        Json.SaveToJson(spots, filePath);
                        break;
                    case "Return":
                        return;
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            static void ExitChoice(List<List<ParkingSpot>> spots)
            {
                var choice = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                            .Title("Would you like to save this version: ")
                            .PageSize(12)
                            .AddChoices(new[] { "Yes", "No", "Return" }));

                switch (choice)
                {
                    case "Yes":
                        AnsiConsole.Write("Please enter a file name: ");                                        //string filePath = "C:/Users/bas_e/OneDrive/Skrivbord/Prague_Parking.json";
                        string filePath = (Console.ReadLine() + ".json");
                        Json.SaveToJson(spots, filePath);
                        AnsiConsole.MarkupLine("[green]Data saved successfully. Exiting...[/]");
                        Environment.Exit(0);
                        break;
                    case "No":
                        AnsiConsole.Markup("[red] Okej... Bye -.-[/]");
                        Environment.Exit(0);
                        break;
                    case "Return":
                        return;
                }
            }
        }
    }
}

