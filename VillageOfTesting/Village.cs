namespace VillageOfTesting;

public class Village
{
    private int foodQty;
    private int woodQty;
    private int metalQty; 
    private int ageOfVillage;
    public int WoodPerDay = 1; 
    public int MetalPerDay = 1;
    public int FoodPerDay = 5;
    public List<Building> buildingsList;
    public List<Workers> workersList;
    public List<Building> onGoingProjectList;
    

    public Village()
    {
        foodQty = 10;
        woodQty = 0;
        metalQty = 0;
        ageOfVillage = 0;
        buildingsList = new List<Building>();
        onGoingProjectList = new List<Building>();
        workersList = new List<Workers>();
        buildingsList.Add(new Building("house", 5,0,3));
        buildingsList.Add(new Building("house", 5,0,3));
        buildingsList.Add(new Building("house", 5,0,3));

    }

    public int FoodQty
    {
        get => foodQty;
        set => foodQty = value;
    }

    public int WoodQty
    {
        get => woodQty;
        set => woodQty = value;
    }

    public int MetalQty
    {
        get => metalQty;
        set => metalQty = value;
    }

    public int AgeOfVillage
    {
        get => ageOfVillage;
        set => ageOfVillage = value;
    }


    public void AddWorker(Workers worker)
    {
        double numOfHouses = buildingsList.Count(building => building.TypeOfBuilding == "house");
        double numOfWorkers = workersList.Count + 1;

        for (int i = 0; i < numOfWorkers; i++)
            if (numOfWorkers > 6 && numOfWorkers / numOfHouses > 2)
            {
                Console.WriteLine("There are not enough houses to house another worker");
                return;
            }

        workersList.Add(worker);
    }

    public void AddWood()
    {
        woodQty += WoodPerDay;
    }


    public void AddMetal()
    {
        
        metalQty+= MetalPerDay;
                
    }

    public void AddFood()
    {
        foodQty+=FoodPerDay;
    }


    public void Build()
    {
        var currentProject = onGoingProjectList[0];
        currentProject.ElapsedWorkDays++;

        if (currentProject.ElapsedWorkDays >= currentProject.LengthOfProject)
        {
            currentProject.IsComplete=true;
            buildingsList.Add(currentProject);
            onGoingProjectList.Remove(currentProject);
            
            Console.WriteLine($"{currentProject.TypeOfBuilding} is complete!");

            switch (currentProject.TypeOfBuilding)
            {
                case "woodmill":
                    WoodPerDay += 2;
                    break;
                case "quarry":
                    MetalPerDay += 2;
                    break;
                case "farm":
                    FoodPerDay += 10;
                    break;
                case "castle":
                    Console.WriteLine("You have completed your castle. Well done. You took " + AgeOfVillage + " days to build your village");
                    break;
            }
        }
    }

    public void BuryDead()
    {
        for (int i = 0; i < workersList.Count; i++)
        {
            Workers worker = workersList[i];
            
            if (!worker.IsAlive) {
                workersList.Remove(worker);
            }

        }
    }

    public void AddProject(Building project)
    {
        if (WoodQty >= project.WoodRequired && MetalQty >= project.MetalRequired)
        {

            WoodQty -= project.WoodRequired;
            MetalQty -= project.MetalRequired;
            onGoingProjectList.Add(project);
        }
    }

    public void AddBuilding(Building building)
    {
        for (int i = 0; i < onGoingProjectList.Count; i++)

            if (building.ElapsedWorkDays >= building.LengthOfProject)
            {

                building.IsComplete = true;
                buildingsList.Add(building);
                onGoingProjectList.Remove(building);
            }
    }

    public void FeedWorkers()
    {
        foreach (var worker in workersList)
        {
            
            if (FoodQty <= 0)
            {
                worker.IsHungry = true;
                worker.DaysHungry++;

                if (worker.DaysHungry >= 40)
                {
                    worker.IsAlive = false;
                    Console.WriteLine($"{worker.Name} is dead. And the dead cannot be fed.");
                }
            }
            else
            {
                FoodQty--;
                worker.IsHungry = false;
                worker.DaysHungry = 0;
            }

        }
    }

    public void Day()
    {
        AgeOfVillage++;
        FeedWorkers();
        
        foreach (Workers worker in workersList) {
            worker.DoWork(this);
        }

        BuryDead();
    }
}