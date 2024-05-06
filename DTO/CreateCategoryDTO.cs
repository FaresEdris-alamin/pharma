using System.ComponentModel.DataAnnotations;

namespace pharmacy.DTO;

public record class CreateCategoryDTO
(
    
    [Required] string Name
);
