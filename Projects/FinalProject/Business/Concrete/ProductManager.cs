using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal) 
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            // business codes
            _productDal.Add(product);
            return new Result(true, "Ürün eklendi.");
        }

        public List<Product> GetAll()
        {
            // İş kodları
            // Yetkisi var mı?
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _productDal.GetAll(p => p.CategoryId == categoryId);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(x => x.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }

        //public List<Product> GetAllByCategory(int categoryId)
        //{
        //    return _productDal.GetAllByCategory(categoryId);
        //}
    }
}
