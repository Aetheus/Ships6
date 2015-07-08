namespace Ships6.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Ships6.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ships6.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }



        bool AddUserAndRole(Ships6.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));

            ir = rm.Create(new IdentityRole("canEdit"));

            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
                UserProfile = new UserProfile
                {
                    FullName = "Bob McBob",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1993, 1, 1),
                    CreditCard = "1234-5678-9012-3452"
                }
            };
            ir = um.Create(user, "password1234#");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        void SeedOperators(ApplicationDbContext context)
        {
            context.Operators.AddOrUpdate(p => p.OperatorName,
                new Operator
                {
                    OperatorName = "Princess Cruise"
                },
                new Operator
                {
                    OperatorName = "Cunard Line"
                }
            );
        }

        void SeedCabinTypes(ApplicationDbContext context)
        {

            context.CabinTypes.AddOrUpdate(p => p.CabinTypeName,
                new CabinType
                {
                    CabinTypeName = "Inside Room",
                    CabinTypePrice = 250
                },
                new CabinType
                {
                    CabinTypeName = "Ocean View Room",
                    CabinTypePrice = 350
                },
                new CabinType
                {
                    CabinTypeName = "Balcony Room",
                    CabinTypePrice = 550
                },
                new CabinType
                {
                    CabinTypeName = "Suite Room",
                    CabinTypePrice = 550
                }
            );
        }

        void SeedDestinations(Ships6.Models.ApplicationDbContext context)
        {
            context.Destinations.AddOrUpdate(p => p.DestinationName,
                new Destination
                {
                    DestinationName = "no destination",
                    DestinationCountry = "nowhere"
                },
              new Destination
              {
                  DestinationName = "Cape Town",
                  DestinationCountry = "South Africa"
              },
              new Destination
              {
                  DestinationName = "Penang",
                  DestinationCountry = "Malaysia"
              },
              new Destination
              {
                  DestinationName = "San Fransicso",
                  DestinationCountry = "United States"
              },
              new Destination
              {
                  DestinationName = "Antartica",
                  DestinationCountry = "Antartica"
              },
              new Destination
              {
                  DestinationName = "Ellesmere Port",
                  DestinationCountry = "United Kingdoms"
              },
              new Destination
              {
                  DestinationName = "Osaka",
                  DestinationCountry = "Japan"
              },
              new Destination
              {
                  DestinationName = "Hong Kong",
                  DestinationCountry = "China"
              },
              new Destination
              {
                  DestinationName = "Nagoya",
                  DestinationCountry = "Japan"
              },
              new Destination
              {
                  DestinationName = "Port Royal",
                  DestinationCountry = "Jamaica"
              },
              new Destination
              {
                  DestinationName = "Sydney",
                  DestinationCountry = "Australia"
              },
              new Destination
              {
                  DestinationName = "Anchorage",
                  DestinationCountry = "United States"
              },
              new Destination
              {
                  DestinationName = "Lisbon",
                  DestinationCountry = "Spain"
              },
              new Destination
              {
                  DestinationName = "Singapore",
                  DestinationCountry = "Singapore"
              },
              new Destination
              {
                  DestinationName = "Liverpool",
                  DestinationCountry = "United Kingdoms"
              },
              new Destination
              {
                  DestinationName = "Pusan",
                  DestinationCountry = "South Korea"
              },
              new Destination
              {
                  DestinationName = "Dubrovnik",
                  DestinationCountry = "Croatia"
              },
              new Destination
              {
                  DestinationName = "Lisbon",
                  DestinationCountry = "Portugal"
              },
              new Destination
              {
                  DestinationName = "Beijing",
                  DestinationCountry = "China"
              },
              new Destination
              {
                  DestinationName = "Athens",
                  DestinationCountry = "Greece"
              },
              new Destination
              {
                  DestinationName = "Stockholm",
                  DestinationCountry = "Sweden"
              },
              new Destination
              {
                  DestinationName = "Istanbul",
                  DestinationCountry = "Turkey"
              },
              new Destination
              {
                  DestinationName = "Quebec City",
                  DestinationCountry = "Canada"
              },
              new Destination
              {
                  DestinationName = "St. Petersburg",
                  DestinationCountry = "Russia"
              },
              new Destination
              {
                  DestinationName = "Venice",
                  DestinationCountry = "Italy"
              }
            );
        }

        protected override void Seed(Ships6.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddUserAndRole(context);

            SeedOperators(context);
            SeedCabinTypes(context);
            SeedDestinations(context);

        }
    }
}
