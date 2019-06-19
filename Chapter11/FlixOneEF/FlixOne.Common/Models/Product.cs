using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlixOne.Common.Models
{
    public class Product    
    {
        [Key]
        public Guid Id { get; set; }
        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(400)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(max)")]
        public string Image { get; set; }
        [Column(TypeName = "decimal(5, 2)")]
        public decimal Price { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        [Column(TypeName = "bit")]
        public bool IsDeleted { get; set; } = false;
        public Guid CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}