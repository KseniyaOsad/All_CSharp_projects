using CustomCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCollectionUnitTest
{
    class TestHelper<T>
    {
        public GenericCollection<T> GetCollection( T[] objects)
        {
            if (objects.Length == 0) return new GenericCollection<T>();
            GenericCollection<T> list = new GenericCollection<T>();
            foreach (var item in objects)
            {
                list.Add(item);
            }
            return list;
        }

        public void Clear_List_ReturnCountZero(params T[] values)
        {
            GenericCollection<T> list = GetCollection(values);
            list.Clear();
            int actual = list.Count;
            Assert.AreEqual(0, actual);
        }

        public void Get_ValueByIndex_IndexIsCorrect_ReturnRightValue(int index, params T[] values)
        {
            GenericCollection<T> list = GetCollection(values);
            T actual = list[index];
            T answer = values[index];
            Assert.AreEqual(answer, actual);
        }

        public void Get_ValueByIndex_IndexIsIncorrect_CatchError(int index, params T[] values)
        {
            GenericCollection<T> list = GetCollection(values);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list[index], "Expected Exception");
        }

        public void Put_ValueByIndex_IndexIsCorrect_ReturnNewValue(int index, T newValue, params T[] values)
        {
            GenericCollection<T> list = GetCollection(values);
            list[index] = newValue;
            T actual = list[index];
            Assert.AreEqual(newValue, actual);
        }

        public void Put_ValueByIndex_IndexIsIncorrect_CatchError(int index, T newValue, params T[] values)
        {
            GenericCollection<T> list = GetCollection(values);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list[index] = newValue, "Expected Exception");
        }

        public void Remove_ByIndex_ReturnValue(int IndexToDelete, params T[] values)
        {
            GenericCollection<T> list = GetCollection(values);
            T actualValue = list.RemoveByIndexAndReturnValue(IndexToDelete);
            T answer = values[IndexToDelete];
            Assert.AreEqual(answer, actualValue);
        }

        public void Remove_ByIndex_ReturnRightCount(int IndexToDelete, params T[] values)
        {
            int answer = values.Length - 1;
            
            GenericCollection<T> list = GetCollection(values);
            list.RemoveByIndexAndReturnValue(IndexToDelete);
            int actual = list.Count;
            Assert.AreEqual(answer, actual);

            GenericCollection<T> list2 = GetCollection(values);
            list2.RemoveByIndex(IndexToDelete);
            int actual2 = list2.Count;
            Assert.AreEqual(answer, actual2);
        }

        public void Remove_ByIndex_IndexIsIncorrect_ReturnException(int IndexToDelete, params T[] values)
        {
            GenericCollection<T> list = GetCollection(values);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveByIndexAndReturnValue(IndexToDelete), "Expected Exception");
            Assert.ThrowsException<IndexOutOfRangeException>(() => list.RemoveByIndex(IndexToDelete), "Expected Exception");
        }
    }
}
