namespace WebApplication2.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("team")]
    public partial class team
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public team()
        {
            games = new HashSet<game>();
            games1 = new HashSet<game>();
            games2 = new HashSet<game>();
            players = new HashSet<player>();
        }

        public team(long? tournamentId)
        {
            tournament_id = tournamentId;
            games = new HashSet<game>();
            games1 = new HashSet<game>();
            games2 = new HashSet<game>();
            players = new HashSet<player>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public int? nb_members { get; set; }

        public long? captain_id { get; set; }

        public long? tournament_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<game> games { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<game> games1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<game> games2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<player> players { get; set; }

        public virtual player player { get; set; }

        public virtual tournament tournament { get; set; }
    }
}
