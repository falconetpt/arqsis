using System.ComponentModel.DataAnnotations;

namespace Arqsis.Infrastructure.DAL.DTO.finish
{
    public class FinishWriteDto
    {
        [Required]
        [MaxLength(80)]
        public string Name { set; get; }
    }
}