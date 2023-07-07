using VillageOfTesting;

namespace Tests;

public class AddWorkerTest
{
    [Fact]
    public void AddOneWorkerSuccessfully()
    {
        //Given
        var village = new Village();
        var oli = new Workers("oli", "wood collector");
        
        //When
        village.AddWorker(oli);
        
        
        //Then
        int expected = 1;
        int actual = village.workersList.Count;
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void AddTwoWorkersSuccessfully()
    {
        //Given
        var village = new Village();
        var oli = new Workers("oli", "wood collector");
        var rahman = new Workers("rahman", "wood collector");
        //When
        village.AddWorker(oli);
        village.AddWorker(rahman);
        
        
        //Then
        int expected = 2;
        int actual = village.workersList.Count;
        Assert.Equal(expected, actual);
    }
    
    [Fact]
    public void AddThreeWorkersSuccessfully()
    {
        //Given
        var village = new Village();
        var oli = new Workers("oli", "wood collector");
        var rahman = new Workers("rahman", "wood collector");
        var shah = new Workers("shah", "wood collector");
        
        //When
        village.AddWorker(oli);
        village.AddWorker(rahman);
        village.AddWorker(shah);
        
        //Then
        int expected = 3;
        int actual = village.workersList.Count;
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void AddingSevenWorkersButCanOnlyAddSixDueToInsufficientHousing()
    {
        //Given
        var village = new Village();
        var oli = new Workers("oli", "wood collector");
        var rahman = new Workers("rahman", "wood collector");
        var shah = new Workers("shah", "wood collector");
        var elina = new Workers("elina", "wood collector");
        var cecilia = new Workers("cecilia", "wood collector");
        var benson = new Workers("benson", "wood collector");
        var penny = new Workers("penny", "wood collector");

        //When
        village.AddWorker(oli);
        village.AddWorker(rahman);
        village.AddWorker(shah);
        village.AddWorker(elina);
        village.AddWorker(cecilia);
        village.AddWorker(benson);
        village.AddWorker(penny);

        //Then
        int expected = 6;
        int actual = village.workersList.Count;
        Assert.Equal(expected, actual);
    }
    [Fact]
    public void AddWorkerAndCallDayFunction()
    {
        //given
        Village village = new Village();
        var oli = new Workers("oli", "food collector");
        village.AddWorker(oli);

        //when
        village.Day();

        //Then
        int actualFoodQty = village.FoodQty;
        int NumberOfWorkers = village.workersList.Count;
        
        Assert.Equal(14, actualFoodQty);
        Assert.Equal(1, NumberOfWorkers);

    }
}