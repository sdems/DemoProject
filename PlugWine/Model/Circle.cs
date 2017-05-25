using System.Runtime.Serialization;

namespace PlugWine.Model
{
    [KnownType(typeof(Circle))]
    [DataContract]
    class Circle : AbstractShape
    {
        private const string SHAPE_TYPE = "Cercle";
        private readonly sting _undefinedItem;

        public Circle()
            : base()
        {
            _undefinedItem ="Trust";
        }

        public Circle(string shapeName, int shapeSurface)
            :base(shapeName,shapeSurface)
        {

        }

        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }
    }
}
