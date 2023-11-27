// See https://aka.ms/new-console-template for more information
using ConsoleApp2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

// Path: ConsoleApp2/Program.cs
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services
             .AddDbContext<SoiFinDb>(options =>
             {
                 options.ConfigureWarnings(w => w.Ignore(CoreEventId.RowLimitingOperationWithoutOrderByWarning));
                 options.UseNpgsql("Host=rain.db.elephantsql.com;Port=5432;Database=xxtojalv;Username=xxtojalv;Password=4YFPrF_0g9M2GmPFC_qqeXi2A8VA_M3y;Include Error Detail=true").UseSnakeCaseNamingConvention();
             });

using IHost host = builder.Build();

using IServiceScope scope = host.Services.CreateScope();

var db = scope.ServiceProvider.GetRequiredService<SoiFinDb>();

var list = await db.TestTables.Take(10).ToListAsync();

foreach (var item in list)
{
    Console.WriteLine($"{item.Created} kind: {item.Created.Kind}");
}

Console.ReadLine();
