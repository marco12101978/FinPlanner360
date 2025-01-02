using FinPlanner360.Business.Models;
using FinPlanner360.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPlanner360.Data.Mappings
{
    internal class TransactionMapping : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            #region Mapping columns

            builder.ToTable("TB_TRANSACTION");

            builder.HasKey(x => x.Id)
                .HasName("PK_TB_TRANSACTION");

            builder.Property(x => x.Id)
                .HasColumnName("TRANSACTION_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType(DatabaseTypeConstant.Varchar)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnName("AMOUNT")
                .HasColumnType(DatabaseTypeConstant.Money)
                .HasPrecision(2)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnName("TYPE")
                .HasColumnType(DatabaseTypeConstant.Byte)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .HasColumnName("CATEGORY_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.TransactionDate)
                .HasColumnName("TRANSACTION_DATE")
                .HasColumnType(DatabaseTypeConstant.SmallDateTime)
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

            builder.HasIndex(x => x.UserId).HasDatabaseName("IDX_TB_TRANSACTION_01");

            #endregion Indexes

            #region Relationships

            builder.HasOne(x => x.User)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_TB_TRANSACTION_01")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.CategoryId)
                .HasConstraintName("FK_TB_TRANSACTION_02")
                .OnDelete(DeleteBehavior.Restrict);

            #endregion Relationships
        }
    }
}
