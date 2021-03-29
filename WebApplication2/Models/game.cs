namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("game")]
    public partial class game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public game(tournament t)
        {
            tournament = t;
        }

        public game()
        {
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        
        [Column(TypeName = "datetime2")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? date { get; set; }

        public long? bteam_id { get; set; }

        public long? rteam_id { get; set; }

        public long? tournament_id { get; set; }

        public long? winner_id { get; set; }

        public virtual tournament tournament { get; set; }

        public virtual team team { get; set; }

        public virtual team team1 { get; set; }

        public virtual team team2 { get; set; }
    }
}
