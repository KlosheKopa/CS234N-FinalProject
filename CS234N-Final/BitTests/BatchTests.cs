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
    public class BatchTests
    {
        BitContext dbContext;
        Batch b;
        List<Batch> batches;

        [SetUp]
        public void Setup()
        {
            dbContext = new BitContext();
            dbContext.Database.ExecuteSqlRaw("call usp_testingResetData()");
        }

        [Test]
        public void GetAllTest()
        {
            batches = dbContext.Batch.OrderBy(b => b.BatchId).ToList();
            Assert.AreEqual(4, batches.Count);

        }

        [Test]
        public void CreateBatch()
        {
            batches = dbContext.Batch.OrderBy(b => b.BatchId).ToList();
            b = new Batch();
            b.BatchId = batches.Count + 1;
            b.RecipeId = 3;
            b.EquipmentId = 1;
            b.Volume = 42;
            b.ScheduledStartDate = DateTime.Now;
            b.EstimatedFinishDate = new DateTime(2020, 12, 30, 00, 00, 01);
            dbContext.Batch.Add(b);
            dbContext.SaveChanges();
            Assert.IsNotNull(dbContext.Batch.Find(5));
            Console.WriteLine(dbContext.Batch.Find(5).ToString());
        }

        [Test]
        public void DeleteBatch()
        {
            b = dbContext.Batch.Find(2);
            dbContext.Batch.Remove(b);
            dbContext.SaveChanges();
            Assert.IsNull(dbContext.Batch.Find(2));
        }
    }
}
