using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAI.Models
{
    public class CustomeVisionResponse
    {
        public string Id { get; set; }
        public string Project { get; set; }
        public string Iteration { get; set; }
        public string Created { get; set; }
        public List<Prediction> Predictions { get; set; }
    }
}
