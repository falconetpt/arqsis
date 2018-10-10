using System;
using System.Collections.Generic;
using System.Linq;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DTO.finish;
using Arqsis.Model.Finish;

namespace Arqsis.Infrastructure.Repositories
{
    public class FinishRepository : IBaseRepository<Finish, FinishReadDto, FinishWriteDto>
    {
        private readonly ApiContext _context;
        private readonly FinishAssembler _assembler;
        
        public FinishRepository(ApiContext context)
        {
            _context = context;
            _assembler = new FinishAssembler();
        }
        
        public IEnumerable<FinishReadDto> GetAll()
        {
            return _context.Finishes.ToList()
                .Select(x => _assembler.ToDto(x)).ToList();
        }

        public Finish Add(FinishWriteDto finishWriteDto)
        {
            Finish finish = _assembler.ToDomainObject(finishWriteDto);
            Finish result = _context.Add(finish).Entity;
            _context.SaveChanges();
            return result;
        }

        public FinishReadDto GetById(Guid id)
        {
            Finish finish = GetFinishById(id);
            return _assembler.ToDto(finish);
        }

        public Finish GetEntityById(Guid id)
        {
            return GetFinishById(id);
        }

        public FinishReadDto UpdateElement(Guid id, FinishWriteDto finishWriteDto)
        {
            Finish finish = GetFinishById(id);
            finish.UpdateInfo(finishWriteDto.Name);
            _context.SaveChanges();
            return GetById(id);
        }
        
        public FinishReadDto DeleteById(Guid id)
        {
            Finish finish = GetFinishById(id);
            _context.Remove(finish);
            _context.SaveChanges();
            return _assembler.ToDto(finish);
        }
        
        
        private Finish GetFinishById(Guid finishId)
        {
            return _context.Finishes.Find(finishId);
        }
    }
}