// C# class generated with assistance from ChatGPT


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AgriEnergyConnect1.Models;
using Xunit;

namespace AgriEnergyConnect1.Tests
{
    public class ProductTests
    {
        private Product _product;

        public ProductTests()
        {
            _product = new Product();
        }

        [Fact]
        public void Name_RequiredAttribute_Validation()
        {
            // Act
            var validationResults = ValidateProperty(_product, "Name");

            // Assert
            AssertContainsErrorMessage(validationResults, "Name is required");
        }

        [Fact]
        public void Category_RequiredAttribute_Validation()
        {
            // Act
            var validationResults = ValidateProperty(_product, "Category");

            // Assert
            AssertContainsErrorMessage(validationResults, "Category is required");
        }

        [Fact]
        public void ProductionDate_RequiredAttribute_Validation()
        {
            // Arrange
            var product = new Product(); // Make sure this creates a new instance of Product

            // Act
            var validationResults = ValidateProperty(product, "ProductionDate");

            // Assert
            AssertContainsErrorMessage(validationResults, "Production Date is required");
        }


        private List<ValidationResult> ValidateProperty(object instance, string propertyName)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(instance) { MemberName = propertyName };
            Validator.TryValidateProperty(instance.GetType().GetProperty(propertyName).GetValue(instance), context, validationResults);
            return validationResults;
        }

        private void AssertContainsErrorMessage(List<ValidationResult> validationResults, string expectedErrorMessage)
        {
            Assert.Contains(validationResults, r => r.ErrorMessage == expectedErrorMessage);
        }
    }
}
