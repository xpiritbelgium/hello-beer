using Orleans;

namespace HelloBeer
{
    [GenerateSerializer]
    public class Beer
    {
        [Id(0)]
        public string Name { get; set; }
        [Id(1)]
        public string Brand { get; set; }
        [Id(2)]
        public string Origin { get; set; }
    }
}
