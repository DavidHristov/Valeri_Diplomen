using MedicalEquipmentApp.Infrastructure.Data.Domain;

namespace MedicalEquipmentApp.Core.Contracts
{
	public interface IBrandService
    {
        List<Brand> GetBrands();
        Brand GetBrandById(int brandId);
        List<Product> GetProductsByBrand(int brandId);
    }
}