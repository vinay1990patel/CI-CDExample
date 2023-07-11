using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Models;

namespace UnitOfWorkDemo.Infrastructure.Configurations
{
    internal class StudentAddressConfiguration : IEntityTypeConfiguration<StudentAddress>
    {
        public void Configure(EntityTypeBuilder<StudentAddress> builder)
        {
            builder.HasKey(sa => sa.StudentAddressId);

            builder.HasOne<Student>(sa => sa.Student)
                   .WithOne(sa => sa.Address)
                   .HasForeignKey<StudentAddress>(sa => sa.AddressOfStudentId);
                  

        }
    }
}
