using PlugWine.Model;

namespace PlugWine
{
    class Factory
    {
        private const string CIRCLE_SHAPE_TYPE = "Cercle";
        private const string TRIANGLE_SHAPE_TYPE = "Triangle";
        private const string SQUARE_SHAPE_TYPE = "Carre";

        public AbstractShape GetShape(string shapeType, string shapeName, int shapeSurface)
        {
            AbstractShape shape = null;

            switch (shapeType)
            {
                case CIRCLE_SHAPE_TYPE:
                    shape = new Circle();
                    break;
                case TRIANGLE_SHAPE_TYPE:
                    shape = new Triangle();
                    break;
                case SQUARE_SHAPE_TYPE:
                    shape = new Square();
                    break;
            }

            shape.Name = shapeName;
            shape.Surface = shapeSurface;

            return shape;
        }
    }
}
