using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryOrganizer.Models
{
    internal class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> entity)
        {
            entity.HasData(
               new Author { AuthorId = 1, FirstName = "Anne", LastName = "Sullivan" },
               new Author { AuthorId = 2, FirstName = "Maria", LastName = "Montessori" },
               new Author { AuthorId = 3, FirstName = "Martin Luther", LastName = "King" },
               new Author { AuthorId = 4, FirstName = "", LastName = "Aristotle" },
               new Author { AuthorId = 5, FirstName = "Jaime", LastName = "Escalante" }
            );
        }
    }

}
