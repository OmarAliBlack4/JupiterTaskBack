namespace JupiterTask.Entites
{
    public class Score
    {
        public int Id { get; set; }
        public int Value { get; set; }

        // Foreign Key
        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
