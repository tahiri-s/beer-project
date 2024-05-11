using BeerCollection.Models;

namespace BeerCollection.Interface
{
    public interface IBeerRepository
    {
        void AddBeer(Beers beerObj);
        IEnumerable<Beers> Beers();
        IEnumerable<Beers> Search(string name);
        bool UpdateRating(int beerId);
    }
}