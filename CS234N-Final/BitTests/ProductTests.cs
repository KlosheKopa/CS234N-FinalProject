using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;
using BitEFClasses.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BitTests
{
    [TestFixture]
    public class ProductTests
    {
        BitContext dbContext;
        Product p;
        List<Product> products;

        [SetUp]
        public void SetUp()
        {
            dbContext = new BitContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void GetAllProducts()
        {
            products = dbContext.Product.OrderBy(p => p.BatchId).ToList();
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual(3, products[0].BatchId);
        }

        
    }
}
