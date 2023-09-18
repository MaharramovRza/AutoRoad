using System;
using System.Collections.Generic;

namespace AutoRoad.MVC.Models;

public partial class Ban
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
