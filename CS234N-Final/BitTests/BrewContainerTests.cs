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
    class BrewContainerTests
    {
        BitContext dbContext;
        BrewContainer bC;
        List<BrewContainer> brewContainers;

        [SetUp]
        public void Setup()
        {
            dbContext = new BitContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void GetAllBrewContainers()
        {
            brewContainers = dbContext.BrewContainer.OrderBy(bC => bC.BrewContainerId).ToList();
            Assert.AreEqual(4, brewContainers.Count);
            PrintAll(brewContainers);
        }

        [Test]
        public void GetAllBrewContainersUsingWhere()
        {
            brewContainers = dbContext.BrewContainer.Where(bC => bC.ContainerStatusId.Equals(1)).ToList();
            Assert.AreEqual(2, brewContainers.Count);
            PrintAll(brewContainers);
        }

        public void PrintAll(List<BrewContainer> recipes)
        {
            foreach (BrewContainer r in recipes)
            {
                Console.WriteLine(r.ToString());
            }
        }

    }
}
