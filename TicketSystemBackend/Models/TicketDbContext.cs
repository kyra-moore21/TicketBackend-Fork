using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketSystemBackend.Models;

public partial class TicketDbContext : DbContext
{
    public TicketDbContext()
    {
    }

    public TicketDbContext(DbContextOptions<TicketDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Bookmark> Bookmarks { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Ticket> Tickets { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=TicketDB; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Bookmark>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookmark__3214EC07BE0AB5C3");

            entity.ToTable("Bookmark");

            entity.HasOne(d => d.Ticket).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Bookmark__Ticket__08B54D69");

            entity.HasOne(d => d.UserBookmarkedNavigation).WithMany(p => p.Bookmarks)
                .HasForeignKey(d => d.UserBookmarked)
                .HasConstraintName("FK__Bookmark__UserBo__09A971A2");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comment__3214EC07D0554E6F");

            entity.ToTable("Comment");

            entity.Property(e => e.Body).HasMaxLength(255);

            entity.HasOne(d => d.Ticket).WithMany(p => p.Comments)
                .HasForeignKey(d => d.TicketId)
                .HasConstraintName("FK__Comment__TicketI__114A936A");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Comment__UserId__10566F31");
        });

        modelBuilder.Entity<Ticket>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ticket__3214EC0788C4BD3A");

            entity.ToTable("Ticket");

            entity.Property(e => e.Body).HasMaxLength(255);
            entity.Property(e => e.Resolution).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.UserClosedNavigation).WithMany(p => p.TicketUserClosedNavigations)
                .HasForeignKey(d => d.UserClosed)
                .HasConstraintName("FK__Ticket__UserClos__05D8E0BE");

            entity.HasOne(d => d.UserOpenedNavigation).WithMany(p => p.TicketUserOpenedNavigations)
                .HasForeignKey(d => d.UserOpened)
                .HasConstraintName("FK__Ticket__UserOpen__04E4BC85");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0727E3D5B2");

            entity.ToTable("User");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.PhotoUrl)
                .HasMaxLength(255)
                .HasColumnName("PhotoURL");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
