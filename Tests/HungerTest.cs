using VillageOfTesting;

namespace Tests;

public class HungerTest
{
    [Fact]
    public void WorkerDoesNotCollectMetalWhenHungry()
    {
        // Given
        var oli = new Workers("oli", "metal collector");
        var village = new Village();
        village.AddWorker(oli);

        // When
        village.FoodQty = 0; 
        village.Day();

        // Then
        Assert.True(oli.IsHungry);

    }
    [Fact]
    public void DeadWorkerAfterFortyDaysOfHunger()
    {
        // Given
        var oli = new Workers("oli", "wood collector");
        oli.DaysHungry = 39;

        var village = new Village();
        village.FoodQty = 0;
        village.AddWorker(oli);

        // When
        village.Day();

        // Then 
        Assert.False(oli.IsAlive);
    }
    [Fact]
    public void UnableToFeedDeadWorker()
    {
        // Given
        var oli = new Workers("oli", "wood collector");
        oli.DaysHungry = 39;

 
        var village = new Village();
        village.FoodQty = 0;
        village.AddWorker(oli);

        // When
        village.Day();
        village.FoodQty = 10;
        village.Day();
        var actual = village.FoodQty;
        

        // Then 
        Assert.Equal(10, actual); 
    }
    
    [Fact]
    public void BuryTheDeadAndRemoveFromWorkersList()
    {
        // Given
        var village = new Village();
        var oli = new Workers("oli", "wood collector");
        var shah = new Workers("shah", "food collector");
        village.AddWorker(oli);
        village.AddWorker(shah);
        village.FoodQty = 0;
        // When
        oli.DaysHungry = 39;
        village.Day();

        village.BuryDead();
        var actual = village.workersList.Count;

        // Then
        Assert.False(oli.IsAlive);
        Assert.Equal(1, actual);
    }
}