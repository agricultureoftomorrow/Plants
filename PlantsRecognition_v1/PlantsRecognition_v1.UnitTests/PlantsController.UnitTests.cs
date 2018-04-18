using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CoreAI.Interfaces;
using CoreAI.Models;
using CoreAI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlantsRecognition_v1.Controllers;

namespace PlantsRecognition_v1.UnitTests
{
    [TestClass]
    public class PlantsController
    {
        private readonly CustomeVisionResponse returnList=new CustomeVisionResponse()
        {
            Id = "1",
            Created = "xxx",
            Iteration = "1",
            Project = "Plants",
            Predictions = new List<Prediction>()
                {
                    new Prediction() {Tag = "goosefoot", TagId = "2", Probability = "92"}
                }
        };

        private readonly CustomVisionProject returnProjectsList=new CustomVisionProject()
        {
            Id = "1",
            Created = "Tommy Lee Jones",
            Name = "Food",
            Description = "Some food list",
            
            
        };
        
        private readonly ApplicationSettings appSettings = new ApplicationSettings()
        { PredictionUrl = "someUrl", PredictionKey = "somePredictionKey", TrainingKey = "someTrainingKey" };




    }
}
