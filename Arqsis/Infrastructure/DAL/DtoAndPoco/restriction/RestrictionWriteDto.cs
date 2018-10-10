using System;
using System.ComponentModel.DataAnnotations;

namespace Arqsis.Infrastructure.DAL.DTO.restriction
{
    public class RestrictionWriteDto
    {
        [Required]
        public Guid BaseProductId;

        [Required] 
        public Guid CompatibleProductId;
    }
}