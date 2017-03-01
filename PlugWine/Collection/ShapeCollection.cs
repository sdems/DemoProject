using PlugWine.Model;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PlugWine.Collection
{
    [KnownType(typeof(Circle))]
    [KnownType(typeof(Triangle))]
    [KnownType(typeof(Square))]
    [DataContract]
    class ShapeCollection:ICollection<AbstractShape>
    {
        private IList<AbstractShape> _shapeList;

        [DataMember]
        private  IList<AbstractShape> ShapeList
        {
            get
            {
                if(_shapeList == null)
                {
                    _shapeList = new List<AbstractShape>();
                }

                return _shapeList;
            }
        }

        public void Add(AbstractShape item)
        {
            ShapeList.Add(item);
        }

        public void Clear()
        {
            ShapeList.Clear();
        }

        public bool Contains(AbstractShape item)
        {
            return ShapeList.Contains(item);
        }

        public void CopyTo(AbstractShape[] array, int arrayIndex)
        {
            ShapeList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return ShapeList.Count; }
        }

        public bool IsReadOnly
        {
            get { return ShapeList.IsReadOnly; }
        }

        public bool Remove(AbstractShape item)
        {
            return ShapeList.Remove(item);
        }

        public IEnumerator<AbstractShape> GetEnumerator()
        {
            return ShapeList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
