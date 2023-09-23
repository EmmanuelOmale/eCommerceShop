using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;

namespace ApplicationCore.Entities
{
    public class CatalogItem : BaseEntity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string PictureUri { get; private set; }
        public int CatalogTypeId { get; private set; }
        public CatalogType? CatalogType { get; private set; }
        public int CatalogBrandId { get; private set; }
        public CatalogBrand? CatalogBrand { get; private set; }

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

        public void UpdateDetails(CatalogItemDetails details)
        {
            Guard.Against.NullOrEmpty(details.Name, nameof(details.Name));
            Guard.Against.NullOrEmpty(details.Description, nameof(details.Description));
            Guard.Against.NegativeOrZero(details.Price, nameof(details.Price));

            Name = details.Name;
            Description = details.Description;
            Price = details.Price;
        }

        public void UpdateBrand(int catalogBrandId)
        {
            Guard.Against.Zero(catalogBrandId, nameof(catalogBrandId));
            CatalogBrandId = catalogBrandId;
        }

        public void UpdateType(int catalogTypeId)
        {
            Guard.Against.Zero(catalogTypeId, nameof(catalogTypeId));
            CatalogTypeId = catalogTypeId;
        }

        public void UpdatePictureUri(string pictureName)
        {
            if (string.IsNullOrEmpty(pictureName))
            {
                PictureUri = string.Empty;
                return;
            }
            PictureUri = $"images\\products\\{pictureName}?{new DateTime().Ticks}";
        }

        public readonly record struct CatalogItemDetails
        {
            public string? Name { get; }
            public string? Description { get; }
            public decimal Price { get; }

            public CatalogItemDetails(string? name, string? description, decimal price)
            {
                Name = name;
                Description = description;
                Price = price;
            }
        }
    }
}
