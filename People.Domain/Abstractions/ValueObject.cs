using System.Collections.Generic;
using System.Linq;

namespace People.Domain.Abstractions
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetAtomicValues();

        public static bool operator ==(ValueObject left, ValueObject right)
        {
            if (left is null ^ right is null)
            {
                return false;
            }

            return left is null || left.Equals(right);
        }

        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var other = (ValueObject)obj;
            using (var thisValues = GetAtomicValues().GetEnumerator())
            using (var otherValues = other.GetAtomicValues().GetEnumerator())
            {
                while (thisValues.MoveNext() && otherValues.MoveNext())
                {
                    if (thisValues.Current is null ^ otherValues.Current is null)
                    {
                        return false;
                    }

                    if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                    {
                        return false;
                    }
                }

                return !thisValues.MoveNext() && !otherValues.MoveNext(); 
            }
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(value => value != null ? value.GetHashCode() : 0)
                .Aggregate((leftValue, rightValue) => leftValue ^ rightValue);
        }
    }
}
