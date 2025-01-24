namespace JupiterTask.Entites
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Foreign Key
        public int CategoryId { get; set; }
        public Category Category  { get; set; }

        // Navigation Property
        public ICollection<Score> Scores { get; set; }
    }
}
