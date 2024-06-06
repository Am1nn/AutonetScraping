using Autonet_Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet_Domain.Entities.Concrets;

public class Place:BaseEntity
{
    public string? Place_ {  get; set; }

    // Navigation Property
    public ICollection<Plate?>? Plates { get; set; }

}
