using System.ComponentModel.DataAnnotations;

namespace LibraryOrganizer.Models
{
    public class Title
    {
        public int Id { get; set; }                    // PK

        [StringLength(200, ErrorMessage = "Title may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter a book title.")]
        public string BookTitle { get; set; } //used to be Title in Class

        //[Range(100, 500, ErrorMessage = "Class number must be between 100 and 500.")]
        //[Required(ErrorMessage = "Please enter a class number.")]
        //public int? Number { get; set; }

        public int AuthorId { get; set; }                  // Foreign key property
        
        public Author Author { get; set; }                // Navigation property

        public string Description { get; set; }

        public bool IsRead { get; set; }

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5 stars")]
        public int Rating { get; set; }

        public string Review { get; set; }

        //public int DayId { get; set; }                      // Foreign key property
        //public Day Day { get; set; }                        // Navigation property
    }
}
