using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Starpholio.Models
{
    public class CategoriesColour
    {
        public CategoriesColour()
        {
            categoriesColour = new HashSet<CategoryColour>(); // For the choice between Regular colours, Monochromatic and Negative

        }

        public int ID { get; set; }

        // categoriesColour categories
        [Required(ErrorMessage = "Category 1 is required.")]
        public HashSet<CategoryColour> categoriesColour { get; set; }
    }

    public class CategoryColour
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}

