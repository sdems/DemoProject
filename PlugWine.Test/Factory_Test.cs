using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlugWine.Model;
using System;
using System.Collections.Generic;

namespace PlugWine.Test
{
    [TestClass]
    public class Factory_Test
    {
        [TestMethod]
        public void GetInstance_ShouldReturnInstanceOfTargetedShape()
        {
            var argsList = new List<string>()
            {
                "Cercle NomCercle 12",
                "Triangle NomTriangle 10",
                "Carre NomCarre 12"
            };

            var factory = new Factory();
            AbstractShape actualShape = null;

            foreach(string args in argsList)
            {
                Type expectedType = null;

                string[] splitedArgs = args.Split(' ');
                actualShape = factory.GetShape(splitedArgs[0], splitedArgs[1], int.Parse(splitedArgs[2]));

                switch (splitedArgs[0])
                {
                    case "Cercle":
                        expectedType = typeof(Circle);
                        break;
                    case "Triangle":
                        expectedType = typeof(Triangle);
                        break;
                    case "Carre":
                        expectedType = typeof(Square);
                        break;
                }

                Assert.IsInstanceOfType(actualShape, expectedType);
                Assert.AreEqual(splitedArgs[0],actualShape.GetShapeType());
                Assert.AreEqual(splitedArgs[1],actualShape.Name);
                Assert.AreEqual(int.Parse(splitedArgs[2]),actualShape.Surface);
            }
        }
    }
}
