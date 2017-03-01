using System.Runtime.Serialization;

namespace PlugWine.Model
{
    [DataContract]
    abstract class AbstractShape
    {
        private const string DEFAULT_SURFACE_UNIT = "cm²";

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Surface { get; set; }
        [DataMember]
        public int Price { get; set; }

        public AbstractShape()
        {
        }

        public AbstractShape(string shapeName, int shapeSurface)
        {
            Name = shapeName;
            Surface = shapeSurface;
        }

        public abstract string GetShapeType();
        
        public virtual string GetSurfaceUnit()
        {
            return DEFAULT_SURFACE_UNIT;
        }
    }
}


