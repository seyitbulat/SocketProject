﻿using System;
using System.Collections.Generic;

namespace SocketProject.Model.Models;

public partial class Message
{
    public long Id { get; set; }

    public long? FriendShipId { get; set; }

    public int? Status { get; set; }

    public long? UserId { get; set; }

    public long? CreatedBy { get; set; }

    public long? UpdatedBy { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public DateTime? DeletedDate { get; set; }

    public bool IsActive { get; set; }

    public virtual Friendship? FriendShip { get; set; }

    public virtual User? User { get; set; }
}
