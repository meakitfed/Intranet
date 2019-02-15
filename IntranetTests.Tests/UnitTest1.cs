using System;
using System.Data.Entity;
using IntranetPOPS1819.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntranetTests.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IDal dal;

        [TestInitialize]
        public void Init_AvantChaqueTest()
        {
            IDatabaseInitializer<BddContext> init = new DropCreateDatabaseAlways<BddContext>();
            Database.SetInitializer(init);
            init.InitializeDatabase(new BddContext());

            dal = new Dal();
            dal.InitializeBdd();
        }

        [TestCleanup]
        public void ApresChaqueTest()
        {
            dal.Dispose();
        }

        [TestMethod]
        public void CreerService_CreerMissionAvecService_MissionPresentDansService()
        {
            Service s = dal.AjoutService("Comptabilité");
            Mission m = dal.AjoutMission("ProjetGL", s.Id);

            Assert.AreEqual(s.Missions[0], m);
            Assert.AreEqual(s, m.Service);
        }
    }
}
