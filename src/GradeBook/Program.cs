using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        #region private static methods
        static void Main(string[] args)
        {
            // Create a grade book
            IBook book = new DiskBook("Science");
            // Subscribing to an event
            book.GradeAdded += OnGradeAdded;
            // Entering grades to the grade book
            EnterGrades(book);
            // Show statistic details of the grade book
            book.ShowStatistics();
            // Delete the file, if it exists
            string path = $"{book.Name}.txt";
            DiskBook.DeleteFile(path);
        }
        /** Adding grades to the grade book*/
        private static void EnterGrades(IBook book)
        {
            // Add grade to the grades book from user
            Console.WriteLine($"Enter the grades for {book.Name} grade book. Letter Grades allowed are A, B, C, D and F. Press Q to discontinue:");
            do
            {
                try
                {
                    var input = Console.ReadLine();
                    double grade;
                    char letter;
                    //Parses grade to double or character
                    if (double.TryParse(input, out grade))
                    {
                        book.AddGrade(grade);
                    }
                    else if (char.TryParse(input, out letter) && !char.Equals(letter, 'Q'))
                    {
                        book.AddGrade(letter);
                    }
                    // break the loop if user enters Q
                    else if (char.TryParse(input, out letter) && char.Equals(letter, 'Q'))
                    {
                        break;
                    }
                    // requests user to enter a valid grade
                    else
                    {
                        throw new FormatException($"Please enter a {nameof(grade)} of type double or char:");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("_______________________________________________");
                }
            } while (true);
        }
        /** Method triggered by an event on adding a grade*/
        private static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added.");
        }
        #endregion private static methods

    }
}

