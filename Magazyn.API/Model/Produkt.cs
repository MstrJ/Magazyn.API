using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Magazyn.API.Model
{
    [BsonIgnoreExtraElements]
	public class Produkt
	{
		[BsonElement("kod")]
		public string kod { get; set; }
        [BsonElement("nazwa")]
        public string nazwa { get; set; }
        [BsonElement("ilosc")]
        public int ilosc { get; set; }
        [BsonElement("sektor")]
        public string sektor { get; set; }
	}
}

