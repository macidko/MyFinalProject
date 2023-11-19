using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstracts;
using Business.Constant;
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
            //return new Result(true, "Ürün Eklendi"); //sonrası sonuç (ctor ile parametre gönderilir ve değerler ctor ile proplara set edilir)
            //return new SuccessResult("Ürün Eklendi");
            if (product.ProductName.Length < 3)
            {
                //Magic string
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);//ekleme işlemi
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //iş kodları
            //Bir iş sınıfı, başka sınıfları new'lemez.

            //return _productDal.GetAll();//Filtrelememizi sağlar (Expression-predicate)

            //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal();

            if (DateTime.Now.Hour == 16)
            {
                //return new ErrorResult();
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 16)
            {
                //return new ErrorResult();
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }
    }
}
