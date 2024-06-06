using Autonet_Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet_Domain.Entities.Concrets;

public class Plate:BaseEntity
{
    public string? Plate_ { get; set; }
    public decimal? Price { get; set; }
    public string? Description {  get; set; }


    // Navigation Property

    public Seller? Seller { get; set; }
    public Place? Place { get; set; }

    // Foreign Key
    public int SellerId { get; set; }
    public int PlaceId { get; set; }

}
