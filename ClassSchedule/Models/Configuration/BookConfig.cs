using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOrganizer.Models
{
    internal class BookConfig : IEntityTypeConfiguration<Title>
    {
        public void Configure(EntityTypeBuilder<Title> entity)
        {
            entity.HasOne(c => c.Author).WithMany(t => t.Titles).OnDelete(DeleteBehavior.Restrict);
            entity.HasData(
               new Title { Id = 1, BookTitle = "Sign Language", AuthorId = 1},
               new Title { Id = 2, BookTitle = "Sign Language", AuthorId = 1},
               new Title { Id = 3, BookTitle = "Logic", AuthorId = 4},
               new Title { Id = 4, BookTitle = "Logic", AuthorId = 4},
               new Title { Id = 5, BookTitle = "Early Childhood Education", AuthorId = 2},
               new Title { Id = 6, BookTitle = "Early Childhood Education", AuthorId = 2},
               new Title { Id = 7, BookTitle = "Calculus", AuthorId = 5 },
               new Title { Id = 8, BookTitle = "Calculus", AuthorId = 5},
               new Title { Id = 9, BookTitle = "Nonviolence and Social Change", AuthorId = 3},
               new Title { Id = 10, BookTitle = "Nonviolence and Social Change", AuthorId = 3 }
            );
        }
    }

}
