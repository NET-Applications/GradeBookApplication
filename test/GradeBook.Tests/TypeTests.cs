using System;
using System.Collections.Generic;
using Microsoft.CSharp.RuntimeBinder;
using Xunit;

namespace GradeBook.Tests
{
    #region public delegate
    public delegate string WriteLogDelegate(string logMessage);
    #endregion public delegate

    public class TypeTests
    {
        #region private fields
        private int count = 0;
        #endregion private fields
        
        #region public methods
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            // arrange
            WriteLogDelegate log;
            //full representation
            log = new WriteLogDelegate(ReturnMessage);
            //short-hand representation
            log = ReturnMessage;
            // act
            var result = log("Hello!");
            // assert
            Assert.Equal("Hello!", result);
        }
        [Fact]
        public void WriteLogDelegateCanPointToManyMethods()
        {
            // arrange
            WriteLogDelegate log = ReturnMessage;
            //full representation
            log += new WriteLogDelegate(ReturnMessage);
            //short-hand representation
            log += ReturnMessage;
            log += IncrementCount;
            log -= ReturnMessage;
            // act
            var result = log("Hello!");
            // assert
            Assert.Equal(3, count);
            Assert.Equal("hello!", result);
        }
        [Fact]
        public void StringAlsoBehaveLikeValueTypes()
        {
            // arrange
            string name = "Shubhojit";
            // act
            var upperCase = MakeUpperCase(name);
            // assert
            Assert.Equal("Shubhojit", name);
            Assert.Equal("SHUBHOJIT", upperCase);
        }
        [Fact]
        public void ValueTypeAlsoPassByReference()
        {
            // arrange
            var x = GetInt();
            var y = GetInt();
            // act
            SetInt(ref x);
            SetIntByOut(out y);
            // assert
            Assert.NotEqual(3, x);
            Assert.NotEqual(3, y);
            Assert.Equal(42, x);
            Assert.Equal(56, y);
        }
        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            // act
            var x = GetInt();
            SetInt(x);
            // assert
            Assert.Equal(3, x);
        }
        [Fact]
        public void CanSetNameFromReference()
        {
            // arrange
            var book1 = GetBook("Book1");
            var book2 = GetBook("Book2");
            SetName(ref book1, "New Name");
            GetBookSetName(out book2, "New Book");
            // act
            var name1 = book1.Name;
            var name2 = book2.Name;
            // assert
            Assert.Equal("New Name", name1);
            Assert.Equal("New Book", name2);
        }
        [Fact]
        public void CannotSetNameFromPassByValueParameter()
        {
            // arrange
            var book1 = GetBook("Book1");
            SetName(book1, "New Name");
            // act
            var name1 = book1.Name;
            // assert
            Assert.NotEqual("New Name", name1);
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("book1");
            var book2 = GetBook("book2");
            // act
            var name1 = book1.Name;
            var name2 = book2.Name;
            // assert
            Assert.Equal(name1, book1.Name);
            Assert.Equal(name2, book2.Name);
            Assert.NotSame(book1, book2);
            //Akin to NotSame
            Assert.False(Object.ReferenceEquals(book1, book2));
        }
        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("book1");
            var book2 = book1;
            // act
            var name1 = book1.Name;
            // assert
            Assert.Equal(name1, book1.Name);
            Assert.Equal(name1, book2.Name);
            Assert.Same(book1, book2);
            //Akin to Same
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        [Fact]
        public void ReadOnlyFieldCanBeSetInClassConstructor()
        {
            // arrange
            var category = GetReadOnlyFieldClass("Literature");
            // act
            var result = category.Category;
            // assert
            Assert.Equal("Literature", result);
        }
        [Fact]
        public void ReadOnlyFieldCannotBeSetOutsideClassConstructor()
        {
            // arrange
            dynamic category = GetReadOnlyFieldClass("Literature");
            // act
            var result = Assert.Throws<RuntimeBinderException>(() => category.Category = "Science");
            // assert
            Assert.IsType<ReadOnlyClass>(category);
            Assert.Equal("A readonly field cannot be assigned to (except in a constructor or a variable initializer)", result.Message);
        }
        [Fact]
        public void ConstantFieldCanBeAccessedLikeStaticMembers()
        {
            // arrange
            var category = GetConstantFieldClass();
            // act
            var result = ConstantFieldClass.CATEGORY;
            // assert
            Assert.Equal("Science", result);
        }

        [Fact]
        public void ConstantFieldCannotBeAccessedWithAnInstanceReference()
        {
            // arrange
            dynamic category = GetConstantFieldClass();
            // act
            var result = Assert.Throws<RuntimeBinderException>(() => category.CATEGORY);
            // assert
            Assert.IsType<ConstantFieldClass>(category);
            Assert.Equal("Member 'GradeBook.Tests.ConstantFieldClass.CATEGORY' cannot be accessed with an instance reference; qualify it with a type name instead", result.Message);
        }
        #endregion public methods

        #region private methods
        private InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(new List<double>(), name);
        }
        private void SetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(new List<double>(), name);
        }
        private void SetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(new List<double>(), name);
        }
        private void GetBookSetName(out InMemoryBook book, string name)
        {
            book = new InMemoryBook(new List<double>(), name);
        }
        private int GetInt()
        {
            return 3;
        }
        private void SetInt(int num)
        {
            num = 42;
        }
        private void SetInt(ref int num)
        {
            num = 42;
        }
        private void SetIntByOut(out int num)
        {
            num = 56;
        }
        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }
        private ReadOnlyClass GetReadOnlyFieldClass(string category)
        {
            return new ReadOnlyClass(category);
        }
        private ConstantFieldClass GetConstantFieldClass()
        {
            return new ConstantFieldClass();
        }
        private string ReturnMessage(string message)
        {
            count++;
            return message;
        }
        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        #endregion private methods
    }
}
