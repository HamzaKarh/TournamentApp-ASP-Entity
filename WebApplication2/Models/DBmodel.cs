using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication2.Models
{
    public partial class DBmodel : DbContext
    {
        public DBmodel()
            : base("name=DBmodel")
        {
        }

        public virtual DbSet<game> games { get; set; }
        public virtual DbSet<player> players { get; set; }
        public virtual DbSet<team> teams { get; set; }
        public virtual DbSet<tournament> tournaments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<game>()
                .Property(e => e.date)
                .HasPrecision(6);

            modelBuilder.Entity<player>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<player>()
                .HasMany(e => e.teams)
                .WithOptional(e => e.player)
                .HasForeignKey(e => e.captain_id);

            modelBuilder.Entity<team>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<team>()
                .HasMany(e => e.games)
                .WithOptional(e => e.team)
                .HasForeignKey(e => e.rteam_id);

            modelBuilder.Entity<team>()
                .HasMany(e => e.games1)
                .WithOptional(e => e.team1)
                .HasForeignKey(e => e.winner_id);

            modelBuilder.Entity<team>()
                .HasMany(e => e.games2)
                .WithOptional(e => e.team2)
                .HasForeignKey(e => e.bteam_id);

            modelBuilder.Entity<team>()
                .HasMany(e => e.players)
                .WithRequired(e => e.team)
                .HasForeignKey(e => e.team_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tournament>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<tournament>()
                .Property(e => e.game)
                .IsUnicode(false);

            modelBuilder.Entity<tournament>()
                .Property(e => e._private)
                .IsFixedLength();

            modelBuilder.Entity<tournament>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<tournament>()
                .Property(e => e.start_date)
                .HasPrecision(6);

            modelBuilder.Entity<tournament>()
                .Property(e => e.started)
                .IsFixedLength();

            modelBuilder.Entity<tournament>()
                .HasMany(e => e.games)
                .WithOptional(e => e.tournament)
                .HasForeignKey(e => e.tournament_id);

            modelBuilder.Entity<tournament>()
                .HasMany(e => e.teams)
                .WithOptional(e => e.tournament)
                .HasForeignKey(e => e.tournament_id);
        }
    }
}
