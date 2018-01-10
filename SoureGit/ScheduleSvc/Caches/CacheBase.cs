using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace ScheduleSvc.Caches
{
    public abstract class CacheBase
    {
        private string _name;
        private bool _sync = false;
        private bool _absolute = true;
        private int _duration = int.MaxValue;
        private bool _factory = false;
        protected ConcurrentDictionary<string, object> Dictionary = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// Contructor
        /// </summary>
        public CacheBase()
        {
        }

        /// <summary>
        /// The cache name (name is the same as class name)
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// Add a new item into cache
        /// </summary>
        /// <typeparam name="T">The generic type of the value</typeparam>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        /// <returns>True/False</returns>
        public abstract bool Add<T>(string key, T value)
            where T : class;

        /// <summary>
        /// Remove a item from cache
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>True/False</returns>
        public abstract bool Remove(string key);

        /// <summary>
        /// Get a value into cache by the specified key
        /// </summary>
        /// <typeparam name="T">The generic type of the value</typeparam>
        /// <param name="key">The key</param>
        /// <returns>The value</returns>
        public abstract T Get<T>(string key)
            where T : class;

        /// <summary>
        /// Get all item into cache
        /// </summary>
        /// <returns>True/False</returns>
        public virtual bool GetAll()
        {
            return false;
        }

        /// <summary>
        /// Get all item into cache
        /// </summary>
        /// <typeparam name="T">The generic type of the cache</typeparam>
        /// <returns>The cache</returns>
        public virtual T GetAll<T>()
            where T : class
        {
            return Dictionary as T;
        }

        /// <summary>
        /// Get the number of element
        /// </summary>
        public virtual int Count
        {
            get { return Dictionary.Count; }
        }

        /// <summary>
        /// Get and set flag is cache or not
        /// </summary>
        public virtual bool IsFactory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        /// <summary>
        /// Get and set the transaction of the cache
        /// </summary>
        public virtual bool IsSync
        {
            get { return _sync; }
            set { _sync = value; }
        }

        /// <summary>
        /// Get and set the status of the cache
        /// </summary>
        public virtual bool IsAbsolute
        {
            get { return _absolute; }
            set { _absolute = value; }
        }

        /// <summary>
        /// The period of time during which cache lives (seconds)
        /// </summary>
        public virtual int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }
    }
}
