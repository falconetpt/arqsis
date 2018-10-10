using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arqsis.Model.Finish
{
    public class Finish
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid FinishId { set; get; }
        [Required]
        [MaxLength(80)]
        public string Name { set; get; }

        protected internal Finish()
        {
            
        }

        public void UpdateInfo(string name)
        {
            Name = name;
        }
    }
}