using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Data.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            builder.ToTable("AspNetUserRoles");
            builder.HasData(
            new AppUserRole
            {
                UserId = Guid.Parse("6286C136-92FA-4D66-B8D8-0B3AB4BBE33D"),
                RoleId = Guid.Parse("C98C470B-8494-45E0-8C5A-ACD32784F9CC")
            }, new AppUserRole
            {
                UserId = Guid.Parse("36C170AA-3CB6-45DC-89E8-2B7F86758A19"),
                RoleId = Guid.Parse("39FEAB6C-464E-40DD-961B-2B3E5A382594")

            }

            );
        }
    }
}
