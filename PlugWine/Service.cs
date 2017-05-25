using PlugWine.Collection;
using PlugWine.Model;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using PlugWine.Pricer;

namespace PlugWine
{
    public class Service
    {
        private ShapeCollection _currentShapeCollection;
        private ShapeManager _shapeManager;
        private Factory _factory;

        private Factory Factory
        {
            get
            {
                if(_factory == null)
                {
                    _factory = new Factory();
                }

                return _factory;
            }
        }

        private ShapeManager ShapeManager
        {
            get
            {
                if (_shapeManager == null)
                {
                    _shapeManager = new ShapeManager();
                }

                return _shapeManager;
            }
        }

        private ShapeCollection CurrentShapeCollection
        {
            get
            {
                if (_currentShapeCollection == null)
                {
                    _currentShapeCollection = ShapeManager.GetDefaultShapeCollection();
                }

                return _currentShapeCollection;
            }
        }

        public IEnumerable<string> GetShapes()
        {
            IList<string> shapesDescription = new List<string>();

            foreach (AbstractShape abstractShape in CurrentShapeCollection)
            {
                shapesDescription.Add(GetShapeDescription(abstractShape));
            }

            return shapesDescription;
        }

        public IEnumerable<string> GetEstimations(IPricer pricerMockObject)
        {
            IList<string> shapesDescription = new List<string>();

            foreach (AbstractShape abstractShape in CurrentShapeCollection)
            {
                shapesDescription.Add(GetShapeEstimation(abstractShape, pricerMockObject));
            }

            return shapesDescription;
        }

        public void Remove(string shapeDescription)
        {
            
        }

        public void Add(string shapeDescription)
        {
            int surface;
            string[] args = shapeDescription.Split(' ');

            if(int.TryParse(args[2],out surface))
            {
                var shape = Factory.GetShape(args[0], args[1], surface);
                CurrentShapeCollection.Add(shape);
            }
        }

        public void SerializeCollection(string filePath)
        {
            using(var stream = ShapeManager.Serialize(CurrentShapeCollection))
            {
                using(var fileStream = File.Create(filePath))
                {
                    byte[] buffer = new byte[stream.Length];

                    while(stream.Read(buffer,0,buffer.Length)>0)
                    {
                        fileStream.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }

        internal void Add(AbstractShape shape)
        {
            CurrentShapeCollection.Add(shape);
        }

        private string GetShapeEstimation(AbstractShape shape, IPricer pricer)
        {
            string baseStr = GetShapeDescription(shape);

            return string.Format("{0} - Estimation cout : {1}", baseStr, pricer.Price(shape.Surface).ToString("C", CultureInfo.CurrentCulture));
        }

        internal ShapeCollection DeserializeCollection(string filePath)
        {
            ShapeCollection shapeCollection = null;

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                shapeCollection = ShapeManager.DeserializeCollection(stream);
            }

            return shapeCollection;
        }

        private string GetShapeDescription(AbstractShape shape)
        {
            return string.Format("{0} - {1} - {2}{3}", shape.GetShapeType(), shape.Name, shape.Surface, shape.GetSurfaceUnit());
        }
    }
}
