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
            tournaments = new HashSet<tournament>();
        }

        public user()
        {
            /* Par defaut nous assignons la valeur 1, qui correspond au role user*/
            role_id = 1;
            tournaments = new HashSet<tournament>();
        }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long user_id { get; set; }

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
        
        public int? role_id { get; set; }
        [ForeignKey("role_id")]
        
        public userRole Role { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<tournament> tournaments { get; set; }

        
        

    }
}