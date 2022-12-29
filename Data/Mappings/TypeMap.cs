using GCScript_Automate_API.Models;
using GCScript_Automate_API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript_Automate_API.Data.Mappings
{
    public class TypeMap : IEntityTypeConfiguration<TypeModel>
    {
        public void Configure(EntityTypeBuilder<TypeModel> builder)
        {
            builder.ToTable("Type");

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

            builder.HasIndex(x => new { x.Code, x.CategoryId }, "IX_Type_Code_CategoryId")
                   .IsUnique();

            builder.HasMany(x => x.Subtypes)
                   .WithOne(x => x.Type)
                   .HasForeignKey(x => x.TypeId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.CategoryId)
                   .IsRequired()
                   .HasColumnName("CategoryId");
        }
    }

    public class TypePostViewModelMap : IEntityTypeConfiguration<TypePostViewModel>
    {
        public void Configure(EntityTypeBuilder<TypePostViewModel> builder)
        {
            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }

    public class TypePutViewModelMap : IEntityTypeConfiguration<TypePutViewModel>
    {
        public void Configure(EntityTypeBuilder<TypePutViewModel> builder)
        {
            builder.Property(x => x.Id)
                   .IsRequired();

            builder.Property(x => x.Code)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }
}
