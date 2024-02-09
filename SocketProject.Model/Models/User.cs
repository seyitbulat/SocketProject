using Infrastructure.Model;
using System;
using System.Collections.Generic;

namespace SocketProject.Model.Models;

public partial class User : BaseEntity<long>
{
    public long Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? PhoneNumber { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<Friendship> FriendshipFriends { get; set; } = new List<Friendship>();

    public virtual ICollection<Friendship> FriendshipUsers { get; set; } = new List<Friendship>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
}
