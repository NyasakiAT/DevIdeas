using DevIdeas.Objects;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIdeas.Models
{
    public class DbAccess
    {
        private string dbPath = @".\Db\data.db";

        //// Index document using document Name property
        //coll.EnsureIndex(x => x.Name);
        // Let's create an index in phone numbers (using expression). It's a multikey index
        //coll.EnsureIndex(x => x.Phones);

        // Use LINQ to query documents (filter, sort, transform)
        //var results = coll.Query()
        //    .Where(x => x.Name.StartsWith("J"))
        //    .OrderBy(x => x.Name)
        //    .Select(x => new { x.Name, NameUpper = x.Name.ToUpper() })
        //    .Limit(10)
        //    .ToList();

        public DbAccess()
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(dbPath))
            {
                // Get a collection (or create, if doesn't exist)
                var coll = db.GetCollection<ProjectEntry>("projectentries");
            }
        }

        public List<ProjectEntry> GetAllEntries()
        {
            using (var db = new LiteDatabase(dbPath))
            {
                // Get a collection (or create, if doesn't exist)
                var coll = db.GetCollection<ProjectEntry>("projectentries");

                return coll.Query().ToList();
            }
        }

        public void CreateProjectEntry(string title, string description, List<string> tags)
        {
            using (var db = new LiteDatabase(dbPath))
            {
                // Get a collection (or create, if doesn't exist)
                var coll = db.GetCollection<ProjectEntry>("projectentries");
                // Create your new customer instance
                var entry = new ProjectEntry
                {
                    Title = title,
                    Description = description,
                    Reputation = 0,
                    Tags = tags
                };
                // Insert new customer document (Id will be auto-incremented)
                coll.Insert(entry);
            }
        }

        public void DeleteProjectEntry(int id)
        {
            // Open database (or create if doesn't exist)
            using (var db = new LiteDatabase(dbPath))
            {
                // Get a collection (or create, if doesn't exist)
                var coll = db.GetCollection<ProjectEntry>("projectentries");

                var result = coll.Query().Where(x => x.Id == id).Single();

                coll.Delete(result.Id);
            }
        }
    }
}
