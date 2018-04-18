using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CoreAI.Interfaces;
using CoreAI.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace CoreAI.Repositories
{
    public class PlantsRecognitionRepository: IPlantsRecognition
    {
        
        public CustomeVisionResponse PlantsRecognitionImage(string predictionKey, string predictionUrl, IFormFile files)
        {
            
            var form = files;
            CustomeVisionResponse returnCustomeVisionResponse=new CustomeVisionResponse();

            using (var readStream = form.OpenReadStream())
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("Prediction-Key", predictionKey);
                    MultipartFormDataContent multipartFormDataContent = new MultipartFormDataContent();
                    StreamContent imageData=new StreamContent(readStream);
                    imageData.Headers.ContentType=new MediaTypeHeaderValue("application/octet-stream");
                    ContentDispositionHeaderValue contentDispositionHeaderValue=new ContentDispositionHeaderValue("form-data");
                    contentDispositionHeaderValue.Name = "imageData";
                    contentDispositionHeaderValue.FileName = form.FileName;
                    imageData.Headers.ContentDisposition = contentDispositionHeaderValue;
                    multipartFormDataContent.Add(imageData,"imageData");
                    HttpResponseMessage response =
                        client.PostAsync(predictionUrl, multipartFormDataContent).Result;
                    string responseContent = response.Content.ReadAsStringAsync().Result;
                    CustomeVisionResponse tempCustomeVisionResponse =
                        JsonConvert.DeserializeObject<CustomeVisionResponse>(responseContent);
                    returnCustomeVisionResponse.Id = tempCustomeVisionResponse.Id;
                    returnCustomeVisionResponse.Created = tempCustomeVisionResponse.Created;
                    returnCustomeVisionResponse.Iteration = tempCustomeVisionResponse.Iteration;
                    returnCustomeVisionResponse.Project = tempCustomeVisionResponse.Project;
                    returnCustomeVisionResponse.Predictions = new List<Prediction>();

                    foreach (var prediction in tempCustomeVisionResponse.Predictions)
                    {
                        Prediction objectPrediction=new Prediction(){TagId = prediction.TagId, Tag = prediction.Tag};
                        objectPrediction.Probability = prediction.Probability;
                        returnCustomeVisionResponse.Predictions.Add(objectPrediction);
                    }
                }
            }

            return returnCustomeVisionResponse;

        }

        public IList<CustomVisionProject> GetProjectsList(string trainingKey)
        {
            var returnProjectsList=new List<CustomVisionProject>();

            using (HttpClient client=new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Training-Key", trainingKey);
                StringBuilder uri=new StringBuilder();
                uri.Append("https://southcentralus.api.cognitive.microsoft.com");
                uri.Append("/customvision/v1.0/Training");
                uri.Append("/projects?");
                HttpResponseMessage response = client.GetAsync(uri.ToString()).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                returnProjectsList = JsonConvert.DeserializeObject<List<CustomVisionProject>>(content);
            }

            return returnProjectsList;
        }

        public CustomVisionTag GetTagsList(string projectId, string trainingKey)
        {
            CustomVisionTag returnTags=new CustomVisionTag();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Training-Key", trainingKey);
                StringBuilder uri=new StringBuilder();
                uri.Append("https://southcentralus.api.cognitive.microsoft.com");
                uri.Append("/customvision/v1.0/Training");
                uri.Append("/projects/" + projectId);
                uri.Append("/tags?");
                HttpResponseMessage response = client.GetAsync(uri.ToString()).Result;
                string content = response.Content.ReadAsStringAsync().Result;
                returnTags = JsonConvert.DeserializeObject<CustomVisionTag>(content);
            }
            return returnTags;
        }
    }
}
