using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using JsonTestUseThisProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JsonTestUseThisProject.Controllers
{
    public class JsonDataController : Controller
    {
        public ActionResult Index()
        {
            var webClient = new WebClient();
            var jsonFile = webClient.DownloadString(@"wwwroot\Data\json.json");
            var dataFromJson = JsonConvert.DeserializeObject<ObservableCollection<JsonData>>(jsonFile);

            return View(dataFromJson);
        }

        public ActionResult Details(int id)
        {
            var webClient = new WebClient();
            var jsonFile = webClient.DownloadString(@"wwwroot\Data\json.json");
            var dataFromJson = JsonConvert.DeserializeObject<ObservableCollection<JsonData>>(jsonFile).Where(j => j.id == id);

            return View(dataFromJson);
        }
    }









    //     -----NEW CLASS-----    -----FOR READ AND WRITE FROM JSON FILE-----    -----NEW CLASS-----
    //     -----NEW CLASS-----    -----FOR READ AND WRITE FROM JSON FILE-----    -----NEW CLASS-----



    public class JSONReadWrite
    {
        public JSONReadWrite() { }

        public string Read(string fileName, string location)
        {
            string root = "wwwroot";
            var path = Path.Combine(Directory.GetCurrentDirectory(), root, location, fileName);

            string jsonResult;

            using (StreamReader streamReader = new StreamReader(path))
            {
                jsonResult = streamReader.ReadToEnd();
            }
            return jsonResult;
        }


        public void Write(string fileName, string location, string jSONString)
        {
            string root = "wwwroot";
            var path = Path.Combine(Directory.GetCurrentDirectory(), root, location, fileName);

            using (var streamWriter = File.CreateText(path))
            {
                streamWriter.Write(jSONString);
            }
        }
    }
}