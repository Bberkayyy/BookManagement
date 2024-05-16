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
            a.Property(x => x.Id).HasColumnName("Id");
            a.Property(x => x.FirstName).HasColumnName("FirstName");
            a.Property(x => x.LastName).HasColumnName("LastName");
            a.Property(x => x.Country).HasColumnName("Country");

            a.HasMany(x => x.Books);
        });
        modelBuilder.Entity<AppUser>(u =>
        {
            u.ToTable("AppUsers").HasKey(x => x.Id);
            u.Property(x => x.Id).HasColumnName("Id");
            u.Property(x => x.FirstName).HasColumnName("FirstName");
            u.Property(x => x.LastName).HasColumnName("LastName");
            u.Property(x => x.Email).HasColumnName("Email");
            u.Property(x => x.Username).HasColumnName("Username");
            u.Property(x => x.Password).HasColumnName("Password");
        });
        modelBuilder.Entity<AppRole>(r =>
        {
            r.ToTable("AppRoles").HasKey(x => x.Id);
            r.Property(x => x.Id).HasColumnName("Id");
            r.Property(x => x.Name).HasColumnName("Name");
        });
        modelBuilder.Entity<AppUserRole>(ur =>
        {
            ur.ToTable("AppUserRoles").HasKey(x => x.Id);
            ur.Property(x => x.Id).HasColumnName("Id");

            ur.HasOne(x => x.User).WithMany(u => u.AppUserRoles).HasForeignKey(x => x.AppUserId);
            ur.HasOne(x => x.Role).WithMany(r => r.AppUserRoles).HasForeignKey(x => x.AppRoleId);

        });

        Guid categoryId = Guid.NewGuid();
        Guid authorId = Guid.NewGuid();
        Guid appUserId = Guid.NewGuid();

        modelBuilder.Entity<Category>().HasData(new Category() { Id = categoryId, Name = "Roman" });
        modelBuilder.Entity<Author>().HasData(new Author() { Id = authorId, FirstName = "John", LastName = "Verdon", Country = "ABD" });
        modelBuilder.Entity<Book>().HasData(new Book() { Id = Guid.NewGuid(), Name = "Aklından Bir Sayı Tut", Price = 122, Stock = 500, Description = "Sizi sizden bile iyi tanıyan bir katilin peşinizde olduğunu bilseniz, kaçmak için ne yapabilirsiniz? Polisiye türündeki eserleriyle okuyucuyu her defasında soluksuz bırakmayı başaran John Verdon’dan etkileyici bir yapıt daha! Aklında Bir Sayı Tut, bir seri katil ile onun peşine düşen bir dedektifin heyecan dolu kovalamacasını konu ediniyor. Bu katilin kurban seçtiği kişilerin ortak bir noktası var. Peki ama ne? Bu romanı okurken merakınıza engel olamayacak ve olayların sonunu asla tahmin edemeyeceksiniz!", AuthorId = authorId, CategoryId = categoryId });
        modelBuilder.Entity<AppRole>().HasData(new AppRole() { Id = 1, Name = "Admin" }, new AppRole() { Id = 2, Name = "Visitor" });
        modelBuilder.Entity<AppUser>().HasData(new AppUser() { Id = appUserId, FirstName = "FirstName", LastName = "LastName", Username = "Username", Password = "12345", Email = "seeduser@gmail.com" });
        modelBuilder.Entity<AppUserRole>().HasData(new AppUserRole() { Id = 1, AppUserId = appUserId, AppRoleId = 1 }, new AppUserRole() { Id = 2, AppUserId = appUserId, AppRoleId = 2 });
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<AppRole> AppRoles { get; set; }
    public DbSet<AppUserRole> AppUserRoles { get; set; }
}
