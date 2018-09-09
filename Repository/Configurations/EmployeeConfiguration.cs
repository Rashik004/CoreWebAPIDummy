using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Configurations
{
    class EnvironmentConfiguration : IEntityTypeConfiguration<Repository.Models.Environment>
    {
        public void Configure(EntityTypeBuilder<Models.Environment> builder)
        {
            builder.HasKey(e => e.EnvironmentId);
            builder.Property(e => e.EnvironmentName).IsRequired().HasMaxLength(20);
        }
    }
}
