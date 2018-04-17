using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CoreAI.Interfaces;
using CoreAI.Models;
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

        private readonly ApplicationSettings appSettings = new ApplicationSettings()
        { PredictionUrl = "someUrl", PredictionKey = "somePredictionKey", TrainingKey = "someTrainingKey" };

        private PlantsRecognitionController ControllerPlants()
        {
           
            var mockRepository = new Mock<IPlantsRecognition>();
            var mockSettings = new Mock<IOptions<ApplicationSettings>>();
            var mockCollection = new Mock<IFormFile>();

            var content = "some content";
            var fileName = "FIleName.jpg";
            var ms=new MemoryStream();
            var writer=new StreamWriter(ms);
            writer.Write(content);
            writer.Flush();
            ms.Position = 0;
            mockCollection.Setup(i => i.OpenReadStream()).Returns(ms);
            mockCollection.Setup(i => i.FileName).Returns(fileName);
            mockCollection.Setup(i => i.Length).Returns(ms.Length);

            mockSettings.Setup(s => s.Value).Returns(appSettings);
            mockRepository.Setup(x => x.PlantsRecognitionImage("22","http", mockCollection.Object)).Returns(returnList);
            

            return new PlantsRecognitionController(mockSettings.Object, mockRepository.Object);
        }




    }
}
