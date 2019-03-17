using System.Collections.Generic;

namespace VisioAutomation.ShapeSheet.Query
{

    internal class ShapeCacheItemList : IEnumerable<ShapeCacheItem>
    {
        private List<ShapeCacheItem> _list_shapecacheitems;

        public ShapeCacheItemList()
        {
            this._list_shapecacheitems = new List<ShapeCacheItem>();
        }

        public ShapeCacheItemList(int capacity)
        {
            this._list_shapecacheitems = new List<ShapeCacheItem>(capacity);
        }

        public void Add(ShapeCacheItem item)
        {
            this._list_shapecacheitems.Add(item);
        }
        
        public IEnumerator<ShapeCacheItem> GetEnumerator()
        {
            return this._list_shapecacheitems.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Count
        {
            get
            {
                return this._list_shapecacheitems.Count;
            }
        }

        public int CountCells()
        {
            int n = 0;
            foreach (var shapecacheitem in this._list_shapecacheitems)
            {
                n += shapecacheitem.RowCount * shapecacheitem.SectionQuery.Columns.Count;
            }
            return n;
        }
    }
}