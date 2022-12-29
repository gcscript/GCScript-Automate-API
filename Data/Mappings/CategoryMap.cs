using GCScript_Automate_API.Models;
using GCScript_Automate_API.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript_Automate_API.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<CategoryModel>
    {
        public void Configure(EntityTypeBuilder<CategoryModel> builder)
        {
            builder.ToTable("Category");

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

            builder.HasIndex(x => x.Code, "IX_Category_Code")
                   .IsUnique();

            builder.HasMany(x => x.Types)
                   .WithOne(x => x.Category)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new CategoryModel() { Id = Guid.Parse("49e252cd-68c3-4a93-9672-c4f868411c13"), Code = "acompanhamentos", Name = "Acompanhamentos" },
                                 new CategoryModel() { Id = Guid.Parse("bba09c0b-2e5f-427c-9fd9-08e363901334"), Code = "compromissos", Name = "Compromissos" });
        }
    }

    public class CategoryPostViewModelMap : IEntityTypeConfiguration<CategoryPostViewModel>
    {
        public void Configure(EntityTypeBuilder<CategoryPostViewModel> builder)
        {
            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }

    public class CategoryPutViewModelMap : IEntityTypeConfiguration<CategoryPutViewModel>
    {
        public void Configure(EntityTypeBuilder<CategoryPutViewModel> builder)
        {
            builder.Property(x => x.Id)
                   .IsRequired();

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);
        }
    }

}
