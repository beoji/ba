namespace ba.Dtos;

public class ProductCreateDto
{
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public decimal Price { get; set; }
    public DateTime TimeStamp { get; set; }

}