using VillageOfTesting;

namespace Tests;

public class DayFunctionTest
{
    [Fact]
    public void DayfunctionCalledWithNoWorkers()
    {
        //Given
        var village = new Village();
        
        //When
        village.Day();
        
        //Then
        int foodQty = village.FoodQty;
        int expectedFoodQty = 10;

        int NumberOfWorkers = village.workersList.Count;
        int expectedNumberOfWorkers = 0;
        Assert.Equal(expectedFoodQty, foodQty);
        Assert.Equal(expectedNumberOfWorkers, NumberOfWorkers);
    }

    [Fact]
    public void DayfunctionCalledWithThreeWorkers()
    {
        //Given
        var village = new Village();
        var oli = new Workers("oli", "wood collector");
        var rahman = new Workers("rahman", "wood collector");
        var shah = new Workers("shah", "wood collector");
        
        village.AddWorker(oli);
        village.AddWorker(rahman);
        village.AddWorker(shah);
        
        //When
        village.Day();
        
        //Then
        int expectedFoodQty = 7;
        int actual = village.FoodQty;
        Assert.Equal(expectedFoodQty, actual);
        
        int expectedWoodQty = 3;
        int actualWoodQty = village.WoodQty;
        Assert.Equal(expectedWoodQty, actualWoodQty);
    }

    [Fact]
    public void RunDayWithoutEnoughFood()
    {
        //Given
        Village village = new Village();
        village.FoodQty = 0;
        var oli = new Workers("oli", "wood collector");
        village.AddWorker(oli);
        
        //When
        village.Day();
        
        //Then
        bool expectedIsHungry = true;
        bool actualIsHungry = oli.IsHungry;

        Assert.Equal(expectedIsHungry, actualIsHungry);

    }
    
}