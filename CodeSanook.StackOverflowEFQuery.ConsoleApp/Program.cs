using CodeSanook.StackOverflowEFQuery.ConsoleApp.Models;
using System;
using System.Linq;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var db = new StackOverflowDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                Console.WriteLine($"post counts {db.Posts.Count()}");
                transaction.Commit();
            }
        }
    }
}
