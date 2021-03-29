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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Column(TypeName = "datetime2")]
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
