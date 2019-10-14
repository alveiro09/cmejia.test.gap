﻿using System;
namespace cmejia.test.gap.Models
{
    public partial class TypeCovering
    {
        public TypeCovering()
        {
            Policy = new HashSet<Policy>();
        }

        public int TypeCoveringId { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public double? Percentage { get; set; }

        public virtual ICollection<Policy> Policy { get; set; }
    }
}
