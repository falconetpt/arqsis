using System;
using System.Collections.Generic;
using System.Linq;
using Arqsis.Infrastructure.Context;
using Arqsis.Infrastructure.DAL.DtoAndPoco.product;
using Arqsis.Infrastructure.DAL.DtoAndPojo.product;
using Arqsis.Infrastructure.DAL.DTO.product;
using Arqsis.Infrastructure.DAL.DTO.restriction;
using Arqsis.Model.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Arqsis.Infrastructure.Repositories
{
    public class ProductRepository : IBaseRepository<Product, ProductReadDto, ProductWritePoco>
    {
        private readonly ApiContext _context;
        private readonly ProductAssembler _assembler;
        private readonly RestrictionAssembler _restrictionAssembler;
        
        public ProductRepository(ApiContext context)
        {
            _context = context;
            _assembler = new ProductAssembler();
            _restrictionAssembler = new RestrictionAssembler();
        }

        public IEnumerable<ProductReadDto> GetAll()
        {
            return _context.Products
                .Include(p => p.Finish)
                .Select(p => _assembler.ToDto(p))
                .ToList();
        }

        public Product Add(ProductWritePoco finishWriteDto)
        {
            Product result = _context.Products.Add(_assembler.ToDomainObject(finishWriteDto)).Entity;
            _context.SaveChanges();
            return result;
        }

        public ProductReadDto GetById(Guid id)
        {
            if (GetEntityById(id) == null)
            {
                return null;
            }
            
            return _assembler.ToDto(GetEntityById(id));
        }

        public Product GetEntityById(Guid id)
        {
            return _context.Products
                .Include(p => p.Finish)
                .FirstOrDefault(x => x.Id == id);
        }

        public ProductReadDto UpdateElement(Guid id, ProductWritePoco finishWriteDto)
        {
            Product product = GetEntityById(id);

            product.Finish = finishWriteDto.Finish;
            product.Dimension = finishWriteDto.Dimension;
            product.Name = finishWriteDto.Name;

            _context.SaveChanges();

            return _assembler.ToDto(product);
        }

        public ProductReadDto DeleteById(Guid id)
        {
            Product product = GetEntityById(id);
            _context.Products.Remove(product);

            return _assembler.ToDto(product);
        }

        public IEnumerable<ProductReadDto> getProductsByName(string name)
        {
            return _context.Products
                .Include(p => p.Finish)
                .Where(x => x.Name == name)
                .Select(x => _assembler.ToDto(x))
                .ToList();
        }
        
        public IEnumerable<ProductReadDto> getProductComponents(Guid id)
        {
            return _context.Restrictions
                .Include(r => r.BaseProduct)
                .Include(r => r.CompatibleProduct)
                .Where(r => r.BaseProductId == id)
                .Select(r => GetById(r.CompatibleProductId))
                .ToList();
        }
        
        public IEnumerable<ProductReadDto> getParentProducts(Guid id)
        {
            return _context.Restrictions
                .Include(r => r.BaseProduct)
                .Include(r => r.CompatibleProduct)
                .Where(r => r.CompatibleProductId == id)
                .Select(r => GetById(r.BaseProductId))
                .ToList();
        }

        public IEnumerable<RestrictionReadDto> getProductRestrictions(Guid id)
        {
            return _context.Restrictions
                .Include(r => r.BaseProduct)
                .Include(r => r.CompatibleProduct)
                .Where(r => r.BaseProductId == id)
                .Select(r => _restrictionAssembler.ToDto(r))
                .ToList();
        }
    }
}