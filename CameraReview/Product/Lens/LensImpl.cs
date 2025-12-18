using System;
using System.Collections.Generic;
using System.Text;

namespace CameraReview.Product.Lens
{
    public class LensImpl : ILens
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string SKU { get; set; }
        public List<Feature> Features { get; set; }

        public string GetContent()
        {
            return $"Lens: {Name} by {Manufacturer}";
        }
    }
}