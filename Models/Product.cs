using System.ComponentModel.DataAnnotations;

namespace ba.Models;

public class Product
{
    public int Id { get; set; }
    [MaxLength(250)]
    public string Name { get; set; }
    public string? ShortDescription { get; set; }

    public decimal? Price { get; set; }
    public DateTime TimeStamp { get; set; }
}