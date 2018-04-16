using System;
using System.Collections.Generic;
using System.Text;
using CoreAI.Models;

namespace CoreAI.Interfaces
{
    public interface IPlantsRecognition 
    {
        CustomeVisionResponse PlantsRecognitionImage();
    }
}
