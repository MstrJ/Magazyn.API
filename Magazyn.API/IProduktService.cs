using Magazyn.API.Model;

namespace Magazyn.API
{
    public interface IProduktService
    {
        Task<IEnumerable<Produkt>> GetProdukts();

        Task<bool> ChangeIlosc(string kod, int newilosc);
        Task<Produkt> AddProdukt(ProduktDTO newprodukt);
    }
}