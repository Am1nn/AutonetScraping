using Autonet_Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet_Domain.Entities.Concrets;

public class Seller:BaseEntity
{
    public string? Username { get; set; }
    
    // Navigation Property
    public ICollection<Plate?>? Plates { get; set; }
    public ICollection<Phone>? Phones { get; set; }


}
