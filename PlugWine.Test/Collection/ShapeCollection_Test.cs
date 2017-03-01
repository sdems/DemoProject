using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlugWine.Collection;
using PlugWine.Model;
using System.Linq;

namespace PlugWine.Test.Collection
{
    [TestClass]
    public class ShapeCollection_Test
    {
        [TestMethod]
        public void Add_ShouldAddTargetedInstanceInCollection()
        {
            AbstractShape expectedShape = new Square("SqareName", 44);
            ShapeCollection actualShapeCollection = new ShapeCollection();
            actualShapeCollection.Add(expectedShape);

            Assert.AreEqual(1, actualShapeCollection.Count);

            Assert.AreEqual(expectedShape.Name, actualShapeCollection.Single<AbstractShape>().Name);
            Assert.AreEqual(expectedShape.Surface, actualShapeCollection.Single<AbstractShape>().Surface);
        }
    }
}
