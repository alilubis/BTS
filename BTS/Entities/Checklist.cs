using System.ComponentModel.DataAnnotations;

namespace BTS.Entities
{
    public class Checklist
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();   
        public string Name { get; set; } = string.Empty;
    }
}
