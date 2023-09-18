using System;
using System.Collections.Generic;

namespace AutoRoad.MVC.Models;

public partial class CarPhoto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int ModelId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Model Model { get; set; } = null!;
}
