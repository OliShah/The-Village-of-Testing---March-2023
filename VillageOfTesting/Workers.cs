namespace VillageOfTesting;

public class Workers
{
    private delegate void WorkFunction(Village village);

    private string occupation;
    private string name;
    private bool isHungry;
    private bool isAlive;
    private int daysHungry;
    private WorkFunction workFunction;


    public Workers(string name, string occupation)
    {
        this.name = name;
        this.occupation = occupation;
        isHungry = true;
        isAlive = true;
        daysHungry = 0;
        
        switch (occupation)
        {
            case "wood collector":
                workFunction = village => village.AddWood();
                break;
            case "metal collector":
                workFunction = village => village.AddMetal();
                break;
            case "food collector":
                workFunction = village => village.AddFood();
                break;
            
            case "builder":
                workFunction = village => village.Build();
                break;
            
            default:
                throw new ArgumentException($"Invalid occupation: {occupation}");
        }
        
    }

    public string Name 
    { 
        get => name; 
        set => name = value; 
    }
    
    public string Occupation 
    { 
        get => occupation; 
        set => occupation = value; 
    }
    
    public bool IsHungry 
    { 
        get => isHungry;
        set => isHungry = value;
    }
    
    public int DaysHungry 
    { 
        get => daysHungry; 
        set => daysHungry = value; 
    }
    
    public bool IsAlive 
    { 
        get => isAlive; 
        set => isAlive = value;
    }   
    
    public void DoWork(Village village)
    {
        if (!IsHungry) {
            workFunction(village);
        }
    }

    /*public void IncrementDaysHungry()
    {
        daysHungry++;
        if (daysHungry == 39)
        {
            IsDead();
        }
    }*/

    /*public void IsDead()
    {
        isAlive = false;
    }*/
}