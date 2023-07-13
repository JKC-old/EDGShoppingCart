﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EDGShoppingCart.Data;
using EDGShoppingCart.Models;
using EDGShoppingCart.Repositories.Interfaces;
using EDGShoppingCart.Repositories;

namespace EDGShoppingCart
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<EDGShoppingCartContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("EDGShoppingCartContext") ?? throw new InvalidOperationException("Connection string 'EDGShoppingCartContext' not found.")));

            // Add services to the container.

            builder.Services.AddScoped<ICartRepository, CartRepository>();
            builder.Services.AddScoped<IDiscountRepositry, DiscountRepository>();

            builder.Services.AddRazorPages();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedData.Initialize(services);

            }

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}