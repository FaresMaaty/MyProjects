using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.List
{
    // Project GenericList
    public partial class GenericList<T> : IEnumerable<T>, IList<T>, ICollection<T>
    {
        Stack<T> stack;
        EqualityComparer<T> Comparer { get; set; }
        IComparable<T> IComparer { get; set; }
        #region Fields
        T[] items;
        int defaultCapacity = 4;
        int currentIndex;
        #endregion

        #region Properties
        public int Count { get; set; }
        public int Capacity { get; set; }
        public bool IsReadOnly => throw new NotImplementedException();
        #endregion

        #region Indexers
        public T this[int index]
        {
            set
            {
                if (index < 0 || index >= currentIndex)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
            get
            {
                if (index < 0 || index >= currentIndex)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
        }
        public List<T> this[string indexString]
        {
            get
            {
                if (string.IsNullOrEmpty(indexString))
                    throw new IndexOutOfRangeException();
                string[] strArr = indexString.Split(',');
                List<T> list = new List<T>();
                foreach (string str in strArr)
                {
                    if (Convert.ToInt32(str) < 0 || Convert.ToInt32(str) > items.Length)
                        continue;
                    if (items[Convert.ToInt32(str)] == null)
                        continue;
                    list.Add(items[Convert.ToInt32(str)]);
                }
                return list;
            }
        }
        #endregion

        #region Methods
        #region Constructors
        public GenericList()
        {
            Capacity = defaultCapacity;
            items = new T[defaultCapacity];
            Comparer = EqualityComparer<T>.Default;
            IComparer = new PersonEquality<T>();
            stack = new Stack<T>();
        }
        public GenericList(EqualityComparer<T> comparer)
        {
            Comparer = comparer;
            items = new T[defaultCapacity];
            Capacity = defaultCapacity;
            stack = new Stack<T>();
        }
        public GenericList(int capacity)
        {
            Capacity = capacity;
            Comparer = EqualityComparer<T>.Default;
            IComparer = new PersonEquality<T>();
            items = new T[defaultCapacity];
            stack = new Stack<T>();
        }
        public GenericList(IComparable<T> comparerable)
        {
            IComparer = comparerable;
            stack = new Stack<T>();
        }
        public GenericList(IEnumerable<T> collection)
        {
            int nCount = 0;
            foreach (T item in collection)
                nCount++;
            Capacity = defaultCapacity;
            items = new T[nCount];
            foreach (T item in collection)
            {
                Add(item);
            }
            Comparer = EqualityComparer<T>.Default;
            stack = new Stack<T>();
        }
        #endregion

        #region Add
        void Add(int index, T item)
        {
            
            items[index] = item;
            if (currentIndex > items.Length)
            {
                Resize(Capacity * 2);
            }

        }
        public void Add(T item)
        {
            if (currentIndex>= items.Length)
            {
                Resize(Capacity * 2);
            }
            items[currentIndex] = item;
            currentIndex++;
            Count++;
        }
        public void AddRange(IEnumerable<T> collection)
        {

            if (items.Length < Count + GetIEnumerableCount(collection))
            {
                Resize(Capacity * 2);
            }
            foreach (T item in collection)
            {
                Add(item);
            }

        }
        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in items)
            {
                yield return item;
            }
        }

        public void Insert(int index, T item)
        {
            // Check on Index
            if (currentIndex < 0 || currentIndex > Count || index < 0 || index >= items.Length)
                throw new ArgumentOutOfRangeException();
            // Check on Count of Items for Resize if True
            if (Count == items.Length)
            {
                Resize(Count + 1);
            }
            // Shift Rigth of Items
            ShiftRigth(index, 1);
            // Insert of Item in Current Array
            items[index] = item;
        }
        public void InsertRange(int index, IEnumerable<T> collection)
        {
            // Check on Index
            if (currentIndex < 0 || currentIndex > Count || index < 0 || index >= Count)
                throw new ArgumentOutOfRangeException();
            // Check on Count of Items and Collection for Resize if True
            if (Count + GetIEnumerableCount(collection) > items.Length)
            {
                Resize(Capacity * 2);
            }
            // Shift Rigth of Items
            ShiftRigth(index, GetIEnumerableCount(collection));
            // Insert Range of Items in Current Array
            foreach (T item in collection)
            {
                Add(index, item);
                index++;
            }
            currentIndex = Count;

        }

        #endregion

        #region Remove
        public bool Remove(T item)
        {
            //int number = Array.IndexOf(items, item);
            int number = IndexOf(item);
            if (currentIndex < 0 || currentIndex > Count || number < 0)
                throw new ArgumentOutOfRangeException();
            ShiftLeft(number, 1);
            DefaultOfItem();

            return true;
        }
        public void RemoveAt(int index)
        {

            if (currentIndex < 0 || currentIndex > Count || index > Count - 1)
                throw new ArgumentOutOfRangeException();
            ShiftLeft(index, 1);
            DefaultOfItem();
        }
        public void RemoveRange(int index, int count)
        {
            #region              فارس

            //if (index < 0 || count < 0 || currentIndex < 0 ||  currentIndex > Count  )
            //    throw new ArgumentOutOfRangeException();
            //for (int i = index; i <= count; i++)
            //{
            //    ShiftLeft(index);
            //    currentIndex--;
            //    Count--;
            //} 
            #endregion
            #region علي شاهين 

            // Check on index and count for RemoveRange Method
            if (index < 0 || count < 0 || currentIndex > Count || index + count > Count)
                throw new ArgumentOutOfRangeException();
            //shiftleft
            for (int i = index + count; i < items.Length; i++)
            {
                if (stack.Count < count)
                    stack.Push(items[index]);
                if (items[i] == null)
                    break;
                items[index] = items[i];
                index++;
            }
            //  ShiftLeft(index,count);

            //for (int i = index ; i < Count; i++)
            //{
            //   // stack.Push(items[i]);
            //    items[index] = items[i];
            //    index++;
            //}
            // last of items is null 

            DefaultOfMoreItem(index, count);
            // Check if ( items.Length / 2 > Count ) and reduce Size
            if (items.Length / 2 > Count)
                Resize(items.Length / 2);
            #endregion
        }
        public void RemoveAll()
        {
            #region حلي
            // remove all ( ب زى مهو array وحجم null بتخلي كل العناصر)
            //if (currentIndex < 0 || currentIndex > Count || Count == 0)
            //    throw new ArgumentOutOfRangeException();
            //ShiftLeft(Count - 1, Count);
            //DefaultOfMoreItem(0); 
            #endregion

            //علي شاهين
            if (currentIndex < 0 || currentIndex > Count || Count == 0)
                throw new ArgumentOutOfRangeException();
            items = new T[items.Length];
            Count = 0;
            currentIndex = 0;
        }
        public void Clear()
        {
            // remove all ( ب 4 array وحجم null بتخلي كل العناصر)
            #region حلي
            //if (currentIndex < 0 || currentIndex > Count || Count == 0)
            //    throw new ArgumentOutOfRangeException();
            //ShiftLeft(Count - 1, Count);
            //DefaultOfMoreItem(0);
            //Resize(defaultCapacity); 
            #endregion
            // علي شاهين
            if (currentIndex < 0 || currentIndex > Count || Count == 0)
                throw new ArgumentOutOfRangeException();
            items = new T[defaultCapacity];
            Count = 0;
            currentIndex = 0;
        }
        #endregion

        #region Methods of IEnumerator

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion 

        #region Methods Helpers
        // Special Mehtod Helpers
        void Resize(int newSize)
        {
            Capacity = newSize;
            //Create NewArray
            T[] newArray = new T[newSize];
            //CopyArray
            Array.Copy(items, newArray, Count);
            //Equality
            items = newArray;
        }

        void ShiftLeft(int index, int numberOfItems)
        {
            stack.Push(items[index]);
            for (int i = index + numberOfItems; i < Count; i++)
            {
                items[index] = items[i];
                index++;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Comparer.Equals(item, items[i]))
                {
                    return (i);
                }
            }
            return -1;
        }

        void ShiftRigth(int index, int numberOfItems)
        {
            for (int i = 0; i < numberOfItems; i++)
            {
                for (int j = Count - 1; j >= index; j--)
                {
                    items[j + 1] = items[j];
                }
                Count++;
                currentIndex++;
            }

        }

        void DefaultOfItem()
        {
            items[Count - 1] = default(T);
            Count--;
            currentIndex--;
        }

        void DefaultOfMoreItem(int index, int numberOfCount)
        {
            for (int i = 0; i < numberOfCount; i++)
            {
                items[Count - 1] = default(T);
                Count--;
                currentIndex--;
            }

        }

        public void Reverse()
        {
            T reverse;
            //for (int i = 0;i < Count/2;i++)
            //{
            //    reverse = items[Count -i - 1];
            //    items[Count - i - 1] = items[i];
            //    items[i]=reverse;
            //}
            T[] array = new T[Count];
            for (int i = 0; i < Count; i++)
            {
                array[i] = items[Count - i - 1];
            }
            Array.Copy(array, items, Count);
            items = array;
        }

        public void Sort()
        {

        }

        int GetIEnumerableCount(IEnumerable<T> collection)
        {
            int nCount = 0;
            foreach (T item in collection)
                nCount++;

            return nCount;
        }

        public T[] ToArray()
        {
            Resize(Count);
            return items;
        }


        public bool Contains(T item)
        {
            return IndexOf(item) > -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public void UndoOfItem()
        {
            T item = stack.Pop();
            Add(item);
        }

        public void UndoOfItems()
        {
            T item;
            for (int i = 0; i < Count; i++)
            {
                if (stack.Count == 0)
                {
                    break;
                }
                item = stack.Pop();
                Add(item);
            }
        }
        #endregion

        #endregion
    }
}
