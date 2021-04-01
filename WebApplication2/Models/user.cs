using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("user")]
    public partial class user
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }
        
        [Required]
        public string email { get; set; }
        
        [Required]
        public string password { get; set; }
        
        [Required]
        [ForeignKey("role_id")]
        public int role_id { get; set; }
        
        

    }
}