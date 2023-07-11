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
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        void IEntityTypeConfiguration<Student>.Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p =>p.StudentId);


            builder.HasOne<StudentAddress>(s => s.Address)
                  .WithOne(sa => sa.Student)
                  .HasForeignKey<StudentAddress>(sa =>sa.AddressOfStudentId);

          //  builder.Property(p =>p.Address).IsRequired().HasMaxLength(200);
            builder.Property(p =>p.StudentName).IsRequired().HasMaxLength(128);
            

        }
    }
}
