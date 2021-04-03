using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("user")]
    public partial class user
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user(string fn, string ln, string em, string pwd)
        {
            role_id = 1;
            first_name = fn;
            last_name = ln;
            email = em;
            password = pwd;
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string first_name { get; set; }
        
        [Required]
        [StringLength(255)]
        public string last_name { get; set; }
        
        [Required]
        public string email { get; set; }
        
        [Required]
        public string password { get; set; }
        
        [Required]
        [ForeignKey("role_id")]
        public int role_id { get; set; }
        
        public userRole UserRole { get; set; }
        
        

    }
}