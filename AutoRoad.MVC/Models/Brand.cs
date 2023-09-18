using System;
using System.Collections.Generic;

namespace AutoRoad.MVC.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
