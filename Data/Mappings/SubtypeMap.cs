using GCScript_Automate_API.Models;
using GCScript_Automate_API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript_Automate_API.Data.Mappings
{
    public class SubtypeMap : IEntityTypeConfiguration<SubtypeModel>
    {
        public void Configure(EntityTypeBuilder<SubtypeModel> builder)
        {
            builder.ToTable("Subtype");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasColumnName("Code")
                   .HasMaxLength(100);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasColumnName("Name")
                   .HasMaxLength(100);

            builder.Property(x => x.Registered)
                   .IsRequired()
                   .HasColumnName("Registered")
                   .HasPrecision(6);

            builder.HasIndex(x => new { x.Code, x.TypeId }, "IX_Subtype_Code_TypeId")
                   .IsUnique();

            builder.Property(x => x.TypeId)
                   .IsRequired();
        }
    }
    public class SubtypePostViewModelMap : IEntityTypeConfiguration<SubtypePostViewModel>
    {
        public void Configure(EntityTypeBuilder<SubtypePostViewModel> builder)
        {
            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.TypeCode)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }

    public class SubtypePutViewModelMap : IEntityTypeConfiguration<SubtypePutViewModel>
    {
        public void Configure(EntityTypeBuilder<SubtypePutViewModel> builder)
        {
            builder.Property(x => x.Id)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.TypeCode)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
