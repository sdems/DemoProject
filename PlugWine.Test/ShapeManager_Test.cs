using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlugWine.Model;
using System.Collections.Generic;
using System.Linq;
using PlugWine.Collection;
using System.IO;

namespace PlugWine.Test
{
    [TestClass]
    public class ShapeManager_Test
    {
        [TestMethod]
        public void GetDefaultShapeCollection_ShouldReturnDefaultObjectInstanceCollection()
        {
            IEnumerable<AbstractShape> expectedShapeCollection = new List<AbstractShape>() 
            { 
                new Circle("Nom_1",12),
                new Circle("Nom_2",15),
                new Triangle("Nom_3",16)
            };

            ShapeManager shapeManager = new ShapeManager();

            ShapeCollection actualShapeCollection = shapeManager.GetDefaultShapeCollection();

            Assert.AreEqual(expectedShapeCollection.Count(), actualShapeCollection.Count());
            
            foreach (AbstractShape expectedAbstractShape in expectedShapeCollection)
            {
                Assert.IsNotNull(actualShapeCollection.SingleOrDefault<AbstractShape>(x => x.Name == expectedAbstractShape.Name && x.Surface == expectedAbstractShape.Surface));
            }
        }

        [Ignore]
        [TestMethod]
        public void Serialize_ShouldReturnUnEmptyStream()
        {
            var shapeCollection = new ShapeCollection()
            {
                new Circle("Nom_1",12),
                new Circle("Nom_2",15),
                new Triangle("Nom_3",16)
            };

            var service = new ShapeManager();
            Stream stream = service.Serialize(shapeCollection);

            Assert.IsTrue(stream.Length > 0);
        }

        [Ignore]
        [TestMethod]
        public void DeserializeCollection_ShouldInstanciateCollection()
        {
            string filePath = @"C:\Test\file.json";
            ShapeCollection shapeCollection = null;
            ShapeManager shapeManeger = new ShapeManager();

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                shapeCollection = shapeManeger.DeserializeCollection(stream);
            }

        }
    }
}
