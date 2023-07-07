using VillageOfTesting;

namespace Tests;

public class AddProjectTest
{
    [Fact]
    public void AddBuildingWithSufficientResources()
    {
        //Given
        Village village = new Village();
        village.WoodQty = 50;
        village.FoodQty = 50;
        village.MetalQty = 50;

        //When
        Building building = new Building("farm", 5, 2, 5);
        village.AddProject(building);

        //Then
        int ExpectedNumberOfProjects = 1;
        int ActualNumberOfProjects = village.onGoingProjectList.Count();
        
        Assert.Single(village.onGoingProjectList);

        int ExpectedWoodQuantity = 45;
        int ActualWoodQuantity = village.WoodQty;
        
        Assert.Equal(ExpectedWoodQuantity, ActualWoodQuantity);

        int ExpectedMetalQuantity = 48;
        int ActualMetalQuantity = village.MetalQty;
        
        Assert.Equal(ExpectedWoodQuantity, ActualWoodQuantity);

    } 
    
    [Fact]
    public void FailToAddBuildingDueToInSufficientResources()
    {
        //Given
        Village village = new Village();
        village.WoodQty = 0;
        village.FoodQty = 0;
        village.MetalQty = 0;

        //When
        Building building = new Building("farm", 5, 2, 5);
        village.AddProject(building);

        //Then
            int ExpectedNumberOfProjects = 0;
            int ActualNumberOfProjects = village.onGoingProjectList.Count();
            
            Assert.Equal(ExpectedNumberOfProjects, ActualNumberOfProjects);
    }

    [Fact]
    public void OnePieceOfWoodAddedToVillagePerDayBeforeWoodmillIsCompleteAndThreeAfterWoodmillIsComplete()
    {
        // Given
        var village = new Village();
        village.WoodQty=5;
        village.MetalQty = 5;
        
        var woodmill = new Building("woodmill", 5, 5, 5);
        village.AddProject(woodmill);

        village.AddWorker(new Workers("oli", "wood collector"));
        village.AddWorker(new Workers("rahman", "builder"));

        // When
        for (int i = 1; i < woodmill.LengthOfProject; i++) 
        {
            village.Day();
        }

        // Then
        Assert.Equal(4, village.WoodQty);
        Assert.Equal(4, woodmill.ElapsedWorkDays);
        Assert.False(woodmill.IsComplete);

        // When
        village.Day(); 
        var actualWoodPerDayAfterWoodMillIsComplete = village.WoodPerDay;
        var expectedWoodPerDayAferWoodmillIsComplete = 3;

        // Then
        Assert.True(woodmill.IsComplete);
        Assert.Equal(expectedWoodPerDayAferWoodmillIsComplete, actualWoodPerDayAfterWoodMillIsComplete);
    }
    [Fact]
    public void FiveItemsOfFoodAddedToVillagePerDayBeforeFarmIsCompleteAndTenAfterFarmIsComplete()
    {
        // Given
        var village = new Village();
        village.MetalQty = 2;
        village.WoodQty = 5;
        
        var farm = new Building("farm", 5, 2, 5);
        village.AddProject(farm);

        village.AddWorker(new Workers("oli", "food collector"));
        village.AddWorker(new Workers("rahman", "builder"));

        // When
        for (int i = 1; i < farm.LengthOfProject; i++) // run 4 days
        {
            village.Day();
        }

        // Then
        Assert.Equal(5, village.FoodPerDay);
        Assert.Equal(4, village.AgeOfVillage);
        Assert.False(farm.IsComplete);

        // When
        village.Day();
        var foodPerDayAfterFarmFinished = village.FoodPerDay;

        // Then
        Assert.Equal(15, foodPerDayAfterFarmFinished);
        Assert.True(farm.IsComplete);
    }
    
    [Fact]
    public void OnePieceOfMetalAddedToVillagePerDayBeforeQuarryIsCompleteAndThreeAfterQuarryIsComplete()
    {
        // Given
        var village = new Village();
        village.MetalQty = 5;
        village.WoodQty = 3;
        village.FoodQty = 100;
        
        var quarry = new Building("quarry", 3, 5, 7);
        village.AddProject(quarry);

        village.AddWorker(new Workers("oli", "metal collector"));
        village.AddWorker(new Workers("rahman", "builder"));

        // When
        for (int i = 1; i < quarry.LengthOfProject; i++) 
        {
            village.Day();
        }

        // Then
        var expectedMetalQty = 6;
        var actualMetalQty = village.MetalQty;
        Assert.Equal(expectedMetalQty, actualMetalQty);
        
        var expectedDaysElapsed = 6;
        var actualDaysElapsed = quarry.ElapsedWorkDays;
        Assert.Equal(expectedDaysElapsed, actualDaysElapsed);
        
        Assert.False(quarry.IsComplete);
              
        // When
        village.Day(); 
        var actualMetalPerDayAfterQuarryFinished = village.MetalPerDay;
        var expectedMetalPerDayAfterFarmIsComplete = 3;

        // Then
        Assert.True(quarry.IsComplete);
        Assert.Equal(expectedMetalPerDayAfterFarmIsComplete, actualMetalPerDayAfterQuarryFinished);
    }
    
    [Fact]
    public void BuildAHouse()
    {
        // Given
        var village = new Village();
        village.WoodQty = 100;
        village.MetalQty = 100;
        var oli = new Workers("Oli", "builder");
        var house = new Building("house", 3, 5, 3);

        // When
        village.AddProject(house);
        village.AddWorker(oli);

        for (int i = 1; i <= house.LengthOfProject; i++)
        {
            village.Day();
        }

        // Then
        Assert.Contains(house, village.buildingsList); 
    }
}