using CustomCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IntegerCollectionUnitTest
{
    [TestClass]
    public class IntegerCollectionTest
    {
        public IntegerCollection GetIntegerCollection(params int[] numbers)
        {
            if (numbers.Length == 0) return new IntegerCollection();
            IntegerCollection list = new IntegerCollection();
            foreach (var item in numbers)
            {
                list.Add(item);
            }
            return list;
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 11, 22 })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { })]
        public void EqualityTest_CaseListAreSame(int[] numbers)
        {
            IntegerCollection list1 = GetIntegerCollection(numbers);
            IntegerCollection list2 = GetIntegerCollection(numbers);

            bool result1 = list1 == list2;
            Assert.IsTrue(result1);

            bool result2 = list1 != list2;
            Assert.IsFalse(result2);

            bool result3 = list1.Equals(list2);
            Assert.IsTrue(result3);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, new int[] { 1, 2 })]
        [DataRow(new int[] { 11, 22 }, new int[] { })]
        [DataRow(new int[] { 1 }, new int[] { 1, 2, 3 })]
        [DataRow(new int[] { }, new int[] { 1 })]
        public void EqualityTest_CaseListAreNotSame(int[] numbers1, int[] numbers2)
        {
            IntegerCollection list1 = GetIntegerCollection(numbers1);
            IntegerCollection list2 = GetIntegerCollection(numbers2);

            bool result1 = list1 == list2;
            Assert.IsFalse(result1);

            bool result2 = list1 != list2;
            Assert.IsTrue(result2);

            bool result3 = list1.Equals(list2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 2)]
        [DataRow(new int[] { 11, 22 }, 1)]
        [DataRow(new int[] { 1 }, 0)]
        public void Get_ValueByIndex_IndexIsCorrect_ReturnRightValue(int[] numbers, int index)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            int actual = list[index];
            int answer = numbers[index];
            Assert.AreEqual(answer, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 12)]
        [DataRow(new int[] { 11, 22 }, -1)]
        [DataRow(new int[] { 1 }, 1)]
        [DataRow(new int[] { }, 0)]
        public void Get_ValueByIndex_IndexIsIncorrect_CatchError(int[] numbers, int index)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list[index], "Expected Exception");
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 2, 100)]
        [DataRow(new int[] { 11, 22 }, 1, 100)]
        [DataRow(new int[] { 1 }, 0, 100)]
        public void Put_ValueByIndex_IndexIsCorrect_ReturnNewValue(int[] numbers, int index, int newValue)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            list[index] = newValue;
            int actual = list[index];
            Assert.AreEqual(newValue, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 12, 100)]
        [DataRow(new int[] { 11, 22 }, -1, 100)]
        [DataRow(new int[] { 1 }, 1, 100)]
        [DataRow(new int[] { }, 0, 100)]
        public void Put_ValueByIndex_IndexIsIncorrect_CatchError(int[] numbers, int index, int newValue)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            Assert.ThrowsException<IndexOutOfRangeException>(() => list[index] = newValue, "Expected Exception");
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 })]
        [DataRow(new int[] { 11, 22 })]
        [DataRow(new int[] { 1 })]
        [DataRow(new int[] { })]
        public void Clear_List_ReturnCountZero(int[] numbers)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            list.Clear();
            int actual = list.Count;
            Assert.AreEqual(0, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 1)]
        [DataRow(new int[] { 1, 2, 3 }, -1)]
        [DataRow(new int[] { 11, 22 }, 11)]
        [DataRow(new int[] { 11, 22 }, 33)]
        [DataRow(new int[] { 1 }, 1)]
        [DataRow(new int[] { 1 }, 2)]
        public void Find_FirstValue_ReturnIndexOrNotFind(int[] numbers, int valueToFind)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            int actual = list.IndexOf(valueToFind);
            int answer = Array.IndexOf(numbers, valueToFind);
            Assert.AreEqual(answer, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 3 }, 1)]
        [DataRow(new int[] { 1, 2, 3 }, -1)]
        [DataRow(new int[] { 11, 22 }, 11)]
        [DataRow(new int[] { 11, 22 }, 33)]
        [DataRow(new int[] { 1 }, 1)]
        [DataRow(new int[] { 1 }, 2)]
        public void Find_FirstValue_ReturnTrueOrFalse(int[] numbers, int valueToFind)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            bool actual = list.Contains(valueToFind);
            bool answer = numbers.Contains(valueToFind);
            Assert.AreEqual(answer, actual);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 3)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 1)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 2)]
        public void Remove_AllSetedNumbers_ReturnValueAreDeleted(int[] numbers, int valueToDelete)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            list.RemoveAllByValue(valueToDelete);
            bool actual = list.Contains(valueToDelete);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 3, new int[] { 3, 0 })]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 1, new int[] { 1 })]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 2, new int[] { 2, 4 })]
        public void Remove_AllSetedNumbers_ReturnCorrectDeletedIndexes(int[] numbers, int valueToDelete, int[] expectedIndexes)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            int[] deletedIndexes = list.RemoveAllByValue(valueToDelete).ToArray();
            bool actual = expectedIndexes.SequenceEqual(deletedIndexes);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 13)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 11)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 12)]
        public void Remove_AllSetedNumbers_ReturnValueNotFoundException(int[] numbers, int valueToDelete)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            Assert.ThrowsException<Exception>(() => list.RemoveAllByValue(valueToDelete), "Expected Exception");
        }

        [TestMethod]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 3)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 1)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 2)]
        public void Remove_FirstNumber_ReturnIndex(int[] numbers, int valueToDelete)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            int actualIndex = list.RemoveFirstByValue(valueToDelete);
            int answer = Array.IndexOf(numbers, valueToDelete);
            Assert.AreEqual(answer, actualIndex);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 13)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 11)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 12)]
        public void Remove_FirstNumber_ReturnValueNotFoundException(int[] numbers, int valueToDelete)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            Assert.ThrowsException<Exception>(() => list.RemoveFirstByValue(valueToDelete), "Expected Exception");
        }

        [TestMethod]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 0)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 2)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 4)]
        public void Remove_ByIndex_ReturnValue(int[] numbers, int IndexToDelete)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            int actualValue = list.RemoveByIndexAndReturnValue(IndexToDelete);
            int answer = numbers[IndexToDelete];
            Assert.AreEqual(answer, actualValue);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 0)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 2)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 3)]
        public void Remove_ByIndex_ReturnRightCount(int[] numbers, int IndexToDelete)
        {
            int answer = numbers.Length -1;
            
            IntegerCollection list = GetIntegerCollection(numbers);
            list.RemoveByIndexAndReturnValue(IndexToDelete);
            int actual = list.Count;
            Assert.AreEqual(answer, actual);

            IntegerCollection list2 = GetIntegerCollection(numbers);
            list2.RemoveByIndex(IndexToDelete);
            int actual2 = list2.Count;
            Assert.AreEqual(answer, actual2);
        }


        [TestMethod]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 10)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, -2)]
        [DataRow(new int[] { 3, 1, 2, 3, 2 }, 5)]
        public void Remove_ByIndex_IndexIsIncorrect_ReturnException(int[] numbers, int IndexToDelete)
        {
            IntegerCollection list = GetIntegerCollection(numbers);
            Assert.ThrowsException<IndexOutOfRangeException>(()=> list.RemoveByIndexAndReturnValue(IndexToDelete), "Expected Exception");
            Assert.ThrowsException<IndexOutOfRangeException>(()=> list.RemoveByIndex(IndexToDelete), "Expected Exception");
        }
    }
}
