// Program.cs

using HelloBeer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Orleans;
using Orleans.Hosting;

// create the silo host
using var host = new HostBuilder()
  .UseOrleans(b => b.UseLocalhostClustering()
  .AddMemoryGrainStorageAsDefault()
  .AddMemoryGrainStorage("PubSubStore")
  .UseInMemoryReminderService())

  .Build();

// start the silo
await host.StartAsync();

// get a reference to the grain and call it
var test = host.Services
  .GetRequiredService<IGrainFactory>()
  .GetGrain<IFridgeGrain>("Xpirit-Be");

await test.AddBeer("jaspers biereke", "heiniken", "graspop");
await test.AddBeer("Kristof zijn pintje", "carpils", "Aldi");


var beers = await test.GetStoredBeers();


Console.WriteLine("Beers in the fridge:");
beers.ForEach(i => Console.Write("{0}\t", $"{i.Name} {i.Brand} {i.Origin}"));


Console.WriteLine(beers);
Console.ReadLine();


