using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Magazyn.API.Model
{
	public class ProduktDTO
	{
        public string nazwa { get; set; }
        public int ilosc { get; set; }
        public string sektor { get; set; }
    }
}

