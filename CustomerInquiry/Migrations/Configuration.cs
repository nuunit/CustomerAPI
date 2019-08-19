namespace CustomerInquiry.Migrations
{
    using CustomerInquiry.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CustomerInquiry.Models.CustomerInquiryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CustomerInquiry.Models.CustomerInquiryContext";
        }

        protected override void Seed(CustomerInquiry.Models.CustomerInquiryContext context)
        {

            context.Customers.AddOrUpdate(x => x.Id,
                    new Customer()
                    {
                        Id = 1,
                        Name = "Firstname Lastname",
                        Email = "user@domain.com",
                        MobileNumber = "0123456789",
                        Transactions = new List<Transaction>(){
                                        new Transaction(){
                                            Id=1,
                                            TransactionDate = new DateTime(2019,02,2,21,34,00),
                                            Amount =1234.56M,
                                            CurrencyCode = "USD",
                                            Status = TransactionStatus.Success
                                        }
                                    }
                    },
                    new Customer()
                    {
                        Id = 2,
                        Name = "FirstnameB LastnameB",
                        Email = "userB@domain.com",
                        MobileNumber = "0123456789",
                        Transactions = null
                        
                    },
                    new Customer()
                        {
                            Id = 3,
                            Name = "FirstnameC LastnameC",
                            Email = "userC@domain.com",
                            MobileNumber = "0123456789",
                            Transactions = new List<Transaction>(){
                                        new Transaction(){
                                            Id=1,
                                            TransactionDate = new DateTime(2019,03,18,21,34,00),
                                            Amount =1534.56M,
                                            CurrencyCode = "USD",
                                            Status = TransactionStatus.Success
                                        },
                                            new Transaction(){
                                            Id=2,
                                            TransactionDate = new DateTime(2019,03,18,20,34,00),
                                            Amount =1534.56M,
                                            CurrencyCode = "USD",
                                            Status = TransactionStatus.Failed
                                        }
                                    }
                        }
            );

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
        }
    }
}
