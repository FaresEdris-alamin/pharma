
namespace pharmacy.Model
{
    public class Medicine
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public int AdminId { get; set; }

    }

}