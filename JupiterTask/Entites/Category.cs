namespace JupiterTask.Entites
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        // Navigation Property
        public ICollection<Team> Teams { get; set; }
    }
}
