using BattleshipSimulator.Model.Algorithms.HitPropability;
using BattleshipSimulator.Model.Algorithms.ShipsArrange;
using BattleshipSimulator.Panel;
using BattleshipSimulator.Panel.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IHitPropabilityCalculator, DummyHitPropabilityCalculator>();
builder.Services.AddSingleton<IShipArranger, ShipsRandomArranger>();
builder.Services.AddSingleton<GameService>();
builder.Services.AddSingleton<EnemyShipsService>();

await builder.Build().RunAsync();
