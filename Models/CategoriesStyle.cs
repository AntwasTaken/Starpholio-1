using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Starpholio.Models
{
    public class CategoriesStyle
    {
        public CategoriesStyle()
        {

            categoriesStyle = new HashSet<CategoryStyle>(); // For the choice of picture type(portrait, fashion, sports, nature, urban etc...)
        }
        [Key]
        public int ID { get; set; }

        // categoriesStyle categories
        [Required(ErrorMessage = "Category 2 is required.")]
        public HashSet<CategoryStyle> categoriesStyle { get; set; }
    }

    public class CategoryStyle
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
