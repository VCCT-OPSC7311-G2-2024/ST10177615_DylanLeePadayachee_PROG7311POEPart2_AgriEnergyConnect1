using AgriEnergyConnect1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AgriEnergyConnect1.Tests
{
    public class ErrorViewModelTests
    {
        [Fact]
        public void ShowRequestId_WithValidRequestId_ReturnsTrue()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = "123456" };

            // Act
            var showRequestId = model.ShowRequestId;

            // Assert
            Assert.True(showRequestId);
        }

        [Fact]
        public void ShowRequestId_WithNullRequestId_ReturnsFalse()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = null };

            // Act
            var showRequestId = model.ShowRequestId;

            // Assert
            Assert.False(showRequestId);
        }

        [Fact]
        public void ShowRequestId_WithEmptyRequestId_ReturnsFalse()
        {
            // Arrange
            var model = new ErrorViewModel { RequestId = "" };

            // Act
            var showRequestId = model.ShowRequestId;

            // Assert
            Assert.False(showRequestId);
        }
    }
}