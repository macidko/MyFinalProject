using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstracts;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;

        public InMemoryProductDal()
        {
            //Oracle, Sql, Postgre, MongoDb
            _products = new List<Product>{
                new Product {ProductId = 1, CategoryId = 1, ProductName = "Bardak", UnitPrice = 15, UnitsInStock = 15},
                new Product {ProductId = 2, CategoryId = 1, ProductName = "Kamera", UnitPrice = 500, UnitsInStock = 3},
                new Product {ProductId = 3, CategoryId = 2, ProductName = "Telefon", UnitPrice = 1500, UnitsInStock = 2},
                new Product {ProductId = 4, CategoryId = 2, ProductName = "Klavye", UnitPrice = 150, UnitsInStock = 65},
                new Product {ProductId = 5, CategoryId = 2, ProductName = "Fare", UnitPrice = 85, UnitsInStock = 1}
            };
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        {
            ////LINQ(Language Integrated Query)kullanılmadan yapılabilecek delete işlemi.
            ////Eşleşen id değerine sahip _products'ın referans numarasını atayıp delete işlemi yapmak için Product değişkeni oluşturulur.
            //Product productToDelete = null;

            ////Foreach ile _products listesi dönülür ve parametre olarak gelen product.ProductId ile karşılaştırılır.
            //foreach (var p in _products)
            //{
            //    //Eşleştiği koşulda
            //    if (product.ProductId == p.ProductId)
            //    {
            //        //Referansı tutmak için oluşturduğumuz değişkene o anki liste elemanı atanır
            //        productToDelete = p;
            //    }
            //}
            ////foreach sonlandığında _products listesinden eşleşmiş referans numarasına sahip class (Product) kaldırılır.
            //_products.Remove(productToDelete);
            ////Bu şekilde yapılmadığı takdirde, parametre olarak gelen class referansı ile liste içerisindeki class referansı uyuşmaz. Ve silme işlemi gerçekleştirilemez.



            //SingleOrDefault tek bir eleman bulmaya yarar
            //_products'ı tek tek dolaşır.
            //Lambda (=>)
            //Bu yukarıdaki işlemin aynısını yapar.

            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);
        }
        public void Update(Product product)
        {
            //Gönderdiğim ürün id'sine sahip olan listedeki ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
        }

        //public List<Product> GetAll()
        //{
        //    return _products;
        //}

        //public List<Product> GetAllByCategory(int categoryId)
        //{
        //    return _products.Where(p => p.CategoryId == categoryId).ToList();
        //}

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }
    }
}
