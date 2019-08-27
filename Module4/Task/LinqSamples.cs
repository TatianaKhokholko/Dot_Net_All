// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
//
//Copyright (C) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using SampleSupport;
using Task.Data;

namespace SampleQueries
{
	[Title("LINQ Module")]
	[Prefix("Linq")]
	public class LinqSamples : SampleHarness
	{
		private DataSource dataSource = new DataSource();

		[Category("LINQ")]
		[Title("Task 1")]
		[Description("Output the list of all customers whose total turnover is more than 'x'.")]
		public void Linq1()
		{
            decimal x = 5000;
            var totalTurnover = dataSource.Customers
                .Where (cust=> cust.Orders.Sum(total=>total.Total)>x)
                .Select (cust => new
                {
                    customerId = cust.CustomerID,
                    totalSum = cust.Orders.Sum(total => total.Total)
                });

            foreach (var total in totalTurnover)
            {
                Console.WriteLine($"ID => {total.customerId}, total turnover => {total.totalSum:C}");
            }
        }

		[Category("LINQ")]
		[Title("Task 2")]
		[Description("Output the list of suppliers in the same country and in the same city by customer.")]
        public void Linq2()
		{
            var resultGroup = from supliers in dataSource.Suppliers
                         join customers in dataSource.Customers on new {supliers.Country, supliers.City} equals new
                         {customers.Country, customers.City}
                         select new
                         {
                             countrySup = supliers.Country,
                             citySup = supliers.City,
                             nameSup = supliers.SupplierName,
                             customerName = customers.CompanyName
                         };
            foreach (var makeList1 in resultGroup)
            {
                Console.WriteLine($"The customer '{makeList1.customerName}' has suppliers: '{makeList1.nameSup}' " +
                    $"in the same country {makeList1.countrySup}({makeList1.citySup})");
            }
		}
        
        [Category("LINQ")]
        [Title("Task 3")]
        [Description("Output the list of all customers whose orders is more than 'x'.")]
        public void Linq3()
        {
            decimal x = 50000;
            var orders = dataSource.Customers
                .Where (ord => ord.Orders.Sum(total => total.Total) > x);

            foreach (var allCustomers in orders)
            {
                Console.WriteLine($"{allCustomers.CompanyName}");
            }
        }
        
        [Category("LINQ")]
        [Title("Task 4")]
        [Description("Output the first day of order.")]
        public void Linq4()
        {
            var allCustomersByDate = dataSource.Customers
                .Where(order => order.Orders.Any())
                .Select(order => new
                {
                    customerName = order.CompanyName,
                    firstOrderDay = order.Orders.OrderBy(ord => ord.OrderDate)
                    .Select(ord => ord.OrderDate).First()
                });
     

            foreach (var first in allCustomersByDate)
            {
                Console.WriteLine($"First order {first.firstOrderDay.Year}-{first.firstOrderDay.Month}-{first.firstOrderDay.Day} by {first.customerName}");
            }

        }

        [Category("LINQ")]
        [Title("Task 5")]
        [Description("Output the first day of order and sort by total turnover (max->min).")]
        public void Linq5()
        {
            var allCustomersByDate = dataSource.Customers
                .Where(order => order.Orders.Any())
                .Select(order => new
                {
                    firstOrderDay = order.Orders.OrderBy(ord => ord.OrderDate)
                    .Select(ord => ord.OrderDate).First(),
                    totalTurnover = order.Orders.Sum(total => total.Total),
                    customerName = order.CompanyName
                })
                .OrderByDescending(order => order.firstOrderDay.Year)
                .ThenByDescending(order => order.firstOrderDay.Month)
                .ThenByDescending(order => order.totalTurnover)
                .ThenByDescending(order => order.customerName);

            foreach (var first in allCustomersByDate)
            {
                Console.WriteLine(first);
            }
        }

        [Category("LINQ")]
        [Title("Task 6")]
        [Description("Output clients without region, operator code in the phone or without operator code.")]
        public void Linq6()
        {
            var customers = dataSource.Customers
                .Where(sort => sort.Region != null || sort.Phone.First() != '(' || sort.PostalCode.Any(s => s < 0 || s > 9));

            foreach (var sortedCustomers in customers)
            {
                Console.WriteLine(sortedCustomers.CompanyName + $" region = {sortedCustomers.Region}");
            }
        }

        [Category("LINQ")]
        [Title("Task 7")]
        [Description("Output group products by categories, then by units in stock, then order by price.")]
        public void Linq7()
        {
            var groupProduct = from category in dataSource.Products
                               orderby category.Category, category.UnitsInStock descending, category.UnitPrice descending
                               select new
                               {
                                   sortCatigory = category.Category,
                                   unitsInStock = category.UnitsInStock,
                                   unitPrice = category.UnitPrice
                               };

            foreach (var result in groupProduct)
            {
                Console.WriteLine(result);
            }
        }

        [Category("LINQ")]
        [Title("Task 8")]
        [Description("Output groups product by price: 'cheap', 'average', 'expensive'.")]
        public void Linq8()
        {
            decimal cheap = 8;
            decimal expensive = 25;

          //  var productGroups = dataSource.Products

            //foreach (var group in productGroups)
            //{
      
            //}
        }
                                

        [Category("LINQ")]
        [Title("Task 9")]
        [Description("Counts average order sum for all clients in every city.")]
        public void Linq9()
        {
            var results = dataSource.Customers
                .GroupBy(cus => cus.City)
                .Select(cus => new
                {
                    city = cus.Key,
                    avarageIntensity = cus.Average(pr => pr.Orders.Sum(order => order.Total))

                });

            foreach (var group in results)
            {
                Console.WriteLine($"select city : {group.city} with {group.avarageIntensity:C} ");
            }
        }

        [Category("LINQ")]
        [Title("Task 10")]
        [Description("Output average annual customer statistics by month, year, year and month.")]
        public void Linq10()
        {
            var statisticResult = dataSource.Customers
                 .Select(cus => new
                 {
                     cus.CustomerID,
                     statisticForMonth = cus.Orders.GroupBy(ord => ord.OrderDate.Month)
                                        .Select(group => new
                                        {
                                            month = group.Key,
                                            ordersCount = group.Count()
                                        }),
                    statisticForYear = cus.Orders.GroupBy(ord => ord.OrderDate.Year)
                                        .Select(group => new
                                        {
                                            year = group.Key,
                                            ordersCount = group.Count()
                                        }),
                     statisticYearMonth = cus.Orders
                                        .GroupBy(ord => new
                                        {
                                            ord.OrderDate.Year,
                                            ord.OrderDate.Month
                                        })
                                        .Select(group => new
                                        {
                                            group.Key.Year,
                                            group.Key.Month,
                                            ordersCount = group.Count()
                                        })
                 });

            foreach (var groupStatistic in statisticResult)
            {
                Console.WriteLine($"Customer {groupStatistic.CustomerID} ordered statistic:");
                foreach (var month in groupStatistic.statisticForMonth)
                {
                    Console.WriteLine($"1. per month: {month.month} = {month.ordersCount}");
                }

                foreach (var year in groupStatistic.statisticForYear)
                {
                    Console.WriteLine($"2. per year: {year.year} = {year.ordersCount}");
                }

                foreach (var monthYear in groupStatistic.statisticYearMonth)
                {
                    Console.WriteLine($"3. per : {monthYear.Year} {monthYear.Month} ordered = {monthYear.ordersCount}");
                }
            }
        }
    }
}
