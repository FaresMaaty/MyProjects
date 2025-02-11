using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.List
{
    public class PersonEquality<T> : EqualityComparer<T>,IComparable<T>
    {
        public int CompareTo(T? other)
        {
            if (other == null) return 1;

            return CompareTo(other);
        }

        public override bool Equals(T? x, T? y)
        {
            if (x == null && y == null) return false;

            if ((object)x == (object)y)
                return true;

            return false;
        }

        public override int GetHashCode([DisallowNull] T obj)
        {
            return obj.GetHashCode();
        }
    }
}
