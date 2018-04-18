using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAI.Models
{
    public class CustomVisionProject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CurrentIterationId { get; set; }
        public string Created { get; set; }
        public string LastModified { get; set; }
        public string ThumbnailUri { get; set; }
        public Settings Settings { get; set; }
    }
}
