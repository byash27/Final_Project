using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalP.Web.Models
{
    [Table(name: "Infos")]

    public class StartupInfo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Startup ID")]
        public int StartupId { get; set; }

        [Required(ErrorMessage = " The field {0} can't be Empty !")]
        [Display(Name = "Company Name")]
        [StringLength(50)]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = " The field {0} can't be Empty !")]
        [Display(Name = "Company Sales")]
        public double CompanySales { get; set; }


        [Display(Name = "Date")]
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; } = DateTime.Now;



        [Display(Name = "Sub Category")]
        public int Id { get; set; }
        [ForeignKey(nameof(StartupInfo.Id))]
        public SubCategory SubCategory { get; set; }




        //[Display(Name = "Category ID")]
        //public int CategoryId { get; set; }
        //[ForeignKey(nameof(StartupInfo.CategoryId))]
        //public Category Category { get; set; }



        [Display(Name = "Customer Name")]
        public int CustomerId { get; set; }
        [ForeignKey(nameof(StartupInfo.CustomerId))]
        public Customer Customer { get; set; }
    }
}
