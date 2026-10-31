    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Product
    {
        [Key]
        public int Id {  get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        public string? Name {  get; set; }
        [Required]
        [Range(1,double.MaxValue,ErrorMessage = "price must be greater than 0")]
        public double Price {  get; set; }
        [Required]
        [Range(0,int.MaxValue,ErrorMessage ="value should be positive")]
        public int StockQuantity {  get; set; }
        [Required]
        public string? Category { get; set; }
    }
}
