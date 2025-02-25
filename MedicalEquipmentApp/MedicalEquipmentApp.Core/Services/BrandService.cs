using MedicalEquipmentApp.Core.Contracts;
using MedicalEquipmentApp.Data;
using MedicalEquipmentApp.Infrastructure.Data.Domain;

namespace MedicalEquipmentApp.Core.Services
{
	public class BrandService : IBrandService
    {
        private readonly ApplicationDbContext _context;

        public BrandService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Brand GetBrandById(int brandId)
        {
            return _context.Brands.Find(brandId);
        }

        public List<Brand> GetBrands()
        {
            List<Brand> brands = _context.Brands.ToList();
            return brands;
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            return _context.Products.Where(x => x.BrandId == brandId).ToList();
        }
    }
}