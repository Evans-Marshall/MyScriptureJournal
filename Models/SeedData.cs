using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MyScriptureJournal.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.JournalEntry.Any())
                {
                    return;   // DB has been seeded
                }

                context.JournalEntry.AddRange(
                    new JournalEntry
                    {
                        Title = "My Rock",
                        EntryDate = DateTime.Parse("2020-02-19"),
                        Book = "The Book of Mormon",
                        Reference = "Helaman 5:12",
                        Notes = "Wise Man and Foolish Man",
                    },

                    new JournalEntry
                    {
                        Title = "Distil as the dews from heaven",
                        EntryDate = DateTime.Parse("2020-02-19"),
                        Book = "Doctrine and Covenants",
                        Reference = "121:45",
                        Notes = "the doctrine of the priesthood shall distil upon thy soul",
                    },

                    new JournalEntry
                    {
                        Title = "Sing Good Songs",
                        EntryDate = DateTime.Parse("2020-02-19"),
                        Book = "Doctrine and Covenants",
                        Reference = "25:12",
                        Notes = "Prayer of the righteous",
                    },

                    new JournalEntry
                    {
                        Title = "Chiasmus",
                        EntryDate = DateTime.Parse("2020-02-19"),
                        Book = "Book of Mormon",
                        Reference = "Alma 36",
                        Notes = "The entire chapter is a chiasmus",
                    }
                );
                context.SaveChanges();
            }
        }
    }
}