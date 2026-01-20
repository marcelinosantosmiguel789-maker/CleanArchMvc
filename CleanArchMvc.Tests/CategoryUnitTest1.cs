using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category with valid state")]
        public void CreateCategory_WithValidParameters_ResultObjectState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Category Negative Id Valid")]
        public void CreateCategory_NegativeIdValid_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid Id. Id must be greater than zero.");
        }

        [Fact(DisplayName = "Create Category Short Name")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name, too short, minimum 3 characters");
        }

        [Fact(DisplayName = "Create Category Missing Name")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>()
                .WithMessage("Invalid name. Name is required");
        }

        [Fact(DisplayName = "Create Category Null Name")]
        public void CreateCategor_WithNullNameValue_ValidObject()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create Category Name with Null Value")]
        public void CreateCategory_NameWithNullValue_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Product Name", 99, "Product Description", 9.99m, null);
            action.Should()
                .NotThrow<NullReferenceException>();
        }
    }
}

