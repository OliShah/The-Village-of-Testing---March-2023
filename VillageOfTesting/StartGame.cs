namespace VillageOfTesting;

public class StartGame
{
    Village village = new Village();

    public void Run()
    {
        var running = true;
        Console.WriteLine();
        Console.WriteLine("This is your village. Make it thrive.");
        Console.WriteLine();

        while (running)
        {
            village.Day();
            Console.WriteLine("Choose from the following options?");
            Console.WriteLine("1. Add a worker");
            Console.WriteLine("2. Add a project");
            Console.WriteLine("3. Bury the deceased");
            Console.WriteLine("4. Check on your resources");
            Console.WriteLine("5. See your completed buildings list");
            Console.WriteLine("6. Check on your ongoing buildings");
            Console.WriteLine("7. See your list of workers");
            Console.WriteLine("8. Quit game");
            Console.WriteLine("9. Count the days");
            Console.WriteLine();

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    AddWorker();
                    Console.WriteLine();
                    break;
                case "2":
                    AddProject();
                    Console.WriteLine();
                    break;
                case "3":
                    Bury();
                    if (village.workersList.Count == 0)
                    {
                        running = false;
                        Console.WriteLine("Game Over.");
                    }
                    Console.WriteLine();
                    break;
                case "4":
                    CheckOnResources();
                    Console.WriteLine();
                    break;
                case "5":
                    ListCompleteBuildings();
                    Console.WriteLine();
                    break;
                case "6":
                    ListIncompleteBuildings();
                    Console.WriteLine();
                    break;
                case "7":
                    PrintWorkers();
                    Console.WriteLine();
                    break;
                case "8":
                    running = false;
                    Console.WriteLine("Game Over.");
                    break;
                case "9":
                    CountTheDays();
                    Console.WriteLine();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    Console.WriteLine();
                    break;
            }
        }
    }

    private void PrintWorkers()
    {
        var workersList = village.workersList;
        if (workersList.Count == 0)
        {
            Console.WriteLine("There are no workers available.");
            Console.WriteLine();
        }
        else
        {
            foreach (var worker in workersList)
            {
                Console.WriteLine($"Name: {worker.Name}, Occupation: {worker.Occupation}");
                Console.WriteLine();
            }
        }
    }

    private void ListIncompleteBuildings()
    {
        var unfinishedBuildings = village.onGoingProjectList;
        if (unfinishedBuildings.Count == 0)
        {
            Console.WriteLine("You have no ongoing projects.");
            Console.WriteLine();
        }
        else
        {
            foreach (var building in unfinishedBuildings)
            {
                Console.WriteLine(building.TypeOfBuilding);
                Console.WriteLine();
            }  
        }
    }

    private void ListCompleteBuildings()
    {
        var buildings = village.buildingsList;
        if (buildings.Count == 0)
        {
            Console.WriteLine("You have no buildings.");
            Console.WriteLine();
        }
        else
        {
            foreach (var building in buildings)
            {
                Console.WriteLine(building.TypeOfBuilding);
                Console.WriteLine();
            }
        }
    }

    private void CheckOnResources()
    {
        var food = village.FoodQty;
        var wood = village.WoodQty;
        var metal = village.MetalQty;
        Console.WriteLine($"Food Quantity: {food}, Wood Quantity: {wood}, Metal quantity: {metal}");
        Console.WriteLine();
    }

    private void Bury()
    { 
        village.BuryDead();
    }

    private void AddProject()
    {
        Console.WriteLine("What project do you want to add? House, woodmill, quarry, farm, castle.");
        Console.WriteLine();
        
        var buildingName = Console.ReadLine();
        Building building = null;
        switch (buildingName.ToLower())
        {
            case "house":
                building = new Building("house", 5, 0, 3);
                break;
            case "woodmill":
                building = new Building("woodmill", 5, 1, 5);
                break;
            case "quarry":
                building = new Building("quarry", 3, 5, 7);
                break;
            case "farm":
                building = new Building("farm", 5, 5, 5);
                break;
            case "castle":
                building = new Building("castle", 50, 50, 50);
                break;
            default:
                Console.WriteLine("Invalid Entry. Try again.");
                Console.WriteLine();
                break;
        }

        village.AddProject(building);
    }

    private void CountTheDays()
    {
        Console.WriteLine(village.AgeOfVillage);
    }

    private void AddWorker()
    {
        Console.WriteLine("Give your worker a name:");

        var name = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Assign your worker a job: wood collector, metal collector, builder or food collector?");

        var occupation = Console.ReadLine();
        if (occupation.ToLower() == "wood collector" ||
            occupation.ToLower() == "metal collector" ||
            occupation.ToLower() == "builder" ||
            occupation.ToLower() == "food collector")
        {
            var worker = new Workers(name, occupation);
            village.AddWorker(worker);
        }
        else
        {
            Console.WriteLine("Invalid entry. Try again.");
            Console.WriteLine();
        }
    }
}