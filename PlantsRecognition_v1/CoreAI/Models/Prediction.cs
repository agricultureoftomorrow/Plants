using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAI.Models
{
    public class Prediction
    {
        public string TagId { get; set; }
        public string Tag { get; set; }
        public string Propability { get; set; }
    }
}
