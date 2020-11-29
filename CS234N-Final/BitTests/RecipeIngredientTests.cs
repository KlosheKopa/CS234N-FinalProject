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
    public class RecipeIngredientTests
    {
        BitContext dbContext;
        RecipeIngredient i;
        List<RecipeIngredient> recipeIngredients;

        [SetUp]
        public void Setup()
        {
            dbContext = new BitContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void GetIngredientsBasedOnRecipe()
        {
            Recipe r = dbContext.Recipe.Find(1);
            Assert.AreEqual("Fuzzy Tales Juicy IPA", r.Name);
            recipeIngredients = dbContext.RecipeIngredient.Where(i => i.RecipeId.Equals(r.RecipeId)).OrderBy(i => i.RecipeIngredientId).ToList();
            Assert.AreEqual(13, recipeIngredients.Count);
            PrintAll(recipeIngredients);

        }

        [Test]
        public void GetIngredientsWithName()
        {
            Recipe r = dbContext.Recipe.Find(1);
            Assert.AreEqual("Fuzzy Tales Juicy IPA", r.Name);
            recipeIngredients = dbContext.RecipeIngredient.Where(i => i.RecipeId.Equals(r.RecipeId)).OrderBy(i => i.RecipeIngredientId).ToList();
            Assert.AreEqual(13, recipeIngredients.Count);
            int n = 0;
            foreach (RecipeIngredient i in recipeIngredients)
            {
                List<Ingredient> s = dbContext.Ingredient.Where(s => s.IngredientId.Equals(i.IngredientId)).OrderBy(s => s.IngredientId).ToList();
                Console.WriteLine(i.RecipeIngredientId + ", " + i.IngredientId + ", " + s[0].Name + ", " + i.Quantity);
                n++;
            }
            Assert.AreEqual(recipeIngredients.Count, n);
            
        }


        public void PrintAll(List<RecipeIngredient> recipeIngredients)
        {
            foreach (RecipeIngredient i in recipeIngredients)
            {
                Console.WriteLine(i.ToString());
            }
        }

    }
}
