using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAI.Interfaces;
using CoreAI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlantsRecognition_v1.Controllers
{
    [Route("api/upload")]
    public class UploadController : Controller
    {
        private readonly string trainingKey;
        private readonly string predictionKey;
        private readonly string predictionURL;
        private readonly IPlantsRecognition plantsRecognitionRepository;

        public UploadController(IOptions<ApplicationSettings> appSettings, IPlantsRecognition repository )
        {
            trainingKey = appSettings.Value.TrainingKey;
            predictionKey = appSettings.Value.PredictionKey;
            predictionURL = appSettings.Value.PredictionUrl;
            plantsRecognitionRepository = repository;
        }

        [HttpGet("[action]")]
        public IActionResult GetTags(string projectId)
        {
            var result = plantsRecognitionRepository.GetTagsList(projectId, trainingKey);
            return Ok(result);
        }

        [HttpGet("[Action]")]
        public IActionResult GetProjects()
        {
            var result = plantsRecognitionRepository.GetProjectsList(trainingKey);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult UploadNewImages()
        {
            var response = Request.Form;
            IFormFileCollection files = response.Files;
            string project = response["selectedProject"].First();
            string tag = response["selectedTag"].First();
            plantsRecognitionRepository.SendNewImagesCollection(files, project, tag, trainingKey);
            return Ok();
        }

    }
}
