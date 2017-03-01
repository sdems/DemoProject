using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlugWine.Model;
using System.Collections.Generic;
using System.Linq;
using Moq;
using PlugWine.Pricer;

namespace PlugWine.Test
{
    [TestClass]
    public class Service_Test
    {
        [TestMethod]
        public void GetShapes_ShouldReturnShapesDescriptionAsStringCollection()
        {
            IEnumerable<string> expectedShapesDescription = new List<string>()
            {
                "Cercle - Nom_1 - 12cm²",
                "Cercle - Nom_2 - 15cm²",
                "Triangle - Nom_3 - 16cm²"
            };

            Service service = new Service();
            IEnumerable<string> actualShapesDescription = service.GetShapes();

            Assert.AreEqual(expectedShapesDescription.Count(), actualShapesDescription.Count());

            foreach (string actualShapeDescription in actualShapesDescription)
            {
                Assert.IsNotNull(expectedShapesDescription.SingleOrDefault<string>(x => x == actualShapeDescription));
            }
        }
        
        [TestMethod]
        public void Add_WhenValidShapeDescriptionIsAdded_ThenAbstractShapeInstanceShouldBeAdded()
        {
            string nameParam = "Nom_11";
            int surfaceParamAsInt = 40;

            string submittedParam = string.Format("Carre {0} {1}",nameParam,surfaceParamAsInt);
            string expectedAddedDescription = string.Format("Carre - {0} - {1}cm²", nameParam, surfaceParamAsInt);

            Service service = new Service();
            service.Add(submittedParam);
            string actualAddedDescription = service.GetShapes().SingleOrDefault<string>(x => x == expectedAddedDescription);

            Assert.IsFalse(string.IsNullOrEmpty(actualAddedDescription));
        }

        [TestMethod]
        public void SerializeCollection_ShouldWriteInFile()
        {
            string filePath = @"C:\Test\file.json";

            Service service = new Service();
            service.SerializeCollection(filePath);
        }

        [TestMethod]
        public void GetEstimations_ShouldReturnShapesDescriptionAndEstimationsAsStringCollection()
        {
            AbstractShape shape = new Circle(){Name = "CircleName",Surface = 12};
            string expectedEstimation = string.Format("{0} - {1} - {2}{3} - Estimation cout : {4}€",
                shape.GetShapeType(), shape.Name, shape.Surface, shape.GetSurfaceUnit(), 2 * shape.Surface);
 
            var pricerMock = new Mock<IPricer>();
            pricerMock
                .Setup(x => x.Price(It.IsAny<int>()))
                .Returns<int>((b) => b * 2);
            Service service = new Service();
            service.Add(shape);

            IEnumerable<string> actualeShapesEstimations = service.GetEstimations(pricerMock.Object);
            Assert.IsNotNull(actualeShapesEstimations.SingleOrDefault(x=>x==expectedEstimation));
        }
    }
}
