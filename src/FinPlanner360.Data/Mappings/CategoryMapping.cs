﻿using FinPlanner360.Business.Models;
using FinPlanner360.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinPlanner360.Data.Mappings
{
    internal class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            #region Mapping columns

            builder.ToTable("TB_CATEGORY");

            builder.HasKey(x => x.Id)
                .HasName("PK_TB_CATEGORY");

            builder.Property(x => x.Id)
                .HasColumnName("CATEGORY_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier)
                .IsRequired();

            builder.Property(x => x.UserId)
                .HasColumnName("USER_ID")
                .HasColumnType(DatabaseTypeConstant.UniqueIdentifier);

            builder.Property(x => x.Description)
                .HasColumnName("DESCRIPTION")
                .HasColumnType(DatabaseTypeConstant.Varchar)
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.Type)
                .HasColumnName("TYPE")
                .HasColumnType(DatabaseTypeConstant.Byte)
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

            builder.HasIndex(x => x.UserId).HasDatabaseName("IDX_TB_CATEGORY_01");

            #endregion Indexes

            #region Relationships

            builder.HasOne(x => x.User)
                .WithMany(x => x.Categories)
                .HasForeignKey(x => x.UserId)
                .HasConstraintName("FK_TB_CATEGORY_01")
                .OnDelete(DeleteBehavior.NoAction);

            #endregion Relationships
        }
    }
}
