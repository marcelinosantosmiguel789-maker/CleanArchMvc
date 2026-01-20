using System;
using System.Collections.Generic;
using System.Text;
using CleanArchMvc.Domain.Entities;
using FluentAssertions;


namespace CleanArchMvc.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create Product with valid state")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", 99, "Product Description", 9.99m, "Product image");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Product Negative Id Valid")]
        public void CreateProduct_NegativeIdValid_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", 99, "Product Description", 9.99m, "Product image");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("invalid Id");
        }
        [Fact(DisplayName = "Create Product Short Name")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", 99, "Product Description", 9.99m, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Product Missing Name")]
        public void CreateProduct_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", 99, "Product Description", 9.99m, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }
        [Fact(DisplayName = "Create Product long Name")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Product(1, "Product Name", 99, "Product Description", 9.99m,
                "ThisIsAnExtremelyLongImageNameThatExceedsTheMaximumAllowedLengthOfTwoHundredAndFiftyCharacters_" +
                "ThisIsAnExtremelyLongImageNameThatExceedsTheMaximumAllowedLengthOfTwoHundredAndFiftyCharacters_" +
                "ThisIsAnExtremelyLongImageNameThatExceedsTheMaximumAllowedLengthOfTwoHundredAndFiftyCharacters_" +
                "ThisIsAnExtremelyLongImageNameThatExceedsTheMaximumAllowedLengthOfTwoHundredAndFiftyCharacters_" +
                "ThisIsAnExtremelyLongImageNameThatExceedsTheMaximumAllowedLengthOfTwoHundredAndFiftyCharacters");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid image name, too long, maximum 250 characters");
        }
        [Fact(DisplayName = "Create Product Negative Price")]
        public void CreateProduct_NegativePriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Product Name", 99, "Product Description", -9.99m, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid price value");
        }
        [Fact(DisplayName = "Create Product Negative Stock")]
        public void CreateProduct_NegativeStockValue_DomainExceptionInvalidStock()
        {
            Action action = () => new Product(1, "Product Name", -5, "Product Description", 9.99m, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }
        [Fact(DisplayName = "Create Porduct Description Is Required")]
        public void CreateProduct_MissingDescriptionValue_DomainExceptionRequiredDescription()
        {
            Action action = () => new Product(1, "Product Name", 99, "", 9.99m, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid description. Description is required");
         }

        [Fact(DisplayName = "Create Product Null Image")]
        public void CreateProduct_NullImageValue_NoDomainException()
        {
            Action action = () => new Product(1, "Product Name", 99, "Product Description", 9.99m, null);
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_DomainExceptionInvalidStock(int stock)
        {
            Action action = () => new Product(1, "Product Name", stock, "Product Description", 9.99m, "Product image");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid stock value");
        }
    }
}