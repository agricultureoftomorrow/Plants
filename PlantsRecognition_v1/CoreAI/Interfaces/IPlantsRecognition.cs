using System;
using System.Collections.Generic;
using System.Text;
using CoreAI.Models;
using Microsoft.AspNetCore.Http;

namespace CoreAI.Interfaces
{
    public interface IPlantsRecognition 
    {

        CustomeVisionResponse PlantsRecognitionImage(string predictionKey, string predictionUrl, IFormFile files);
        IList<CustomVisionProject> GetProjectsList(string trainingKey);
        CustomVisionTag GetTagsList(string projectId, string trainingKey);
        void SendNewImagesCollection(IFormFileCollection files, string project, string tag, string trainingKey);

    }
}
