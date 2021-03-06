﻿using System.Runtime.Serialization;

namespace PlugWine.Model
{
    [KnownType(typeof(Circle))]
    [DataContract]
    class Circle : AbstractShape
    {
        private const string SHAPE_TYPE = "Cercle";
        private readonly string _undefinedItem;

        public Circle()
            : base()
        {
            _undefinedItem ="Trust";
        }

        public Circle(string shapeName, int shapeSurface)
            :base(shapeName,shapeSurface)
        {
            _undefinedItem = shapeName;
        }

        public override string GetShapeType()
        {
            return SHAPE_TYPE;
        }
    }
}
