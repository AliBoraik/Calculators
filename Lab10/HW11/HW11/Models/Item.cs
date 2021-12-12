using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HW11.Models
{
    public class Item
    {
        [Key] public string Operation { get; set; }

        [DisplayName("Item Value")] public double Value { get; set; }
    }
}