using GymManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagement.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(nameof(Plan.Name)).HasColumnType("VARCHAR").HasMaxLength(50);

            builder.Property(nameof(Plan.Description)).HasMaxLength(200);

            builder.Property(nameof(Plan.Price)).HasPrecision(10, 2);

            builder.Property(nameof(Plan.CreatedAt)).HasDefaultValueSql("GETDATE()");

            builder.ToTable(tb => tb.HasCheckConstraint("PlanDurationDaysCheck", "DurationDays between 1 and 365"));

        }
    }
}
