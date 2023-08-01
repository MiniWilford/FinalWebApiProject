public class Movies
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Director {get; set;}
    public int Year {get; set;} 
}

public class Students
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public DateTime? DateoOfBirth { get; set; }
    public string StudentProgram { get; set; }
    public int StudentYear { get; set; }
}

public class Food
{
    public int FoodId { get; set; }
    public string FoodName { get; set;}
    public string FoodDescription { get; set; }
    public string FoodType { get; set;}
}