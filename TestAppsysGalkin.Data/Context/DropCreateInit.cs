﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAppsysGalkin.Data.Model;

namespace TestAppsysGalkin.Data.Context
{
    public class DropCreateInit : DropCreateDatabaseAlways<MainContext>
    {
        protected static string solution_path = Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));

        protected override void Seed(MainContext context)
        {
            var passwordHash = new PasswordHasher();
            //base.Seed(context);
            var Users = new List<ApplicationUser>
            {
                new ApplicationUser {  UserName = "user1", PasswordHash = passwordHash.HashPassword("12345"), SecurityStamp="randomString" },
                new ApplicationUser {  UserName = "user2", PasswordHash = passwordHash.HashPassword("qwerty"), SecurityStamp="Cuz its necessary"},
                new ApplicationUser {  UserName = "user3", PasswordHash = passwordHash.HashPassword("asdfgh"), SecurityStamp="for EF"},
            };

            var UserProfiles = new List<UserProfile>
            {
                new UserProfile { UserId = Users[0].Id},
                new UserProfile { UserId = Users[1].Id },
                new UserProfile { UserId = Users[2].Id },
            };
            
            Users.ForEach(s => context.Users.Add(s));
            UserProfiles.ForEach(s => context.UserProfiles.Add(s));

            var Message = new Message { FromUser = UserProfiles[0], ToUser = UserProfiles[1], Text = "Default message from user1 to user2" };
            context.Messages.Add(Message);
            context.SaveChanges();
            
            var Producers = new List<Producer>
            {
                new Producer {Name="Beats" },
                new Producer {Name="Razer" },
                new Producer {Name="AUDIO-TECHNICA" },
                new Producer {Name="Pioneer" },
                new Producer {Name="Sennheiser" }
            };

            context.SaveChanges();

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = false,
                    IsDetachableCable = false
                },
                Producer = Producers.Single(p=>p.Name=="Beats"),
                Name = "Studio",
                Price = 15000,
                Image = "/Content/Images/redBeats.jpg",
            });

            context.SaveChanges();

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = true,
                    IsDetachableCable = true
                },
                Producer = Producers.Single(p => p.Name == "Beats"),
                Name = "Pro Infinite",
                Price = 30000,
                Image = "/Content/Images/Beats_Pro_Infinite_Black.jpg",
            });

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 10,
                    IsPortable = false,
                    IsDetachableCable = false
                },
                Producer = Producers.Single(p => p.Name == "Razer"),
                Name = "Tiamat 7.1",
                Price = 17000,
                Image = "/Content/Images/razer_titanit71.jpg",
            });

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = false,
                    IsDetachableCable = false
                },
                Producer = Producers.Single(p => p.Name == "Razer"),
                Name = "Kraken Pro 2015",
                Price = 8000,
                Image = "/Content/Images/Razer_Kraken_pro2015.jpg",
            });

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = false,
                    IsDetachableCable = false
                },
                Producer = Producers.Single(p => p.Name == "Razer"),
                Name = "Kraken Pro 2015",
                Price = 8000,
                Image = "/Content/Images/Razer_Kraken_pro2015_White.jpg",
            });

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = false,
                    IsDetachableCable = false
                },
                Producer = Producers.Single(p => p.Name == "AUDIO-TECHNICA"),
                Name = "ATH-MSR7",
                Price = 18000,
                Image = "/Content/Images/Audio-Technica-ATH-MSR7.jpg",
            });

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = true,
                    IsDetachableCable = true
                },
                Producer = Producers.Single(p => p.Name == "Pioneer"),
                Name = "SE-MX9-S",
                Price = 21000,
                Image = "/Content/Images/Pioneer_ SE-MX9-S.jpg",
            });

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = true,
                    IsDetachableCable = true
                },
                Producer = Producers.Single(p => p.Name == "Pioneer"),
                Name = "SE-MX9-K",
                Price = 21000,
                Image = "/Content/Images/pioneer-se-mx9-k.jpg",
            });

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = true,
                    IsDetachableCable = false
                },
                Producer = Producers.Single(p => p.Name == "Sennheiser"),
                Name = "MOMENTUM M2 IEG",
                Price = 5000,
                Image = "/Content/Images/Sennheiser_Momentum.jpg",
            });

            context.Products.Add(new Product
            {
                HeadPhone = new HeadPhone
                {
                    DynamicQuantity = 2,
                    IsPortable = false,
                    IsDetachableCable = false
                },
                Producer = Producers.Single(p => p.Name == "Sennheiser"),
                Name = "G4ME ZERO",
                Price = 15000,
                Image = "/Content/Images/Sennheiser_G4ME_ZERO.jpg",
            });

            context.SaveChanges();
        }
    }
}
