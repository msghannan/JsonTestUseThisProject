using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            List<JsonData> data = new List<JsonData>();
            JSONReadWrite readWrite = new JSONReadWrite();
            data = JsonConvert.DeserializeObject<List<JsonData>>(readWrite.Read("json.json", "data"));

            return View(data);
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