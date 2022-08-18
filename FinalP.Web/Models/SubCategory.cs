using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalP.Web.Models
{
    [Table(name: "SubCategories")]

    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "SubCategory ID")]
        public int Id { get; set; }



        [Required(ErrorMessage = "The Field {0} can't be Empty!")]
        [Column(TypeName = "varchar(100)")]
        [Display(Name = "Sector")]
        public string SubCategories { get; set; }


        #region 


        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }
        [ForeignKey(nameof(SubCategory.CategoryID))]
        public Category Category { get; set; }

        #endregion

        public ICollection<StartupInfo> StartupInfo { get; set; }


    }
}
