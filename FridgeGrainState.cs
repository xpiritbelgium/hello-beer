using Orleans;

namespace HelloBeer
{
    [GenerateSerializer]
    public class FridgeGrainState
    {
        [Id(0)]
        public List<Beer> Beers { get; set; } = new List<Beer>();

    }
}
