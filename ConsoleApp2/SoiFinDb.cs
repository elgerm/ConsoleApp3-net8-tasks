using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ConsoleApp2
{

    public class SoiFinDb : Microsoft.EntityFrameworkCore.DbContext
    {
        public string Hostname { get; set; }

        private readonly IConfiguration configuration;

        public SoiFinDb(DbContextOptions<SoiFinDb> options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }
        public DbSet<TestTable> TestTables { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    [Table("test_table")]
    public class TestTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long MoneyTransactionId { get; set; }
        public int Amount { get; set; }
        public DateTime Created { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

}

