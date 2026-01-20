using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CleanArchMvc.Domain.Entities
{
   public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public int Stock { get; private set; }
        public decimal Price { get; private set;}

        public Product(string name, int stock, string description, decimal price,string image)
        {
            validateDomain(name, description,image,stock, price);
        }

        public Product(int id,string name, int stock, string description, decimal price, string image)
        {
            DomainExceptionValidation.When(id < 0, "invalid Id");
            validateDomain(name, description, image, stock, price);
        }

        public void Update(string name, int stock, string description, decimal price, string image, int categoryId)
        {
            validateDomain(name, description, image, stock, price);
            CategoryId = categoryId;
        }


        private void validateDomain(string name, string description, string image, int stock, decimal price)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");
            DomainExceptionValidation.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters");
            DomainExceptionValidation.When(price < 0,
                "Invalid price value");
            DomainExceptionValidation.When(stock < 0,
                "Invalid stock value");
            DomainExceptionValidation.When(!string.IsNullOrEmpty(image) && image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Image = image;
            Stock = stock;
            Price = price;
            

        }

        public int CategoryId { get; set; }
        public Category Category { get; set;}


    }
}
