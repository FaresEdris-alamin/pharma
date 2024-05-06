using System.ComponentModel.DataAnnotations;

namespace pharmacy.DTO;

public record class UpdateMedicineDTO
(
    [Required] string Name,
    [Required] int CategoryId,
    [Required] int AdminId
);
