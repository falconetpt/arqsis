using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arqsis.Model.Category
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid CategoryId { set; get; }
        public string Name { set; get; }
        public Guid? ParentId { get; set; }
        
        [ForeignKey("ParentId")]
        public virtual Category ParentCategory { set; get; }
        
        public void UpdateInfo(string name)
        {
            Name = name;
        }
    }
}
