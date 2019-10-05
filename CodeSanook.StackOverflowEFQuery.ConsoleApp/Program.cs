using CodeSanook.StackOverflowEFQuery.ConsoleApp.Models;
using System;
using System.Data;
using System.Linq;

namespace CodeSanook.StackOverflowEFQuery.ConsoleApp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            // Converted from https://data.stackexchange.com/stackoverflow/query/785/how-many-upvotes-do-i-have-for-each-tag
            using (var db = new StackOverflowDbContext())
            using (var transaction = db.Database.BeginTransaction())
            {
                byte voteType = 2;
                int userId = 55;
                var query1 = from t in db.Tags
                            from pt in t.PostTags
                            let p = pt.Post
                            join v in db.Votes on new { PostId = p.Id, VoteTypeId = voteType } equals new { v.PostId, v.VoteTypeId }
                            where p.OwnerUserId == userId
                            group t by t.TagName into g
                            orderby g.Count()
                            select new { TagName = g.Key, Upvotes = g.Count() };


                var query2 = from t in db.Tags
                            join pt in db.PostTags on t.Id equals pt.TagId
                            join p in db.Posts on pt.PostId equals p.Id
                            join v in db.Votes on new { PostId = p.Id,  VoteTypeId  = voteType} equals new { v.PostId, v.VoteTypeId }
                            where p.OwnerUserId == userId
                            group t by t.TagName into g
                            orderby g.Count()
                            select new { TagName = g.Key, Upvotes = g.Count() };

                foreach (var item in query1.ToList())
                {
                    Console.WriteLine($"{item.TagName} {item.Upvotes}");
                }

                foreach (var item in query2.ToList())
                {
                    Console.WriteLine($"{item.TagName} {item.Upvotes}");
                }

                transaction.Commit();
            }
        }
    }
}
