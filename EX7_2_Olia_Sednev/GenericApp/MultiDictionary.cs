using System;
using System.Collections;
using System.Collections.Generic;
namespace GenericApp
{
    public class MultiDictionary<K, V> : IMutiDictionary<K, V>, IEnumerable<KeyValuePair<K, V>>
    {
       
        internal Dictionary<K, LinkedList<V>> _MultiDictionary = new Dictionary<K, LinkedList<V>>();

        public int Count
        {
            get
            {
                return _MultiDictionary.Count;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                return _MultiDictionary.Keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
                LinkedList<V> lList = new LinkedList<V>();
                foreach (var list in _MultiDictionary)
                {
                    foreach (var value in list.Value)
                    {
                        lList.AddLast(value);
                    }
                }
                return lList;
            }
        }

        public void Add(K key, V value)
        {
            LinkedList<V> _ValusesLList;
            if ((_MultiDictionary.ContainsKey(key)))
            {
                _MultiDictionary[key].AddLast(value);
            }
            else
            {
                _ValusesLList = new LinkedList<V>();
                _ValusesLList.AddLast(value);
                _MultiDictionary.Add(key, _ValusesLList);
            }
        }

        public void Clear()
        {
            _MultiDictionary.Clear();
        }

        public bool Contains(K key, V value)
        {
            return _MultiDictionary[key].Contains(value);
        }

        public bool ContainsKey(K key)
        {
            return _MultiDictionary.ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var list in _MultiDictionary)
            {
                foreach (var value in list.Value)
                {
                    yield return new KeyValuePair<K, V>(list.Key, value);
                }
            }
        }

        public bool Remove(K key)
        {
            return _MultiDictionary.Remove(key);
        }

        public bool Remove(K key, V value)
        {
            if(_MultiDictionary.ContainsKey(key))
            {
                if (_MultiDictionary[key].Contains(value))
                {
                   return _MultiDictionary[key].Remove(value);
                }
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
