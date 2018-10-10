using System;
using System.Collections.Generic;
using System.Linq;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DTO.restriction;
using Arqsis.Model.Restriction;
using Microsoft.EntityFrameworkCore;

namespace Arqsis.Infrastructure.Repositories
{
    public class RestrictionRepository : IBaseRepository<Restriction, RestrictionReadDto, RestrictionWritePoco>
    {
        private readonly ApiContext _context;
        private readonly RestrictionAssembler _assembler;
        
        public RestrictionRepository(ApiContext context)
        {
            _context = context;
            _assembler = new RestrictionAssembler();
        }
        
        public IEnumerable<RestrictionReadDto> GetAll()
        {
            return _context.Restrictions
                .Include(r => r.BaseProduct)
                .Include(r => r.CompatibleProduct)
                .Select(r => _assembler.ToDto(r))
                .ToList();
        }

        public Restriction Add(RestrictionWritePoco writeDto)
        {
            Restriction restriction = _assembler.ToDomainObject(writeDto);
            restriction = _context.Add(restriction).Entity;
            _context.SaveChanges();

            return restriction;
        }

        public RestrictionReadDto GetById(Guid id)
        {
            if (GetEntityById(id) == null)
            {
                return null;
            }

            return _assembler.ToDto(GetEntityById(id));
        }

        public Restriction GetEntityById(Guid id)
        {
            return _context.Restrictions
                    .Include(r => r.BaseProduct)
                    .Include(r => r.CompatibleProduct)
                    .FirstOrDefault(x => x.RestrictionId == id);
        }

        public RestrictionReadDto UpdateElement(Guid id, RestrictionWritePoco finishWriteDto)
        {
            throw new NotImplementedException();
        }

        public RestrictionReadDto DeleteById(Guid id)
        {
            Restriction restriction = GetEntityById(id);
            
            if (restriction == null)
            {
                return null;
            }

            _context.Remove(restriction);
            _context.SaveChanges();

            return _assembler.ToDto(restriction);
        }
    }
}