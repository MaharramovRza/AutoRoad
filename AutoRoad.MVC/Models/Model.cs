using System;
using System.Collections.Generic;

namespace AutoRoad.MVC.Models;

public partial class Model
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int BrandId { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<CarPhoto> CarPhotos { get; set; } = new List<CarPhoto>();

    public virtual ICollection<Car> Cars { get; set; } = new List<Car>();
}
