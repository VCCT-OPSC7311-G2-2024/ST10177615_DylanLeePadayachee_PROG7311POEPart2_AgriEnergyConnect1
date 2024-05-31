using Xunit;
using AgriEnergyConnect1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgriEnergyConnect1.Tests
{
    public class FarmerTests
    {
        [Fact]
        public void Name_RequiredAttribute_Validation()
        {
            // Arrange
            var farmer = new Farmer();

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(farmer, new ValidationContext(farmer), validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.MemberNames.Contains("Name"));
        }

        [Fact]
        public void Email_RequiredAttribute_Validation()
        {
            // Arrange
            var farmer = new Farmer();

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(farmer, new ValidationContext(farmer), validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.MemberNames.Contains("Email"));
        }

        [Theory]
        [InlineData("invalidEmail")]
        [InlineData("invalid@")]
        [InlineData("invalid.com")]
        public void Email_InvalidEmailAddress_Validation(string email)
        {
            // Arrange
            var farmer = new Farmer { Email = email };

            // Act
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(farmer, new ValidationContext(farmer), validationResults, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(validationResults, r => r.MemberNames.Contains("Email"));
        }
    }
}