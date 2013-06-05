namespace RetailPOS.CommonLayer.DataTransferObjects.Category
{
    public class ProductCategoryDTO : BaseDTO
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}