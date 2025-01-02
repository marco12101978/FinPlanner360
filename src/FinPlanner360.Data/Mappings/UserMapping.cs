using FinPlanner360.Business.Models;
using FinPlanner360.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPlanner360.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            #region Mapping columns

            builder.ToTable("TB_USER");

            builder.HasKey(x => x.Id)
                .HasName("PK_TB_USER");

            builder.Property(x => x.Id)
                .HasColumnName("USER_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnName("NAME")
                .HasColumnType(DatabaseTypeConstant.Varchar)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("EMAIL")
                .HasColumnType(DatabaseTypeConstant.Varchar)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.AuthenticationId)
                .HasColumnName("AUTHENTICATION_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            #endregion Mapping columns


            #region Relationships

            builder.HasMany(x => x.Transactions)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_TB_USER_01")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Categories)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_TB_USER_02")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Budgets)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_TB_USER_03")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.GeneralBudgets)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_TB_USER_04")
                .OnDelete(DeleteBehavior.Cascade);

            #endregion Relationships
        }
    }
}
