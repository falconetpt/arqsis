using System;

namespace Arqsis.Infrastructure.DAL.DTO.restriction
{
    public class RestrictionReadDto
    {
        public Guid Id { get; set; }
        public Guid BaseProductId { get; set; }
        public string BaseProductName { get; set; }
        public Guid CompatibleProductId { get; set; }
        public string CompatibleProductName { get; set; }
    }
}