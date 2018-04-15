using System;
using System.Collections.Generic;
using System.Text;
using CoreAI.Interfaces;
using CoreAI.Models;
using Microsoft.AspNetCore.Http;
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
                    new Prediction() {Tag = "goosefoot", TagId = "2", Propability = "92"}
                }
        };

        private readonly ApplicationSettings appSettings = new ApplicationSettings()
        { PredictionUrl = "someUrl", PredictionKey = "somePredictionKey", TrainingKey = "someTrainingKey" };

        private PlantsRecognitionController ControllerPlants()
        {
            var mockRepository = new Mock<IPlantsRecognition>();
            var mockSettings = new Mock<IOptions<ApplicationSettings>>();
            mockSettings.Setup(s => s.Value).Returns(appSettings);
            mockRepository.Setup(x => x.PlantsRecognitionImage()).Returns(returnList);
            return new PlantsRecognitionController(mockSettings.Object, mockRepository.Object);
        }

        [TestMethod]
        public void RecognitionImage_checkInputFile_BadRequest()
        {
            //Arrange           
            var controller = ControllerPlants();

            //Act
            var result = controller.RecognitionImage(null);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void RecognitionImage_checkResult_CustomeVisionResponse()
        {
            //Arrange
            var mockCollection=new Mock<ICollection<IFormFile>>();
            var controller = ControllerPlants();

            //Act
            var result = controller.RecognitionImage(mockCollection.Object);
            var okObjectResult = result as OkObjectResult;
            var modelResult = okObjectResult.Value is CustomeVisionResponse;

            //Assert
            Assert.IsNotNull(modelResult);
            Assert.IsTrue(modelResult);
        }
    }
}
