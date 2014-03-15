using System;
using DrugManagement.Data;
using DrugManagement.Data.Contracts;
using DrugManagement.Data.Helper;
using DrugManagement.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrugManagement.Tests
{
    [TestClass]
    public class UnitTestDrug
    {
        [TestMethod]
        public void TestMethodInsert()
        {
            var uow = new ManagementUow(new RepositoryProvider(new RepositoryFactories()));
            uow.Drugs.Add(new Drug
            {
                Name = "Ben-u-ron",
                CapsuleNumber = 10,
                Category = "Orais Sólidas",
                Dosage = "1g",
                Obs = ""
            });
        }
    }
}
