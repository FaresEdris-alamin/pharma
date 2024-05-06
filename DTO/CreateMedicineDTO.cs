using System.ComponentModel.DataAnnotations;

namespace pharmacy.DTO;

public record class CreateMedicineDTO
(    
    [Required]string Name,
    [Required]int CategoryId,
    [Required]int AdminId
);