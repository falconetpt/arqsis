using System;
using System.ComponentModel.DataAnnotations;

namespace Arqsis.Infrastructure.DAL.DTO.finish
{
    public class FinishReadDto
    {
        public Guid Id { set; get; }
        public string Name { set; get; }
    }
}