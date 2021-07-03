using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [Required(ErrorMessage ="Title is Mandatory")]
        [Display(Name = "Book Title")]
        [MaxLength(35, ErrorMessage = "Maximum Length Exceeded Eerror")]
        [MinLength(5, ErrorMessage = "Title Should not be less than 5 letters")]
        public string Title { get; set; }

        public string Author { get; set; }

        [Display( Name ="Category" )]
        [Required(ErrorMessage ="You have to specify the category")]
        public CategoryType Gener { get; set; }

        [DataType(DataType.Currency)]
        [Range(10.00 , 100.00 , ErrorMessage ="Price Can't be less than 10 or greater than 100")]
        public double Price { get; set; }

        [StringLength( 35 , ErrorMessage = "Should be between 0~~35 chars")]
        public string Publisher { get; set; }

        [Display(Name = "Book Language")]
        public Language Lang { get; set; }

        [Display(Name = "Book state")]
        public BookCondition State { get; set; }


        [Display(Name = "Publish Date")]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

    }
}
