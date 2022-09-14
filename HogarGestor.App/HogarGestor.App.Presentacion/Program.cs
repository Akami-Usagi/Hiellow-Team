using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HogarGestor.App.Persistencia;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IRepositorioJovenMemoria,RepositorioJovenMemoria>();
builder.Services.AddSingleton<IRepositorioFamiliarMemoria,RepositorioFamiliarMemoria>();
builder.Services.AddSingleton<IRepositorioMedicoMemoria,RepositorioMedicoMemoria>();

builder.Services.AddScoped<IRepositorioJoven,RepositorioJoven>();

var ConnectionStrings = builder.Configuration.GetConnectionString("HogarGestor");
builder.Services.AddDbContext<HogarGestor.App.Persistencia.AppContext>(options => options.UseSqlServer(ConnectionStrings));
// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

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
