using System.ComponentModel.DataAnnotations;

namespace API_Crud_Log.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
