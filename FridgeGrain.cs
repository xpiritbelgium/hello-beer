using Orleans.Runtime;

namespace HelloBeer
{
    public class FridgeGrain : IFridgeGrain
    {
        private readonly IPersistentState<FridgeGrainState> _state;


        public FridgeGrain(
            [PersistentState("State")] IPersistentState<FridgeGrainState> state)
        {
            _state = state;
        }


        public async Task AddBeer(string name, string brand, string origin)
        {

            _state.State.Beers.Add(new Beer
            {
                Name = name,
                Brand = brand,
                Origin = origin
            });

            await _state.WriteStateAsync();
            // onnext?
        }

        public Task<List<Beer>> GetStoredBeers()
        {
            return Task.FromResult(_state.State.Beers);
        }
    }
}
