using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace IndexerBindingSample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            this["Age"] = 20;
        }

        // This dictionary can be seen as a data store or caching system.
        private Dictionary<string, object?> _data = new Dictionary<string, object?>();

        public IDictionary Data => _data;

        /// <summary>
        /// Access any property by it's indexer
        /// </summary>
        /// <param name="key">The key to lookup</param>
        /// <returns>the value if present, otherwise a string with an error message</returns>
        public object? this[string key]
        {
            get
            {
                return _data.TryGetValue(key, out var value) ? value : null;
            }
            set
            {
                _data[key] = value;
                this.RaisePropertyChanged($"Item");
            }
        }
    }
}
