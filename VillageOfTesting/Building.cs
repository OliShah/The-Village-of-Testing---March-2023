namespace VillageOfTesting;

public class Building
{
    private bool isComplete;
    private int lengthOfProject;
    private int elapsedWorkDays;
    private int woodRequired; 
    private int metalRequired;
    private string typeOfBuilding;

    public Building( string typeOfBuilding, int woodRequired, int metalRequired, 
        int lengthOfProject)
    {
        this.typeOfBuilding = typeOfBuilding;
        isComplete = false;
        this.lengthOfProject = lengthOfProject;
        elapsedWorkDays = 0;
        this.woodRequired = woodRequired;
        this.metalRequired = metalRequired;     
    }

    public string TypeOfBuilding 
    { 
        get => typeOfBuilding;
        set => typeOfBuilding = value;
    }
    
    public int LengthOfProject 
    {
        get => lengthOfProject; 
        set => lengthOfProject = value; 
    }

    public int ElapsedWorkDays 
    { 
        get => elapsedWorkDays;
        set => elapsedWorkDays = value;
    }

    public int WoodRequired 
    { 
        get => woodRequired;  
        set => woodRequired = value;
    }

    public int MetalRequired 
    { 
        get => metalRequired; 
        set=> metalRequired = value;
    }
    
    public bool IsComplete
    {
        get => isComplete;
        set => isComplete = value;
    }

   // public void IncrementElapsedWorkDays()
    //{
      //  elapsedWorkDays++;
    //}
}