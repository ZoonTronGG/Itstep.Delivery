using System.ComponentModel.DataAnnotations;

namespace Itstep.Delivery.GlobalDictionary.Api.Entities;

public class Country
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<City> Cities { get; set; } = null!;
}
