using System;
using Magazyn.API.Model;
using MongoDB.Driver;

namespace Magazyn.API
{
    public class ProduktService : IProduktService
    {
        private IMongoCollection<Produkt> _produktCollection;

        public ProduktService(IMongoClient client)
        {
            var db = client.GetDatabase("Magazyn");
            _produktCollection = db.GetCollection<Produkt>("Produkty");
        }


        public async Task<IEnumerable<Produkt>> GetProdukts()
        {
            return await _produktCollection.AsQueryable().ToListAsync();
        }

        public async Task<bool> ChangeIlosc(string kod,int newilosc)
        {
            var obj = await _produktCollection.Find(x => x.kod.Equals(kod)).FirstOrDefaultAsync();
            obj.ilosc = newilosc;
            await _produktCollection.ReplaceOneAsync(x => x.kod.Equals(kod),obj);
            return true;
        }

        public async Task<Produkt> AddProdukt(ProduktDTO newprodukt)
        {
            var produkt = new Produkt()
            {
                ilosc = newprodukt.ilosc,
                kod = $"PROD{GetProdukts().Result.Count() + 1}",
                nazwa = newprodukt.nazwa,
                sektor = newprodukt.sektor
            };
            await _produktCollection.InsertOneAsync(produkt);
            return produkt;
        }
    }
}

