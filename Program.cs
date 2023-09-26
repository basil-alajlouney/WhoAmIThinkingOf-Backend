using System.Data.Common;
using Connector;
using Microsoft.Extensions.Caching.Memory;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddMemoryCache();
        var db = new ConnectionPoint();
        db.Database.EnsureCreated();
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        // - Meddleware
        // # adds IP-Based Auth
        // ! requires "IP" in each request header.
        app.Use((request, next) =>
        {
            var _memoryCache = 
            request.RequestServices
            .GetRequiredService<IMemoryCache>();
            var Headers = request.Request.Headers;
            var OverLooked = new string[]
            {
                "ControllerMenu.UserController.Get (EFCore)",
                "ControllerMenu.UserController.Post (EFCore)",
            };// as overlooked endpoints
            System.Console.WriteLine(request.GetEndpoint()!.DisplayName);
            foreach (var el in OverLooked)
                if (request.GetEndpoint()!.DisplayName == el)
                    return next();// OverLooks Listed endpoint

            if (!Headers.ContainsKey("IP"))
                throw new Exception("Missing Headers (IP address)");

            var IP = Headers.GetCommaSeparatedValues("IP");
            if (IP.Length <= 0)
                throw new Exception("Missing Credentials (IP address)");

            
            var user = _memoryCache.Get(IP[0]) ?? throw new Exception("session timed out!");
            
            _memoryCache.Set(IP[0],user,TimeSpan.FromMinutes(20));
            // _memoryCache.Set("IP",IP[0]); //! for testing purposes
            return next();
        });
        app.Run();
    }
}