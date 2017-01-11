namespace CA_EF
{
    using System.Data.Entity;

    public partial class TestEF : DbContext
    {
        public TestEF()
            : base("name=TestEF")
        {
        }

        public virtual DbSet<my_table> my_table { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<my_table>()
                .Property(e => e.name)
                .IsUnicode(false);
        }
    }
}
