using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using FirstMVC.Models;
using MongoDB.Bson;

namespace FirstMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var client = new MongoClient("mongodb+srv://********:********@microservices.rjvap.mongodb.net/Blog?retryWrites=true&w=majority");
            var db = client.GetDatabase("Blog");
            var collection = db.GetCollection<Visitor>("visitors");
            
            var document = collection.Find(new BsonDocument()).FirstOrDefault();
            var id = document.Id;
            document.Number++;
            
            BsonBinaryData binData = new BsonBinaryData(id, GuidRepresentation.Standard);

            collection.ReplaceOne(new BsonDocument("_id", binData), document);

            ViewBag.numVisitors = collection.Find(new BsonDocument()).FirstOrDefault().Number.ToString();

            return View();
        }
    }
}
