using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreAI.Interfaces;
using CoreAI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PlantsRecognition_v1.Controllers
{
    [Route("api/recognition")]
    public class PlantsRecognitionController : Controller
    {
        private readonly string trainingKey;
        private readonly string predictionKey;
        private readonly string predictionURL;
        private readonly IPlantsRecognition plantsRecognitionRepository;

        public PlantsRecognitionController(IOptions<ApplicationSettings> appSettings, IPlantsRecognition plantsRecognition )
        {

            trainingKey = appSettings.Value.TrainingKey;
            predictionKey = appSettings.Value.PredictionKey;
            predictionURL = appSettings.Value.PredictionUrl;
            plantsRecognitionRepository = plantsRecognition;
        }

        [HttpPost]
        public IActionResult RecognitionImage()
        {
            var res = Request.Form;
            var files = res.Files[0];

            if (!Request.HasFormContentType)
            {
                return BadRequest();
            }

            CustomeVisionResponse response = plantsRecognitionRepository.PlantsRecognitionImage(predictionKey, predictionURL,files);

            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
            
        }

    }
}
