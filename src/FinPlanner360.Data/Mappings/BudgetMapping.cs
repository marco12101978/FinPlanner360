using FinPlanner360.Business.Models;
using FinPlanner360.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPlanner360.Data.Mappings
{
    public class BudgetMapping : IEntityTypeConfiguration<Budget>
    {
        public void Configure(EntityTypeBuilder<Budget> builder)
        {
            #region Mapping columns

            builder.ToTable("TB_BUDGET");

            builder.HasKey(x => x.Id)
                .HasName("PK_TB_BUDGET");

            builder.Property(x => x.Id)
                .HasColumnName("BUDGET_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .HasColumnName("CATEGORY_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnType(DatabaseTypeConstant.Money)
                .HasPrecision(2)
                .IsRequired();

            builder.Property(x => x.CreatedDate)
                .HasColumnName("CREATED_DATE")
                .HasColumnType(DatabaseTypeConstant.DateTime)
                .IsRequired();

            builder.Property(x => x.RemovedDate)
                .HasColumnName("REMOVED_DATE")
                .HasColumnType(DatabaseTypeConstant.DateTime);

            #endregion Mapping columns

            #region Indexes

            builder.HasIndex(x => x.UserId).HasDatabaseName("IDX_TB_BUDGET_01");

            #endregion Indexes

            #region Relationships

            builder.HasOne(x => x.User)
                .WithMany(x => x.Budgets)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_TB_BUDGET_01")
                .OnDelete(DeleteBehavior.NoAction);

            #endregion Relationships
        }
    }
}
