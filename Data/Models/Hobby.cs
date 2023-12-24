using System.ComponentModel.DataAnnotations;


// This class represents the data structure for a hobby.
namespace ReferenceForCoursework.Data.Models
{
    public class Hobby
    {
        // Unique identifier for each hobby, automatically generated.
        public Guid Id { get; set; } = Guid.NewGuid(); 

        [Required(ErrorMessage = "The Name is Required")]  // Required attribute ensures that this Name field is mandatory.
        public string Name { get; set; }
    }
}
