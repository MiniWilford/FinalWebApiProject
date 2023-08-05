//using System.ComponentModel.DataAnnotations;

namespace Main.Model {

    //[Table("Books", SchemaName="dbo")]
    public class Books
    {
        public long ISBN {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}
        public string Genre {get; set;}
        public int Year {get; set;}

    }
}