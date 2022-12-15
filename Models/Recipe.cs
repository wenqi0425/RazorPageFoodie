using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace FoodieBlog.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Recipe Name:")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Cooking Steps:")]
        public string CookingSteps { get; set; }

        [Display(Name = "Introduction:")]
        public string? Introduction { get; set; }

        [Display(Name = "Image:")]
        public byte[]? FoodImageData { get; set; }        
    }
}
