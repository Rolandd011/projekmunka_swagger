using Microsoft.EntityFrameworkCore;
using MyApp.Backend.Models;

namespace MyApp.Backend.Context
{
    /// <summary>
    ///     Az alkalmazás elsődleges Entity Framework Core adatbázis kontextusa.
    ///     Ez határozza meg, hogy a domain entitások hogyan kerülnek leképezésre az adatbázis tábláira,
    ///     valamint beállítja a konvenciókat, kapcsolatokat és a tesztadatokat az 
    ///     <see cref="OnModelCreating(ModelBuilder)"/> metódusban.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         A kontextus a függőségi injektáláson keresztül kerül regisztrálásra
    ///         (<c>AddDbContext></c>), és több különböző adatbázis-szolgáltatóval is használható:
    ///         <list type="bullet">
    ///             <item><description><b>InMemory</b> – teszteléshez</description></item>
    ///             <item><description><b>SQLite</b> – könnyű, helyi fejlesztési környezethez</description></item>
    ///             <item><description><b>MySQL</b> – éles vagy felhő alapú rendszerekhez</description></item>
    ///         </list>
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Tipikus regisztráció a <c>Program.cs</c> fájlban:
    ///     <code language="csharp">
    ///     builder.Services.AddDbContext<AppDbContext>(options =>
    ///         options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
    ///     </code>
    /// </example>
    /// 


    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Issue> Issues => Set<Issue>();

        public DbSet<Location> Locations => Set<Location>();

        public DbSet<Priority> Priorities => Set<Priority>();

        public DbSet<Role> Roles => Set<Role>();

        public DbSet<Status> Statuses => Set<Status>();

        public DbSet<User> Users => Set<User>();

        public DbSet<UserAction> UserActions => Set<UserAction>();

        protected AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ez tölti be a konfigurációkat (ez megvolt)
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            // EZ HIÁNYZOTT: Itt hívjuk meg a feltöltést!
            modelBuilder.Seed();
        }
    }

}
