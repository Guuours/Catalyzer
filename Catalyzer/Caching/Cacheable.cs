using System;

namespace Catalyzer
{
    public class Cacheable<T>
    {
        private T value = default;

        public T Value
        {
            get
            {
                if (!HasValue)
                {
                    if (InitFunc != null)
                    {
                        value = InitFunc.Invoke();
                    }
                }

                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public Func<T, bool> HasValueFunc { get; set; }

        public Func<T> InitFunc { get; set; }

        public Action RefreshFunc { get; set; }

        public Cacheable() { }

        public Cacheable(Func<T, bool> hasValue, Func<T> getFunc, Action refreshFunc)
        {
            HasValueFunc = hasValue;
            InitFunc = getFunc;
            RefreshFunc = refreshFunc;
        }

        public bool HasValue
        {
            get
            {
                if (HasValueFunc == null)
                {
                    return !value.Equals(default);
                }

                return !HasValueFunc.Invoke(value);
            }
        }

        public void Refresh()
        {
            value = default;
            RefreshFunc?.Invoke();
        }
    }
}