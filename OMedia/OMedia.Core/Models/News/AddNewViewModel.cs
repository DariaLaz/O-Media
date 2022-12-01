using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMedia.Core.Models.News
{
    public class AddNewViewModel
    {
        [Required]
        [StringLength(50, MinimumLength =5, ErrorMessage ="The text should be between 5 and 50 characters")]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(800, MinimumLength =20, ErrorMessage ="The text should be between 20 and 800 characters!")]
        public string Content { get; set; } = null!;
    }
}
