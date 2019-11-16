using Codesanook.StackOverflowEFQuery.ConsoleApp.Models;
using System;
using System.Data;
using System.Linq;
using Terminal.Gui;

namespace Codesanook.LinqToEF101
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Application.Init();
            Application.Current.Width = Dim.Fill();
            Application.Top.Add(new MainWindow());
            Application.Run();

            return;
            // Converted from https://data.stackexchange.com/stackoverflow/query/785/how-many-upvotes-do-i-have-for-each-tag


            byte voteType = 2;
            int userId = 55;
            using (var db = new StackOverflowDbContext())
            {
                var query = from t in db.Tags
                            join pt in db.PostTags on t.Id equals pt.TagId
                            join p in db.Posts on pt.PostId equals p.ParentId
                            join v in db.Votes on new { PostId = p.Id, VoteTypeId = voteType }
                            equals new { v.PostId, v.VoteTypeId }
                            where p.OwnerUserId == userId
                            group t by t.TagName into g
                            select new { TagName = g.Key, Upvotes = g.Count() };

                query = query.OrderBy(t => t.Upvotes);

                foreach (var item in query.ToList())
                {
                    Console.WriteLine($"{item.TagName} {item.Upvotes}");
                }

            }
        }
    }
}

//alternatively
//var query = from t in db.Tags
//             from pt in t.PostTags
//             let p = pt.Post
//             join v in db.Votes on new { PostId = p.Id, VoteTypeId = voteType } equals new { v.PostId, v.VoteTypeId }
//             where p.OwnerUserId == userId
//             group t by t.TagName into g
//             orderby g.Count()
//             select new { TagName = g.Key, Upvotes = g.Count() };

