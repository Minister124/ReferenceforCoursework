using System.ComponentModel.DataAnnotations;


// This class represents the data structure for the main form
// that users will fill out to submit information.
namespace ReferenceForCoursework.Data.Models
{
    public class AddForm
    {
        [Required(ErrorMessage = "First Name is Required")] // Required attribute ensures that this field is mandatory.
        [Display(Name = "First Name")] // Display attribute changes the label that will be shown in the UI.
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")] // Similar annotations for Last Name.
        [Display(Name = "Last Name")]  // Similar annotations for Last Name.
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]  // Similar annotations for Last Name.
        [EmailAddress(ErrorMessage = "Invalid email address")]  // Annotation to ensure a valid email address is provided.
        [Display(Name = "Email")]   // Similar annotations for Last Name.
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Invalid phone number")]  // Annotation to ensure a valid phone number is provided.
        [Display(Name = "Phone")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address is required")] // Annotation to make sure the address is provided.
        [Display(Name = "Address")]  // Annotation to make sure the address is provided.
        public string Address { get; set; }

        // This property represents a list of hobbies associated with the form.
        public List<Hobby> Hobbies { get; set; }
    }
}
