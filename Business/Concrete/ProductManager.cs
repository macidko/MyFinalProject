using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        //contructor injection
        public ProductManager(IProductDal IProductDal)
        {
            _productDal = IProductDal;
        }

        public IResult Add(Product product)
        {
            //business codes
            //Request-response
            _productDal.Add(product);//ekleme işlemi
            //return new Result(true, "Ürün Eklendi"); //sonrası sonuç (ctor ile parametre gönderilir ve değerler ctor ile proplara set edilir)
            //return new SuccessResult("Ürün Eklendi");
            return new SuccessResult();
        }

        public List<Product> GetAll()
        {
            //iş kodları
            //Bir iş sınıfı, başka sınıfları new'lemez.

            return _productDal.GetAll();//Filtrelememizi sağlar (Expression-predicate)

            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal();

        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public Product GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
