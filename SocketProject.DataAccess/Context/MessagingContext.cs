using Microsoft.EntityFrameworkCore;
using SocketProject.Model.Models;

namespace SocketProject.DataAccess.Context;

public partial class MessagingContext : DbContext
{
    public MessagingContext()
    {
    }

    public MessagingContext(DbContextOptions<MessagingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Friendship> Friendships { get; set; }

    public virtual DbSet<Message> Messages { get; set; }


    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-R04PVQ3\\SQLEXPRESS; Initial Catalog=MessagingDb; Integrated Security=true; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Friendship>(entity =>
        {
            entity.HasIndex(e => e.FriendId, "IX_Friendships_FriendId");

            entity.HasIndex(e => e.UserId, "IX_Friendships_UserId");

            entity.HasOne(d => d.Friend).WithMany(p => p.FriendshipFriends)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.User).WithMany(p => p.FriendshipUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasOne(d => d.FriendShip).WithMany(p => p.Messages)
                .HasForeignKey(d => d.FriendShipId)
                .HasConstraintName("FK_Messages_Friendships");

            entity.HasOne(d => d.User).WithMany(p => p.Messages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Messages_Users");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasIndex(e => e.UserId, "IX_Notifications_UserId");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications).HasForeignKey(d => d.UserId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email)
                .HasMaxLength(32)
                .IsUnicode(false);
            entity.Property(e => e.FirstName).HasMaxLength(32);
            entity.Property(e => e.LastName).HasMaxLength(32);
            entity.Property(e => e.Password).HasMaxLength(24);
            entity.Property(e => e.PhoneNumber).HasMaxLength(32);
            entity.Property(e => e.Username)
                .HasMaxLength(24)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasIndex(e => e.RoleId, "IX_UserRoles_RoleId");

            entity.HasIndex(e => e.UserId, "IX_UserRoles_UserId");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles).HasForeignKey(d => d.RoleId);

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles).HasForeignKey(d => d.UserId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
