using Autonet_Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autonet_Domain.Entities.Concrets
{
    public class Phone:BaseEntity
    {
        public string? Phone_ {  get; set; }

        //Navigaton Property
        public Seller? Seller { get; set;}

        // Foreign Key
        public int SellerId { get; set; }

    }
}