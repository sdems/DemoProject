using System.Runtime.Serialization;

namespace PlugWine.Model
{
    [KnownType(typeof(Triangle))]
    [DataContract]
    class Triangle : AbstractShape
    {
        private const string SHAPE_TYPE = "Triangle";

        public Triangle()
            : base()
        {

        }

        public Triangle(string shapeName, int shapeSurface)
            :base(shapeName,shapeSurface)
        {

        }

        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }
    }
}
