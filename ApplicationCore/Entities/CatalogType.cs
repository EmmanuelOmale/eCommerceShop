using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public class CatalogType : BaseEntity
    {
        public string Type { get; set; }
        public CatalogType(string type)
        {
            Type = type;
        }
    }
}
