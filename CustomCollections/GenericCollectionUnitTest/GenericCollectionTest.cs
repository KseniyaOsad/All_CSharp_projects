using CustomCollections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericCollectionUnitTest
{
    [TestClass]
    public class GenericCollectionTest
    {

        [TestMethod]
        [DataRow("string",  new string[] { "hi", "hello"},   null,                    null)]
        [DataRow("string",  new string[] { "hi"},            null,                    null)]
        [DataRow("int",     null,                            new int[] { 1, 2},       null)]
        [DataRow("int",     null,                            new int[] { 1, 2, 100},  null)]
        [DataRow("object",  null,                            null,                    new object[] { })]
        [DataRow("object",  null,                            null,                    new object[] { 'd' })]
        public void Clear_List_ReturnCountZero(string type, string[] stringValues, int[] intValues, object[] objectValues)
        {
            switch (type)
            {
                case "string":
                    TestHelper<string> THS = new TestHelper<string>();
                    THS.Clear_List_ReturnCountZero(stringValues);
                    break;
                case "int":
                    TestHelper<int> THI = new TestHelper<int>();
                    THI.Clear_List_ReturnCountZero(intValues);
                    break;
                default:
                    TestHelper<object> THO = new TestHelper<object>();
                    THO.Clear_List_ReturnCountZero(objectValues);
                    break;
            }
            
        }

        [TestMethod]
        [DataRow("string", 1, new string[] { "hi", "hello"},   null,                    null)]
        [DataRow("string", 0, new string[] { "hi"},            null,                    null)]
        [DataRow("int",    1, null,                            new int[] { 1, 2},       null)]
        [DataRow("int",    2, null,                            new int[] { 1, 2, 100},  null)]
        [DataRow("object", 0, null,                            null,                    new object[] { 'd' })]
        public void Get_ValueByIndex_IndexIsCorrect_ReturnRightValue(string type, int index, string[] stringValues, int[] intValues, object[] objectValues)
        {
            switch (type)
            {
                case "string":
                    TestHelper<string> THS = new TestHelper<string>();
                    THS.Get_ValueByIndex_IndexIsCorrect_ReturnRightValue(index, stringValues);
                    break;
                case "int":
                    TestHelper<int> THI = new TestHelper<int>();
                    THI.Get_ValueByIndex_IndexIsCorrect_ReturnRightValue(index, intValues);
                    break;
                default:
                    TestHelper<object> THO = new TestHelper<object>();
                    THO.Get_ValueByIndex_IndexIsCorrect_ReturnRightValue(index, objectValues);
                    break;
            }
        }

        [TestMethod]
        [DataRow("string", 11, new string[] { "hi", "hello"},   null,                    null)]
        [DataRow("string", 10, new string[] { "hi"},            null,                    null)]
        [DataRow("int",    -1, null,                            new int[] { 1, 2},       null)]
        [DataRow("int",    22, null,                            new int[] { 1, 2, 100},  null)]
        [DataRow("object",  0, null,                            null,                    new object[] {  })]
        [DataRow("object", -2, null,                            null,                    new object[] { 'd' })]
        public void Get_ValueByIndex_IndexIsIncorrect_CatchError(string type, int index, string[] stringValues, int[] intValues, object[] objectValues)
        {
            switch (type)
            {
                case "string":
                    TestHelper<string> THS = new TestHelper<string>();
                    THS.Get_ValueByIndex_IndexIsIncorrect_CatchError(index, stringValues);
                    break;
                case "int":
                    TestHelper<int> THI = new TestHelper<int>();
                    THI.Get_ValueByIndex_IndexIsIncorrect_CatchError(index, intValues);
                    break;
                default:
                    TestHelper<object> THO = new TestHelper<object>();
                    THO.Get_ValueByIndex_IndexIsIncorrect_CatchError(index, objectValues);
                    break;
            }
        }

        [TestMethod]
        [DataRow("string", 1, new string[] { "hi", "hello"},   null,                    null)]
        [DataRow("string", 0, new string[] { "hi"},            null,                    null)]
        [DataRow("int",    1, null,                            new int[] { 1, 2},       null)]
        [DataRow("int",    2, null,                            new int[] { 1, 2, 100},  null)]
        [DataRow("object", 0, null,                            null,                    new object[] { 'd' })]
        public void Put_ValueByIndex_IndexIsCorrect_ReturnNewValue(string type, int index, string[] stringValues, int[] intValues, object[] objectValues)
        {
            switch (type)
            {
                case "string":
                    TestHelper<string> THS = new TestHelper<string>();
                    THS.Put_ValueByIndex_IndexIsCorrect_ReturnNewValue(index, "newValue", stringValues);
                    break;
                case "int":
                    TestHelper<int> THI = new TestHelper<int>();
                    THI.Put_ValueByIndex_IndexIsCorrect_ReturnNewValue(index, 100, intValues);
                    break;
                default:
                    TestHelper<object> THO = new TestHelper<object>();
                    THO.Put_ValueByIndex_IndexIsCorrect_ReturnNewValue(index, 'k', objectValues);
                    break;
            }
        }

        [TestMethod]
        [DataRow("string", 11, new string[] { "hi", "hello"},   null,                    null)]
        [DataRow("string", 10, new string[] { "hi"},            null,                    null)]
        [DataRow("int",    -1, null,                            new int[] { 1, 2},       null)]
        [DataRow("int",    22, null,                            new int[] { 1, 2, 100},  null)]
        [DataRow("object",  0, null,                            null,                    new object[] {  })]
        [DataRow("object", -2, null,                            null,                    new object[] { 'd' })]
        public void Put_ValueByIndex_IndexIsIncorrect_CatchError(string type, int index, string[] stringValues, int[] intValues, object[] objectValues)
        {
            switch (type)
            {
                case "string":
                    TestHelper<string> THS = new TestHelper<string>();
                    THS.Put_ValueByIndex_IndexIsIncorrect_CatchError(index, "newValue", stringValues);
                    break;
                case "int":
                    TestHelper<int> THI = new TestHelper<int>();
                    THI.Put_ValueByIndex_IndexIsIncorrect_CatchError(index, 100, intValues);
                    break;
                default:
                    TestHelper<object> THO = new TestHelper<object>();
                    THO.Put_ValueByIndex_IndexIsIncorrect_CatchError(index, 'k', objectValues);
                    break;
            }
        }

        [TestMethod]
        [DataRow("string", 1, new string[] { "hi", "hello"},   null,                    null)]
        [DataRow("string", 0, new string[] { "hi"},            null,                    null)]
        [DataRow("int",    1, null,                            new int[] { 1, 2},       null)]
        [DataRow("int",    2, null,                            new int[] { 1, 2, 100},  null)]
        [DataRow("object", 0, null,                            null,                    new object[] { 'd' })]
        public void Remove_ByIndex_ReturnValue(string type, int indexToDelete, string[] stringValues, int[] intValues, object[] objectValues)
        {
            switch (type)
            {
                case "string":
                    TestHelper<string> THS = new TestHelper<string>();
                    THS.Remove_ByIndex_ReturnValue(indexToDelete, stringValues);
                    break;
                case "int":
                    TestHelper<int> THI = new TestHelper<int>();
                    THI.Remove_ByIndex_ReturnValue(indexToDelete, intValues);
                    break;
                default:
                    TestHelper<object> THO = new TestHelper<object>();
                    THO.Remove_ByIndex_ReturnValue(indexToDelete, objectValues);
                    break;
            }
        }

        [TestMethod]
        [DataRow("string", 1, new string[] { "hi", "hello"},   null,                    null)]
        [DataRow("string", 0, new string[] { "hi"},            null,                    null)]
        [DataRow("int",    1, null,                            new int[] { 1, 2},       null)]
        [DataRow("int",    2, null,                            new int[] { 1, 2, 100},  null)]
        [DataRow("object", 0, null,                            null,                    new object[] { 'd' })]
        public void Remove_ByIndex_ReturnRightCount(string type, int indexToDelete, string[] stringValues, int[] intValues, object[] objectValues)
        {
            switch (type)
            {
                case "string":
                    TestHelper<string> THS = new TestHelper<string>();
                    THS.Remove_ByIndex_ReturnRightCount(indexToDelete, stringValues);
                    break;
                case "int":
                    TestHelper<int> THI = new TestHelper<int>();
                    THI.Remove_ByIndex_ReturnRightCount(indexToDelete, intValues);
                    break;
                default:
                    TestHelper<object> THO = new TestHelper<object>();
                    THO.Remove_ByIndex_ReturnRightCount(indexToDelete, objectValues);
                    break;
            }
        }

        [TestMethod]
        [DataRow("string", 11, new string[] { "hi", "hello"},   null,                    null)]
        [DataRow("string", 10, new string[] { "hi"},            null,                    null)]
        [DataRow("int",    -1, null,                            new int[] { 1, 2},       null)]
        [DataRow("int",    22, null,                            new int[] { 1, 2, 100},  null)]
        [DataRow("object",  0, null,                            null,                    new object[] {  })]
        [DataRow("object", -2, null,                            null,                    new object[] { 'd' })]
        public void Remove_ByIndex_IndexIsIncorrect_ReturnException(string type, int indexToDelete, string[] stringValues, int[] intValues, object[] objectValues)
        {
            switch (type)
            {
                case "string":
                    TestHelper<string> THS = new TestHelper<string>();
                    THS.Remove_ByIndex_IndexIsIncorrect_ReturnException(indexToDelete, stringValues);
                    break;
                case "int":
                    TestHelper<int> THI = new TestHelper<int>();
                    THI.Remove_ByIndex_IndexIsIncorrect_ReturnException(indexToDelete,  intValues);
                    break;
                default:
                    TestHelper<object> THO = new TestHelper<object>();
                    THO.Remove_ByIndex_IndexIsIncorrect_ReturnException(indexToDelete,  objectValues);
                    break;
            }
        }
    }
}
