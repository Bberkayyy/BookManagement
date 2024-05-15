using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;

namespace DataAccess.Context;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public BaseDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(b =>
        {
            b.ToTable("Books").HasKey(x => x.Id);
            b.Property(x => x.Id).HasColumnName("Id");
            b.Property(x => x.CategoryId).HasColumnName("CategoryId");
            b.Property(x => x.AuthorId).HasColumnName("AuthorId");
            b.Property(x => x.Name).HasColumnName("Name");
            b.Property(x => x.Description).HasColumnName("Description");
            b.Property(x => x.Price).HasColumnName("Price");
            b.Property(x => x.Stock).HasColumnName("Stock");

            b.HasOne(x => x.Category);
            b.HasOne(x => x.Author);
        });
        modelBuilder.Entity<Category>(c =>
        {
            c.ToTable("Categories").HasKey(x => x.Id);
            c.Property(x => x.Id).HasColumnName("Id");
            c.Property(x => x.Name).HasColumnName("Name");

            c.HasMany(x => x.Books);
        });
        modelBuilder.Entity<Author>(a =>
        {
            a.ToTable("Authors").HasKey(x => x.Id);
            a.Property(x => x.FirstName).HasColumnName("FirstName");
            a.Property(x => x.LastName).HasColumnName("LastName");
            a.Property(x => x.Phone).HasColumnName("Phone");
            a.Property(x => x.Email).HasColumnName("Email");
            a.Property(x => x.Age).HasColumnName("Age");

            a.HasMany(x => x.Books);
        });

        Guid categoryId = Guid.NewGuid();
        Guid authorId = Guid.NewGuid();

        modelBuilder.Entity<Category>().HasData(new Category() { Id = categoryId, Name = "Roman" });
        modelBuilder.Entity<Author>().HasData(new Author() { Id = authorId, FirstName = "John", LastName = "Verdon", Phone = "05555555555", Email = "johnverdon@gmail.com", Age = 82 });
        modelBuilder.Entity<Book>().HasData(new Book() { Id = Guid.NewGuid(), Name = "Aklından Bir Sayı Tut", Price = 122, Stock = 500, Description = "Sizi sizden bile iyi tanıyan bir katilin peşinizde olduğunu bilseniz, kaçmak için ne yapabilirsiniz? Polisiye türündeki eserleriyle okuyucuyu her defasında soluksuz bırakmayı başaran John Verdon’dan etkileyici bir yapıt daha! Aklında Bir Sayı Tut, bir seri katil ile onun peşine düşen bir dedektifin heyecan dolu kovalamacasını konu ediniyor. Bu katilin kurban seçtiği kişilerin ortak bir noktası var. Peki ama ne? Bu romanı okurken merakınıza engel olamayacak ve olayların sonunu asla tahmin edemeyeceksiniz!", AuthorId = authorId, CategoryId = categoryId });
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Author> Authors { get; set; }
}
