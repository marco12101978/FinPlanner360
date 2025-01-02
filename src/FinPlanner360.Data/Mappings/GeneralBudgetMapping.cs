using FinPlanner360.Business.Models;
using FinPlanner360.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPlanner360.Data.Mappings
{
    internal class GeneralBudgetMapping : IEntityTypeConfiguration<GeneralBudget>
    {
        public void Configure(EntityTypeBuilder<GeneralBudget> builder)
        {
            #region Mapping columns

            builder.ToTable("TB_GENERAL_BUDGET");

            builder.HasKey(x => x.Id)
                .HasName("PK_TB_GENERAL_BUDGET");

            builder.Property(x => x.Id)
                .HasColumnName("GENERAL_BUDGET_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnType(DatabaseTypeConstant.Money)
                .HasPrecision(2);

            builder.Property(x => x.Percentage)
                .HasColumnName("PERCENTAGE")
                .HasColumnType(DatabaseTypeConstant.Money)
                .HasPrecision(0);


            #endregion Mapping columns


            #region Indexes

            builder.HasIndex(x => x.UserId).HasDatabaseName("IDX_TB_GENERAL_BUDGET_01");

            #endregion Indexes

            #region Relationships

            builder.HasOne(x => x.User)
                .WithMany(x => x.GeneralBudgets)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_TB_GENERAL_BUDGET_01")
                .OnDelete(DeleteBehavior.NoAction);

            #endregion Relationships
        }
    }
}
