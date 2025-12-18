using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using CameraReview.Product.Lens;
using NSubstitute;

namespace CameraReviewUnitTests.CameraReview.Product.Lens
{
    [TestClass]
    public class LensTest
    {
        [TestMethod]
        public void Lens_ShouldReturnContent_Success()
        {
            // setup
            var lens = new LensImpl
            {
                Name = "50mm f/1.4",
                SKU = "5678",
                Manufacturer = "Canon"
            };

            // exec
            var content = lens.GetContent();

            // assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(content), "Should return content but obtained null or whitespace.");
        }

        [TestMethod]
        public void Lens_ShouldIncludeNameInContent_Success()
        {
            // setup
            var name = "85mm f/1.8";
            var lens = new LensImpl
            {
                Name = name,
                SKU = "9101",
                Manufacturer = "Nikon"
            };

            // exec
            var content = lens.GetContent();

            // assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(content), "Should return content but obtained null or whitespace.");
            Assert.IsTrue(content.Contains(name));
        }
    }
}