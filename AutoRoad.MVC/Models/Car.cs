using System;
using System.Collections.Generic;

namespace AutoRoad.MVC.Models;

public partial class Car
{
    public int Id { get; set; }

    public int ModelId { get; set; }

    public decimal Price { get; set; }

    public int Year { get; set; }

    public int FuelId { get; set; }

    public int TransmissionId { get; set; }

    public int BanId { get; set; }

    public byte Doors { get; set; }

    public byte Seats { get; set; }

    public bool HasGarage { get; set; }

    public int CarCount { get; set; }

    public bool IsMain { get; set; }

    public DateTime? Created { get; set; }

    public DateTime? Updated { get; set; }

    public virtual Ban Ban { get; set; } = null!;

    public virtual ICollection<CarPhoto> CarPhotos { get; set; } = new List<CarPhoto>();

    public virtual Fuel Fuel { get; set; } = null!;

    public virtual Model Model { get; set; } = null!;

    public virtual Transmission Transmission { get; set; } = null!;
}
