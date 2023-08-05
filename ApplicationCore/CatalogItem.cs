using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public  class CatalogItem : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }  
        public string PictureUri { get; set; }  
        public int CatalogTypeId { get; set; }
        public CatalogType? CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand? CatalogBrand { get; set; }


        public CatalogItem(int catalogTypeId,
            int catalogBrand,
            string description,
            string name,
            int price,
            string pictureUri)
        {
            CatalogTypeId = catalogTypeId;
            CatalogBrandId = catalogBrand;
            Description = description;
            Name = name;
            Price = price;
            PictureUri = pictureUri;
        }
    }
}
