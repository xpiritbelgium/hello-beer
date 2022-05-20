using Orleans;

namespace HelloBeer
{
    public interface IFridgeGrain : IGrainWithStringKey
    {
        Task AddBeer(string name, string brand, string origin);
        Task<List<Beer>> GetStoredBeers();
    }
}
