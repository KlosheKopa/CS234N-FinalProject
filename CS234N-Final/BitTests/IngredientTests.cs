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
    public class IngredientTests
    {
        BitContext dbContext;
        Ingredient i;
        List<Ingredient> ingredients;

        [SetUp]
        public void Setup()
        {
            dbContext = new BitContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void GetIngredientById()
        {
            i = dbContext.Ingredient.Find(1);
            Assert.AreEqual("Acid Malt", i.Name);
        }

    }
}
