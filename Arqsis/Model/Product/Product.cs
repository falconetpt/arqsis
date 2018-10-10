using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arqsis.Model.Product
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { set; get; }
        public string Name { set; get; }
        
        [ForeignKey("FinishId")]
        public virtual Finish.Finish Finish { get; set; }
        public Guid FinishId { get; set; }
        
        public Dimension.Dimension Dimension { set; get; }
        
    }
}
