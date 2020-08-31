using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Final_Projectt.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxmayın"), StringLength(255, ErrorMessage = "Simvolun uzunluğu 255dən artıq ola bilməz")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxmayın")]

        public decimal Price { get; set; }

        public int? Discount { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxmayın")]

        public int Count { get; set; }
        [Required(ErrorMessage = "Xananı boş buraxmayın"), StringLength(255, ErrorMessage = "Simvolun uzunluğu 255den artıq ola bilməz")]

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }

        public int MarkaCategoryId { get; set; }

        public virtual MarkaCategory MarkaCategory { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public static implicit operator BasketProduct(Product product)
        {
            return new BasketProduct
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Discount = product.Discount,
                Quantity = 1,
                Image = product.ProductImages.FirstOrDefault()?.Image,
           
            };
        }




    }
}
