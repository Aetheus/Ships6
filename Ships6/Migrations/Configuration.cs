namespace Ships6.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Ships6.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Diagnostics;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Ships6.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        Ships6.Models.ApplicationDbContext context;


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


        /*void SeedCruiseDestinations(List<CruiseDestination> cdArray)
        {
            var arr = cdArray.ToArray<CruiseDestination>();
            Debug.WriteLine("Length is: " + arr.Count());
            arr.Count();
            context.CruiseDestinations.AddOrUpdate(arr);

            List<CruiseDestination> cruiseDestinationList = new List<CruiseDestination>();
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 1, DestinationID = 10, tripOrder = 1, Cruise = context.Cruises.Find(1), Destination = context.Destinations.Find(10) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 1, DestinationID = 13, tripOrder = 2, Cruise = context.Cruises.Find(1), Destination = context.Destinations.Find(13) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 1, DestinationID = 17, tripOrder = 3, Cruise = context.Cruises.Find(1), Destination = context.Destinations.Find(17) });

            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 2, DestinationID = 21, tripOrder = 1, Cruise = context.Cruises.Find(2), Destination = context.Destinations.Find(21) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 2, DestinationID = 13, tripOrder = 2, Cruise = context.Cruises.Find(2), Destination = context.Destinations.Find(13) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 2, DestinationID = 19, tripOrder = 3, Cruise = context.Cruises.Find(2), Destination = context.Destinations.Find(19) });

            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 3, DestinationID = 3, tripOrder = 1, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(3) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 3, DestinationID = 7, tripOrder = 2, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(7) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 3, DestinationID = 14, tripOrder = 3, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(14) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 3, DestinationID = 16, tripOrder = 4, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(16) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 3, DestinationID = 9, tripOrder = 5, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(9) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 3, DestinationID = 18, tripOrder = 6, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(18) });

            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 4, DestinationID = 6, tripOrder = 1, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(6) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 4, DestinationID = 15, tripOrder = 2, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(15) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 4, DestinationID = 20, tripOrder = 3, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(20) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 4, DestinationID = 23, tripOrder = 4, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(23) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 4, DestinationID = 24, tripOrder = 5, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(24) });

            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 5, DestinationID = 4, tripOrder = 1, Cruise = context.Cruises.Find(5), Destination = context.Destinations.Find(4) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 5, DestinationID = 12, tripOrder = 2, Cruise = context.Cruises.Find(5), Destination = context.Destinations.Find(12) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 5, DestinationID = 13, tripOrder = 3, Cruise = context.Cruises.Find(5), Destination = context.Destinations.Find(13) });

            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 6, DestinationID = 5, tripOrder = 1, Cruise = context.Cruises.Find(6), Destination = context.Destinations.Find(5) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 6, DestinationID = 8, tripOrder = 2, Cruise = context.Cruises.Find(6), Destination = context.Destinations.Find(8) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 6, DestinationID = 11, tripOrder = 3, Cruise = context.Cruises.Find(6), Destination = context.Destinations.Find(11) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 6, DestinationID = 22, tripOrder = 4, Cruise = context.Cruises.Find(6), Destination = context.Destinations.Find(22) });

            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 7, DestinationID = 2, tripOrder = 1, Cruise = context.Cruises.Find(7), Destination = context.Destinations.Find(2) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 7, DestinationID = 17, tripOrder = 2, Cruise = context.Cruises.Find(7), Destination = context.Destinations.Find(17) });

            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 8, DestinationID = 4, tripOrder = 1, Cruise = context.Cruises.Find(8), Destination = context.Destinations.Find(4) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 8, DestinationID = 12, tripOrder = 2, Cruise = context.Cruises.Find(8), Destination = context.Destinations.Find(12) });

            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 9, DestinationID = 10, tripOrder = 1, Cruise = context.Cruises.Find(9), Destination = context.Destinations.Find(10) });
            cruiseDestinationList.Add(new CruiseDestination { CruiseID = 9, DestinationID = 5, tripOrder = 2, Cruise = context.Cruises.Find(9), Destination = context.Destinations.Find(5) });


            SeedCruiseDestinations(cruiseDestinationList);
        }*/


        void SeedCruiseDestinations()
        {
            context.CruiseDestinations.AddOrUpdate(
                new CruiseDestination { CruiseID = 1, DestinationID = 10, tripOrder = 1, Cruise = context.Cruises.Find(1), Destination = context.Destinations.Find(10) },
                new CruiseDestination { CruiseID = 1, DestinationID = 13, tripOrder = 2, Cruise = context.Cruises.Find(1), Destination = context.Destinations.Find(13) },
                new CruiseDestination { CruiseID = 1, DestinationID = 17, tripOrder = 3, Cruise = context.Cruises.Find(1), Destination = context.Destinations.Find(17) },

                new CruiseDestination { CruiseID = 2, DestinationID = 21, tripOrder = 1, Cruise = context.Cruises.Find(2), Destination = context.Destinations.Find(21) },
                new CruiseDestination { CruiseID = 2, DestinationID = 13, tripOrder = 2, Cruise = context.Cruises.Find(2), Destination = context.Destinations.Find(13) },
                new CruiseDestination { CruiseID = 2, DestinationID = 19, tripOrder = 3, Cruise = context.Cruises.Find(2), Destination = context.Destinations.Find(19) },

                new CruiseDestination { CruiseID = 3, DestinationID = 3, tripOrder = 1, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(3) },
                new CruiseDestination { CruiseID = 3, DestinationID = 7, tripOrder = 2, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(7) },
                new CruiseDestination { CruiseID = 3, DestinationID = 14, tripOrder = 3, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(14) },
                new CruiseDestination { CruiseID = 3, DestinationID = 16, tripOrder = 4, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(16) },
                new CruiseDestination { CruiseID = 3, DestinationID = 9, tripOrder = 5, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(9) },
                new CruiseDestination { CruiseID = 3, DestinationID = 18, tripOrder = 6, Cruise = context.Cruises.Find(3), Destination = context.Destinations.Find(18) },

                new CruiseDestination { CruiseID = 4, DestinationID = 6, tripOrder = 1, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(6) },
                new CruiseDestination { CruiseID = 4, DestinationID = 15, tripOrder = 2, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(15) },
                new CruiseDestination { CruiseID = 4, DestinationID = 20, tripOrder = 3, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(20) },
                new CruiseDestination { CruiseID = 4, DestinationID = 23, tripOrder = 4, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(23) },
                new CruiseDestination { CruiseID = 4, DestinationID = 24, tripOrder = 5, Cruise = context.Cruises.Find(4), Destination = context.Destinations.Find(24) },

                new CruiseDestination { CruiseID = 5, DestinationID = 4, tripOrder = 1, Cruise = context.Cruises.Find(5), Destination = context.Destinations.Find(4) },
                new CruiseDestination { CruiseID = 5, DestinationID = 12, tripOrder = 2, Cruise = context.Cruises.Find(5), Destination = context.Destinations.Find(12) },
                new CruiseDestination { CruiseID = 5, DestinationID = 13, tripOrder = 3, Cruise = context.Cruises.Find(5), Destination = context.Destinations.Find(13) },

                new CruiseDestination { CruiseID = 6, DestinationID = 5, tripOrder = 1, Cruise = context.Cruises.Find(6), Destination = context.Destinations.Find(5) },
                new CruiseDestination { CruiseID = 6, DestinationID = 8, tripOrder = 2, Cruise = context.Cruises.Find(6), Destination = context.Destinations.Find(8) },
                new CruiseDestination { CruiseID = 6, DestinationID = 11, tripOrder = 3, Cruise = context.Cruises.Find(6), Destination = context.Destinations.Find(11) },
                new CruiseDestination { CruiseID = 6, DestinationID = 22, tripOrder = 4, Cruise = context.Cruises.Find(6), Destination = context.Destinations.Find(22) },

                new CruiseDestination { CruiseID = 7, DestinationID = 2, tripOrder = 1, Cruise = context.Cruises.Find(7), Destination = context.Destinations.Find(2) },
                new CruiseDestination { CruiseID = 7, DestinationID = 17, tripOrder = 2, Cruise = context.Cruises.Find(7), Destination = context.Destinations.Find(17) },

                new CruiseDestination { CruiseID = 8, DestinationID = 4, tripOrder = 1, Cruise = context.Cruises.Find(8), Destination = context.Destinations.Find(4) },
                new CruiseDestination { CruiseID = 8, DestinationID = 12, tripOrder = 2, Cruise = context.Cruises.Find(8), Destination = context.Destinations.Find(12) },

                new CruiseDestination { CruiseID = 9, DestinationID = 10, tripOrder = 1, Cruise = context.Cruises.Find(9), Destination = context.Destinations.Find(10) },
                new CruiseDestination { CruiseID = 9, DestinationID = 5, tripOrder = 2, Cruise = context.Cruises.Find(9), Destination = context.Destinations.Find(5) }
            );
        }

        void SeedCruises(Ships6.Models.ApplicationDbContext context)
        {
            Cruise[] cruiseArray =  {
                    new Cruise{ //01
                        CruiseName = "Carribean Nights",
                        CruiseDescription = "Ahoy! Visit the sights and sounds of the carribean sea!",
                        CruiseDayLength = 15,
                        CruiseDepartureTime = new DateTime(2016,1,2,11,30,0),
                        CruisePrice = 9000,
                        OperatorID = 1,
                    },
                    new Cruise{ //02
                        CruiseName = "Arabian Seas",
                        CruiseDescription = "Open Sesame with the Arabian Cruise Line!",
                        CruiseDayLength = 9,
                        CruiseDepartureTime = new DateTime(2016,5,4,4,0,0),
                        CruisePrice = 7600,
                        OperatorID = 2,
                    },
                    new Cruise{ //03
                        CruiseName = "Asian Adventure",
                        CruiseDescription = "Indulge in the orient and more!",
                        CruiseDayLength = 12,
                        CruiseDepartureTime = new DateTime(2016,12,8,10,30,00),
                        CruisePrice = 6300,
                        OperatorID = 1,
                    },
                    new Cruise{ //04
                        CruiseName = "European Enigmas",
                        CruiseDescription = "Traverse the beautiful seas of Europe!",
                        CruiseDayLength = 17,
                        CruiseDepartureTime = new DateTime(2016,5,9,12,00,00),
                        CruisePrice = 8400,
                        OperatorID = 2,
                    },
                    new Cruise{ //05
                        CruiseName = "The Christoper Columbus Experience",
                        CruiseDescription = "From the old world to the new! Experience the thrill of discovery!",
                        CruiseDayLength = 21,
                        CruiseDepartureTime = new DateTime(2016,11,11,12,00,00),
                        CruisePrice = 10000,
                        OperatorID = 1,
                    },
                    new Cruise{ //06
                        CruiseName = "Around the World in 80 Days",
                        CruiseDescription = "Prepare for the adventure of a lifetime! Travel the world!",
                        CruiseDayLength = 80,
                        CruiseDepartureTime = new DateTime(2016,1,1,08,00,00),
                        CruisePrice = 50000,
                        OperatorID = 2,
                    },
                    new Cruise{ //07
                        CruiseName = "African Alightment",
                        CruiseDescription = "Journey to the beautiful coasts of Africa!",
                        CruiseDayLength = 11,
                        CruiseDepartureTime = new DateTime(2016,6,9,10,30,00),
                        CruisePrice = 7000,
                        OperatorID = 2,
                    },
                    new Cruise{ //08
                        CruiseName = "Northern Lights",
                        CruiseDescription = "Brave the cold and meet with adventure on the frigid norths!",
                        CruiseDayLength = 17,
                        CruiseDepartureTime = new DateTime(2016,8,12,11,30,00),
                        CruisePrice = 7500,
                        OperatorID = 1,
                    },
                    new Cruise{ //09
                        CruiseName = "Warm South Expedition",
                        CruiseDescription = "Enjoy warm tropical weather and all the wonders of the sandy south!",
                        CruiseDayLength = 17,
                        CruiseDepartureTime = new DateTime(2016,12,8,11,30,00),
                        CruisePrice = 7800,
                        OperatorID = 2,
                    }
            };

            context.Cruises.AddOrUpdate(p => p.CruiseName, cruiseArray);


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

            context.SaveChanges();

            SeedCruises(context);

            context.SaveChanges();
            //SeedCruiseDestinations();

        }
    }
}
