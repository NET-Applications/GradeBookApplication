using System;
using Microsoft.CSharp.RuntimeBinder;
using Xunit;

namespace GradeBook.Tests
{
    public class DiskBookTests
    {
        #region private fields
        private int count = 0;
        #endregion private fields

        #region public methods
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = GetBook("Science");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            // act
            var result = book.GetStatistics();
            string path = $"{book.Name}.txt";
            DiskBook.DeleteFile(path);
            // assert
            Assert.Equal(3, result.Size);
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.HighestGrade);
            Assert.Equal(77.3, result.LowestGrade);
        }
        [Fact]
        public void AddGradeGreaterThan100ToGradeBook()
        {
            // arrange
            var book = GetBook("Science");
            // act
            var result = Assert.Throws<ArgumentException>(() => book.AddGrade(120));
            // assert    
            Assert.Equal("Invalid grade", result.Message);
        }
        [Fact]
        public void AddGradeLessThan0ToGradeBook()
        {
            // arrange
            var book = GetBook("Science");
            // act
            var result = Assert.Throws<ArgumentException>(() => book.AddGrade(-1));
            // assert  
            Assert.Equal("Invalid grade", result.Message);
        }
        [Fact]
        public void AddLetterGradeToGradeBook()
        {
            // arrange
            var book = GetBook("Literature");
            book.AddGrade('A');
            book.AddGrade('Q');
            // act
            var result = book.GetStatistics();
            string path = $"{book.Name}.txt";
            DiskBook.DeleteFile(path);
            // assert
            Assert.Equal(2, result.Size);
            Assert.Equal(45, result.Average);
            Assert.Equal('F', result.Letter);
            Assert.Equal(90, result.HighestGrade);
            Assert.Equal(0, result.LowestGrade);
        }
        [Fact]
        public void BookCalculatesLetterGrades()
        {
            // arrange
            var book = GetBook("Social Science");
            book.AddGrade('A');
            book.AddGrade('B');
            book.AddGrade('A');
            book.AddGrade('C');
            // act
            var result = book.GetStatistics();
            string path = $"{book.Name}.txt";
            DiskBook.DeleteFile(path);
            // assert
            Assert.Equal(4, result.Size);
            Assert.Equal(82.50, result.Average);
            Assert.Equal('B', result.Letter);
            Assert.Equal(330, result.Total);
        }
        [Fact]
        public void BookCalculatesAnEmptyGrade()
        {
            // arrange
            var book = GetBook("Science");
            // act
            var result = book.GetStatistics();
            // assert
            Assert.Equal(0, result.Size);
            Assert.Equal(0, result.Total);
            Assert.Equal(0, result.Average);
            Assert.Equal('F', result.Letter);
            Assert.Equal(0, result.HighestGrade);
            Assert.Equal(0, result.LowestGrade);
        }
        [Fact]
        public void BookGradeBookNameCannotBeEmpty()
        {
            // arrange
            var book = new DiskBook("Science");
            // act
            var result = Assert.Throws<ArgumentException>(() => GetBook(String.Empty));
            var name = book.Name;
            // assert
            Assert.Equal("Grade book name is required", result.Message);
            Assert.NotEmpty(name);
        }
        [Fact]
        public void BookGradeBookNameCannotBeNull()
        {
            // arrange
            var book = GetBook("Science");
            // act
            var result = Assert.Throws<ArgumentException>(() => GetBook(null));
            var name = book.Name;
            // assert
            Assert.Equal("Grade book name is required", result.Message);
            Assert.NotNull(name);
        }
        [Fact]
        public void GradeAddedEventCannotBeAssignedAValueOutsideTheClass()
        {
            // arrange
            dynamic book = GetBook("Science");
            // act
            var result = Assert.Throws<RuntimeBinderException>(() => book.GradeAdded = null);
            // assert
            Assert.IsType<DiskBook>(book);
            Assert.Equal("The event 'GradeAdded' can only appear on the left hand side of +", result.Message);

        }
        [Fact]
        public void GradeAddedEventCanMulticast()
        {
            // arrange
            var book = GetBook("Science");
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeLetterAdded;
            book.GradeAdded -= OnGradeAdded;
            // act
            book.AddGrade('B');
            string path = $"{book.Name}.txt";
            DiskBook.DeleteFile(path);
            // assert
            Assert.Equal(3, count);
        }
        #endregion public methods

        #region private methods
        private DiskBook GetBook(string name)
        {
            return new DiskBook(name);
        }
        private void OnGradeAdded(object sender, EventArgs e)
        {
            count++;
        }
        private void OnGradeLetterAdded(object sender, EventArgs args)
        {
            count++;
        }
        #endregion private methods

    }
}