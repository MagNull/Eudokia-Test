using System.Collections.Generic;
using System.Linq;

namespace Sources.Runtime.Utils
{
    public class SortedLimitedSizeStack<T>
    {
        private readonly int _limit;
        private List<T> _list;

        public SortedLimitedSizeStack(int limit)
        {
            _limit = limit;
            _list = new List<T>();
        }

        public void Push(T item)
        {
            _list.Add(item);
            if (_list.Count > _limit)
                _list.Remove(_list.First());
            _list = _list.OrderByDescending(x => x).ToList();
        }

        public T Pop()
        {
            if (_list.Count == 0)
                return default;
            
            var item = _list.Last();
            _list.Remove(item);
            return item;
        }

        public int Count => _list.Count;
    }
}