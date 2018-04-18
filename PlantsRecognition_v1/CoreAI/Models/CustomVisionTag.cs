using System;
using System.Collections.Generic;
using System.Text;

namespace CoreAI.Models
{
    public class CustomVisionTag
    {
        public List<Tag> Tags { get; set; }
        public int TotalTaggedImages { get; set; }
        public int TotalUntaggedImages { get; set; }
    }
}
