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
    public class RecipeTests
    {
        BitContext dbContext;
        Recipe r;
        List<Recipe> recipes;

        [SetUp]
        public void Setup()
        {
            dbContext = new BitContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void GetAllRecipes()
        {
            recipes = dbContext.Recipe.OrderBy(r => r.RecipeId).ToList();
            Assert.AreEqual(4, recipes.Count);
            Assert.AreEqual("Fuzzy Tales Juicy IPA", recipes[0].Name);
            PrintAll(recipes);
        }

        [Test]
        public void GetRecipeById()
        {
            r = dbContext.Recipe.Find(1);
            Assert.IsNotNull(r);
            Assert.AreEqual("Fuzzy Tales Juicy IPA", r.Name);
            Console.WriteLine(r.ToString());
        }

        [Test]
        public void GetRecipeUsingWhere()
        {
            recipes = dbContext.Recipe.Where(r => r.Name.Contains("Fuzzy Tales Juicy IPA")).OrderBy(r => r.RecipeId).ToList();
            Assert.AreEqual(1, recipes.Count);
            Assert.AreEqual(1, recipes[0].RecipeId);
            PrintAll(recipes);
        }

        

        public void PrintAll(List<Recipe> recipes)
        {
            foreach (Recipe r in recipes)
            {
                Console.WriteLine(r.ToString());
            }
        }

    }
}
