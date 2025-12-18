using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

using CameraReview.Review;
using CameraReview.Product;
using NSubstitute;

namespace CameraReviewUnitTests.CameraReview.Review
{
    [TestClass]
    public class ReviewTest
    {
        [TestMethod]
        public void Review_ShouldReturnContent_Success()
        {
            // setup
            var review = new ReviewImpl
            {
                Title = "Great Camera",
                Content = "This camera is amazing.",
                Author = "John Doe",
                Product = Substitute.For<IProduct>()
            };

            // exec
            var content = review.GetContent();

            // assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(content), "Should return content but obtained null or whitespace.");
        }

        [TestMethod]
        public void Review_ShouldIncludeTitleInContent_Success()
        {
            // setup
            var title = "Excellent Lens";
            var review = new ReviewImpl
            {
                Title = title,
                Content = "Best lens ever.",
                Author = "Jane Smith",
                Product = Substitute.For<IProduct>()
            };

            // exec
            var content = review.GetContent();

            // assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(content), "Should return content but obtained null or whitespace.");
            Assert.IsTrue(content.Contains(title));
        }
    }
}
