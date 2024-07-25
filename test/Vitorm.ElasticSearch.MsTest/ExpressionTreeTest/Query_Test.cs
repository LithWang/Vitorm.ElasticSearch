﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

using Vit.Linq.ExpressionTree.ExpressionTreeTest;

namespace Vitorm.MsTest.ExpressionTreeTest
{
    [TestClass]
    public class Query_Test
    {
        [TestMethod]
        public void TestQueryable()
        {
            var initUsers = ExpressionTester.GetSourceData();

            using var dbContext = DataSource.CreateDbContextForWriting();
            var dbSet = dbContext.DbSet<ExpressionTester.User>();

            dbSet.TryDropTable();
            dbSet.TryCreateTable();
            dbSet.AddRange(initUsers);

            var query = dbSet.Query();
            ExpressionTester.TestQueryable(query);
        }
    }
}
