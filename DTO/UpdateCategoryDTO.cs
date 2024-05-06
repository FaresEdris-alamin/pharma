using System.ComponentModel.DataAnnotations;


namespace pharmacy.DTO;

public record class UpdateCategoryDTO
(
    [Required] string Name
);