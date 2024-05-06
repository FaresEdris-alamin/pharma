using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using pharmacy.DTO;
using pharmacy.Data;
using pharmacy.Model;
using Microsoft.EntityFrameworkCore;

namespace pharmacy.Controller;
public static class MedicineController 
{
 
    public static RouteGroupBuilder MapMedicineEndpoints( this WebApplication app){
        var group = app.MapGroup("Medicines").WithParameterValidation();
        
        group.MapGet("/", async(PharmacyDbContext dbContext)=> 
            await dbContext.Medicines
            .Include(medicine =>medicine.Category)
            .AsNoTracking().ToListAsync());


        group.MapGet("/{id}", async(int id,PharmacyDbContext dbContext)=> {
            
            Medicine? medicine = await dbContext.Medicines.FindAsync(id);
            return medicine is null ? Results.NotFound() : Results.Ok(medicine);
            

        }).WithName("getMedicine");
        
        group.MapPost("/", async (CreateMedicineDTO NewMedicine,PharmacyDbContext dbContext) =>{
            Medicine medicine = new (){

                Name =NewMedicine.Name,
                CategoryID = NewMedicine.CategoryId,
                Category =dbContext.Categories.Find(NewMedicine.CategoryId),
                AdminId = NewMedicine.AdminId};
            
            dbContext.Medicines.Add(medicine);
            await dbContext.SaveChangesAsync();

            return Results.CreatedAtRoute("getMedicine",new{id = medicine.Id},medicine);    
        });

        group.MapPut("/{id}",async (int id, UpdateMedicineDTO updateMedicineDTO,PharmacyDbContext dbContext) => {
            
            var medicine = await dbContext.Medicines.FindAsync(id);
            if(medicine == null){
                return Results.NotFound();
            }
            Medicine med = new (){
                Id = id,    
                Name =updateMedicineDTO.Name,
                CategoryID = updateMedicineDTO.CategoryId,
                Category =dbContext.Categories.Find(updateMedicineDTO.CategoryId),
                AdminId = updateMedicineDTO.AdminId};

            dbContext.Entry(medicine).CurrentValues.SetValues(med);
            await dbContext.SaveChangesAsync();

            return Results.Ok(updateMedicineDTO);
        });

        group.MapDelete("/{id}",async (int id,PharmacyDbContext dbContext) => {
            await dbContext.Medicines.Where(medicine => medicine.Id==id).ExecuteDeleteAsync();

            return Results.NoContent();
        });
        return group;
    }
}
