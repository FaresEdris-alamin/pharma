using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace pharmacy.Data
{
    public static class DataExtensions
    {
        public static async Task MigrateDbAsync(this WebApplication app){
            using var scope = app.Services.CreateScope();
            var DbContext = scope.ServiceProvider.GetRequiredService<PharmacyDbContext>();
            await DbContext.Database.MigrateAsync();
        }
    }
}