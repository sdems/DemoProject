using System;
using System.IO;
using System.Runtime.Serialization.Json;
using PlugWine.Collection;
using PlugWine.Model;

namespace PlugWine
{
    internal class ShapeManager
    {
        public ShapeCollection GetDefaultShapeCollection()
        {
            return new ShapeCollection()
            {
                new Circle("Nom_1",12),
                new Circle("Nom_2",15),
                new Triangle("Nom_3",16),
                new Square("Nom_4",17)
            };
        }

        public Stream Serialize(ShapeCollection shapeCollection)
        {
            Stream stream = new MemoryStream();
            DataContractJsonSerializer serializer = null;

            serializer = new DataContractJsonSerializer(shapeCollection.GetType());
            serializer.WriteObject(stream, shapeCollection);

            stream.Flush();
            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }

        public ShapeCollection DeserializeCollection(Stream stream)
        {
            ShapeCollection shapeCollection = null;
            var deserializer = new DataContractJsonSerializer(typeof(ShapeCollection));

            try
            {
                shapeCollection = (ShapeCollection)deserializer.ReadObject(stream);
            }
            catch (Exception e)
            {
                //TODO : Log/Show    
            }

            return shapeCollection;
        }
    }
}
