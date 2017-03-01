using System.Runtime.Serialization;

namespace PlugWine.Model
{
    [KnownType(typeof(Square))]
    [DataContract]
    class Square : AbstractShape
    {
        private const string SHAPE_TYPE = "Carre";

        public Square()
            : base()
        {

        }

        public Square(string shapeName, int shapeSurface)
            :base(shapeName,shapeSurface)
        {

        }

        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }
    }
}
