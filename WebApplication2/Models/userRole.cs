using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public partial class userRole
    {
        [Key]
        public int role_id { get; set; }
        
        public string role_name { get; set; }
        
    }
}