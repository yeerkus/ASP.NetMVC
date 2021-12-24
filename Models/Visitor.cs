using MongoDB.Bson.Serialization.Attributes;

namespace FirstMVC.Models
{
    public class Visitor
    {
        [BsonId]
        public Guid Id {get;set;}
        public int Number {get; set;}
    }
}