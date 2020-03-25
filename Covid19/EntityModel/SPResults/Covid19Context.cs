using Covid19.EntityModel.SPResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Covid19.EntityModel
{
    public partial class Covid19Context : DbContext
    {
        public virtual DbSet<RPT_COVID19_DAILY_RESULT> RPT_COVID19_DAILY_RESULT { get; set; }
        public virtual DbSet<RPT_COVID19_DAILY_COUNTRY_RESULT> RPT_COVID19_DAILY_COUNTRY_RESULT { get; set; }
        public virtual DbSet<RPT_COVID19_DAILY_FLU_RESULT> RPT_COVID19_DAILY_FLU_RESULT { get; set; }
        public virtual DbSet<RPT_COVID19_DAILY_SYMTOM_RESULT> RPT_COVID19_DAILY_SYMTOM_RESULT { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RPT_COVID19_DAILY_RESULT>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<RPT_COVID19_DAILY_COUNTRY_RESULT>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<RPT_COVID19_DAILY_FLU_RESULT>(entity =>
            {
                entity.HasNoKey();
            });

            modelBuilder.Entity<RPT_COVID19_DAILY_SYMTOM_RESULT>(entity =>
            {
                entity.HasNoKey();
            });
        }
    }
}
