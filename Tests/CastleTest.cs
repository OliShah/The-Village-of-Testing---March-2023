using VillageOfTesting;
using Xunit.Abstractions;

namespace Tests;

public class CastleTest
{
    private readonly ITestOutputHelper _testOutputHelper;

    public CastleTest(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void BuildACastleTest()
    {
        // Given
        var village = new Village();
        village.WoodQty = 50;
        village.MetalQty = 50;
        village.FoodQty = 50;
        var castle = new Building("castle", 50, 50, 50);
        village.AddProject(castle);

        village.AddWorker(new Workers("oli", "builder"));

        // When
        while (!castle.IsComplete)
        {
            village.Day();
        }

        // Then
        var expectedAgeOfVillage = 50;
        var actualAgeOfVillage = village.AgeOfVillage; 
        Assert.Equal(expectedAgeOfVillage, actualAgeOfVillage);
        Assert.Contains(castle, village.buildingsList);
        
    }
}