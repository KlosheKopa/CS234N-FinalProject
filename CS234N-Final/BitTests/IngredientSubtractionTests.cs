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
    public class IngredientSubtractionTests
    {
        BitContext dbContext;
        IngredientInventorySubtraction i;
        List<IngredientInventorySubtraction> subtractions;

        [SetUp]
        public void Setup()
        {
            dbContext = new BitContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void AddIngredientSubtraction()
        {
            subtractions = dbContext.IngredientInventorySubtraction.OrderBy(i => i.IngredientInventorySubtractionId).ToList();
            i = new IngredientInventorySubtraction();
            i.IngredientInventorySubtractionId = (subtractions.Count + 1);
            i.IngredientId = 1;
            i.TransactionDate = DateTime.Now;
            i.Reason = "Needed for new batch";
            i.BatchId = 3;
            i.Quantity = 10;
            dbContext.IngredientInventorySubtraction.Add(i);
            dbContext.SaveChanges();
            Assert.IsNotNull(dbContext.IngredientInventorySubtraction.Find(1));
        }
    }
}
