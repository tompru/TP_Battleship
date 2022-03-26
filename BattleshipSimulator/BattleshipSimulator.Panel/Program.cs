using BattleshipSimulator.Model.Algorithms.HitPropability;
using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Panel;
using BattleshipSimulator.Panel.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<IHitPropabilityCalculator, DummyHitPropabilityCalculator>();
builder.Services.AddTransient<IShipArranger, ShipsRandomArranger>();
builder.Services.AddTransient<GameService>();
builder.Services.AddTransient<EnemyShipsService>();

await builder.Build().RunAsync();
