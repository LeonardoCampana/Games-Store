using System.ComponentModel.DataAnnotations.Schema;

namespace GamesStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string PathImage { get; set; }
        public int Discount { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
