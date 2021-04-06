using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Models
{
    [Table("userRole")]
    public partial class userRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage",
            "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public userRole()
        {
            
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int role_id { get; set; }
        
        public string role_name { get; set; }
        
        public ICollection<user> users { get; set; }
        
    }
}