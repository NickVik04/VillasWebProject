namespace VillasWebProject.Models
{

    public class Villa
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int occupancy { get; set; }
        public int sqft { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}