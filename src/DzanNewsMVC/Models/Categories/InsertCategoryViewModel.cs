using System.ComponentModel.DataAnnotations;

namespace DzanNewsMVC.Models.Categories
{
    public class InsertCategoryViewModel
    {
        [Required(ErrorMessage ="Unesite naziv kategorije")]
        [Display(Name="Naziv")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [StringLength(100)]
        public string Description { get; set; }
    }
}
