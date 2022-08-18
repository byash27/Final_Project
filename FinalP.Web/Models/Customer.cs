using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalP.Web.Models
{
    [Table(name: "Customers")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Customer ID")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty!")]
        [Column(TypeName = "varchar(50)")]
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }

        [Required(ErrorMessage = "{0} cannot be empty !")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid! Mobile Number XXX-XXX-XXXX")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "The Field {0} can't be Empty !")]
        [Display(Name = "EMAIL")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Not a valid {0} Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please add the required field !")]
        [Display(Name = "ID Proof")]
        public string ImgUrl { get; set; } = null;

        public ICollection<StartupInfo> StartupInfo { get; set; }

    }
}
