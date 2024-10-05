using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Dtos.Category
{
    public class UpdateCategoryRequestDto
    {
        [Required(ErrorMessage = "Name field is requierd")]
        [MinLength(2, ErrorMessage = "Name length must be at least 5 Characters")]
        [DataType(DataType.Text, ErrorMessage = "Name must be a string")]
        public required string Name { get; set; }
        [MinLength(2, ErrorMessage = "Name length must be at least 5 Characters")]
        [DataType(DataType.Text, ErrorMessage = "Name must be a string")]
        public string Description { get; set; } = String.Empty;
    }
}
