﻿using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;

namespace ConsoleUI
{
    //SOLID
    //O - Open Closed Principle
    internal class Program
    {
        static void Main(string[] args)
        {
            //DTO- DATA TRANSFORMATION OBJECTS
            //ProductTest();
            //CategoryTest();
            //ProductDetailTest();
            //DataResultTest();


        }

        private static void DataResultTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetProductDetails();
            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryName);
                    Console.WriteLine(DateTime.Now.Hour == 16);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        //private static void ProductDetailTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());
        //    foreach (var product in productManager.GetProductDetails())
        //    {
        //        Console.WriteLine(product.ProductName + " / " + product.CategoryName);
        //    }
        //}

        //private static void CategoryTest()
        //{
        //    CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        //    foreach (var category in categoryManager.GetAll())
        //    {
        //        Console.WriteLine(category.CategoryName);
        //    }
        //}

        //private static void ProductTest()
        //{
        //    ProductManager productManager = new ProductManager(new EfProductDal());

        //    //foreach (var product in productManager.GetAll())
        //    //{
        //    //    Console.WriteLine(product.ProductName);
        //    //}
        //    //foreach (var product in productManager.GetAllByCategoryId(2))
        //    //{
        //    //    Console.WriteLine(product.ProductName);
        //    //}
        //    foreach (var product in productManager.GetByUnitPrice(50, 100))
        //    {
        //        Console.WriteLine(product.ProductName);
        //    }
        //}
    }
}