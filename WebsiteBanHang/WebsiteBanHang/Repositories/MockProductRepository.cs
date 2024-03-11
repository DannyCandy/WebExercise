using System.Collections.Generic;
using System.Linq;
using WebsiteBanHang.Models; // Thay thế bằng namespace thực tế của bạn
namespace WebsiteBanHang.Repositories
{
    public class MockProductRepository : IProductRepository
    {
        private List<Product> _products = new List<Product>();

        public MockProductRepository()
        {
            // Tạo một số dữ liệu mẫu
            
        }

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            if(_products.Any())
            {
                product.Id = _products.Max(p => p.Id) + 1;
                _products.Add(product);
            }
            else
            {
                product.Id = 1;
                _products.Add(product);
            }
        }

        public void Update(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }

        public void Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

    }
}
