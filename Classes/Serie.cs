namespace DIO.Series //.Classes
{ 
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        public bool Excluded { get; private set; }
        
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Excluded = false;
        }
        
        
        public override string ToString()
        {
            string result = "";
            result += "Genre: " + this.Genre + "\n";
            result += "Title: " + this.Title + "\n";
            result += "Description: " + this.Description + "\n";
            result += "Debut year: " + this.Year + "\n";
            return result;
        }
        
        public string GetTitle()
        {
            return this.Title;
        }
        
        public int GetId()
        {
            return this.Id;
        }

        public void Exclude()
        {
            this.Excluded = true;
        }
    }
}