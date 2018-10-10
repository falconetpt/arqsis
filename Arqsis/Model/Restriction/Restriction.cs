using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arqsis.Model.Restriction
{
    public class Restriction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid RestrictionId { set; get; }
        
        [Required]
        [ForeignKey("BaseProductId")]
        public virtual Product.Product BaseProduct { set; get; }
        public Guid BaseProductId { set; get; }
        [Required]
        [ForeignKey("CompatibleProductId")]
        public virtual Product.Product CompatibleProduct { set; get; }
        public Guid CompatibleProductId { set; get; }
    }
}