using System;
using System.Collections.Generic;
using System.Data.Entity;
using IntranetPOPS1819.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IntranetTests.Tests
{
    [TestClass]
    public class CollaborateursTests
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
        public void CreerCreerCollaborateur_AvecUnNouveauCreerCollaborateur_ObtientTousLesCreerCollaborateurRenvoitBienLeCreerCollaborateur()
        {
            dal.AjoutCollaborateur("Minh", "Nguyen", "minh.nguyen@u-psud.fr", "mdp");
            List<Collaborateur> collab = dal.ObtenirTousLesCollaborateurs();

            Assert.IsNotNull(collab);
            Assert.AreEqual(1, collab.Count);
            Assert.AreEqual("Minh", collab[0].Nom);
            Assert.AreEqual("Nguyen", collab[0].Prenom);
            Assert.AreEqual("minh.nguyen@u-psud.fr", collab[0].Mail);
        }

        [TestMethod]
        public void AssignerServiceACollaborateur()
        {
            Service compta = dal.AjoutService("Comptabilité");
            Collaborateur n = dal.AjoutCollaborateur("Minh", "Nguyen", "minh.nguyen@u-psud.fr", "bonmotdepasse");
            dal.AssignerService(compta.Id, n.Id);
            Assert.AreEqual(compta, dal.ObtenirTousLesCollaborateurs()[0].Service);
        }
    }
}
