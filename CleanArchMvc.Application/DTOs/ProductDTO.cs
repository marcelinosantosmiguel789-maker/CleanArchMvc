using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        [MinLength(3, ErrorMessage = "The Name field must be at least 3 characters long.")]
        [MaxLength(100, ErrorMessage = "The Name field must be a maximum of 100 characters long.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Description field is required.")]
        [MinLength(5, ErrorMessage = "The Description field must be at least 5 characters long.")]
        [MaxLength(500, ErrorMessage = "The Description field must be a maximum of 500 characters long.")]
        public string Description { get; set; }
        [Required(ErrorMessage = "The Price field is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The Price field must be a positive value.")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "The ImageUrl field is required.")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "The Stock field is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "The Stock field must be a non-negative integer.")]
        [MaxLength(250, ErrorMessage = "The ImageUrl field must be a maximum of 250 characters long.")]
        public int Stock { get; set; }
        [Required(ErrorMessage = "The CategoryId field is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "The CategoryId field must be a positive integer.")]
        public int CategoryId { get; set; }
    }
}
