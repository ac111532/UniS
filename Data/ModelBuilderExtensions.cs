﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace UniS.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            var pwd = "P@$$w0rd";
            var passwordHasher = new PasswordHasher<Customer>();

            // Seed Roles
            var adminRole = new IdentityRole("Admin");
            adminRole.NormalizedName = adminRole.Name!.ToUpper();

            var customerRole = new IdentityRole("Customer");
            customerRole.NormalizedName = customerRole.Name!.ToUpper();

            List<IdentityRole> roles = new List<IdentityRole>() {
            adminRole,
            customerRole
            };

            builder.Entity<IdentityRole>().HasData(roles);


            // Seed Users
            var adminUser = new Customer
            {
                UserName = "admin@avcol.school.nz",
                Email = "admin@avcol.school.nz",
                EmailConfirmed = true,
                CustomerFirstName = "Admin",
                CustomerLastName = "Account",
                CustomerAddress = "School",
            };
            adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
            adminUser.NormalizedEmail = adminUser.Email.ToUpper();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, pwd);

            var customerUser = new Customer
            {
                UserName = "testcustomer@gmail.com",
                Email = "testcustomer@gmail.com",
                EmailConfirmed = true,
                CustomerFirstName = "Customer",
                CustomerLastName = "Account",
                CustomerAddress = "Home",

            };
            customerUser.NormalizedUserName = customerUser.UserName.ToUpper();
            customerUser.NormalizedEmail = customerUser.Email.ToUpper();
            customerUser.PasswordHash = passwordHasher.HashPassword(customerUser, pwd);

            List<Customer> users = new List<Customer>() {
                adminUser,
                customerUser,
            };

            builder.Entity<Customer>().HasData(users);

            // Seed UserRoles
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[1].Id,
                RoleId = roles.First(q => q.Name == "Customer").Id
            });


            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }

}