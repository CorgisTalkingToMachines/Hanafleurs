namespace API.Application.DataObjects.Commands
{
    public class CreateProductCommand
    {
        // "ProductName", "Description", "Price", "Season", "UsageContexte", "FlowerType", "FlowerCareAdvice"
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string SeasonDescription { get; set; }
        public string UsageContext { get; set; }
        public string FlowerType { get; set; }

        public string FlowerCareAdvice { get; set; }

        public CreateProductCommand(string name, string description, int price, string seasonDescription, string usageContext, string flowerType, string flowerCareAdvice)
        {
            Name = name;
            Description = description;
            Price = price;
            SeasonDescription = seasonDescription;
            UsageContext = usageContext;
            FlowerType = flowerType;
            FlowerCareAdvice = flowerCareAdvice;
        }


    }
}
