using System;
using System.Collections.Generic;

namespace AutoRoad.MVC.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public int UserRoleId { get; set; }

    public int UserStatusId { get; set; }

    public DateTime? RegisterDate { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual UserRole UserRole { get; set; } = null!;
}
