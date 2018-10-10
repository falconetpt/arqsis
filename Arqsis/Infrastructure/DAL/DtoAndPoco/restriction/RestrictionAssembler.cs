using Arqsis.Model.Restriction;

namespace Arqsis.Infrastructure.DAL.DTO.restriction
{
    public class RestrictionAssembler : IBaseAssembler<RestrictionReadDto, RestrictionWritePoco, Restriction>
    {
        public RestrictionReadDto ToDto(Restriction baseObject)
        {
            RestrictionReadDto restrictionReadDto = new RestrictionReadDto();
            restrictionReadDto.Id = baseObject.RestrictionId;
            restrictionReadDto.BaseProductId = baseObject.BaseProductId;
            restrictionReadDto.BaseProductName = baseObject.BaseProduct?.Name;
            restrictionReadDto.CompatibleProductId = baseObject.CompatibleProductId;
            restrictionReadDto.CompatibleProductName = baseObject.CompatibleProduct?.Name;

            return restrictionReadDto;
        }

        public Restriction ToDomainObject(RestrictionWritePoco dto)
        {
            Restriction restriction = new Restriction();
            restriction.BaseProduct = dto.BaseProduct;
            restriction.BaseProductId = dto.BaseProduct.Id;
            restriction.CompatibleProduct = dto.CompatibleProduct;
            restriction.CompatibleProductId = dto.CompatibleProduct.Id;

            return restriction;
        }
    }
}