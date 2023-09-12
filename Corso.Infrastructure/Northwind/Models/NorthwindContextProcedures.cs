﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Corso.Infrastructure.Northwind.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Corso.Infrastructure.Northwind.Models
{
    public partial class NorthwindContext
    {
        private INorthwindContextProcedures _procedures;

        public virtual INorthwindContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new NorthwindContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public INorthwindContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustOrderHistResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<CustOrdersDetailResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<CustOrdersOrdersResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<EmployeeSalesbyCountryResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<SalesbyYearResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<SalesByCategoryResult>().HasNoKey().ToView(null);
            modelBuilder.Entity<TenMostExpensiveProductsResult>().HasNoKey().ToView(null);
        }
    }

    public partial class NorthwindContextProcedures : INorthwindContextProcedures
    {
        private readonly NorthwindContext _context;

        public NorthwindContextProcedures(NorthwindContext context)
        {
            _context = context;
        }

        public virtual async Task<List<CustOrderHistResult>> CustOrderHistAsync(string CustomerID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "CustomerID",
                    Size = 10,
                    Value = CustomerID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<CustOrderHistResult>("EXEC @returnValue = [dbo].[CustOrderHist] @CustomerID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<CustOrdersDetailResult>> CustOrdersDetailAsync(int? OrderID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "OrderID",
                    Value = OrderID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<CustOrdersDetailResult>("EXEC @returnValue = [dbo].[CustOrdersDetail] @OrderID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<CustOrdersOrdersResult>> CustOrdersOrdersAsync(string CustomerID, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "CustomerID",
                    Size = 10,
                    Value = CustomerID ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<CustOrdersOrdersResult>("EXEC @returnValue = [dbo].[CustOrdersOrders] @CustomerID", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<EmployeeSalesbyCountryResult>> EmployeeSalesbyCountryAsync(DateTime? Beginning_Date, DateTime? Ending_Date, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Beginning_Date",
                    Value = Beginning_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "Ending_Date",
                    Value = Ending_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<EmployeeSalesbyCountryResult>("EXEC @returnValue = [dbo].[Employee Sales by Country] @Beginning_Date, @Ending_Date", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<SalesbyYearResult>> SalesbyYearAsync(DateTime? Beginning_Date, DateTime? Ending_Date, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "Beginning_Date",
                    Value = Beginning_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                new SqlParameter
                {
                    ParameterName = "Ending_Date",
                    Value = Ending_Date ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.DateTime,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SalesbyYearResult>("EXEC @returnValue = [dbo].[Sales by Year] @Beginning_Date, @Ending_Date", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<SalesByCategoryResult>> SalesByCategoryAsync(string CategoryName, string OrdYear, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "CategoryName",
                    Size = 30,
                    Value = CategoryName ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                new SqlParameter
                {
                    ParameterName = "OrdYear",
                    Size = 8,
                    Value = OrdYear ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.NVarChar,
                },
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<SalesByCategoryResult>("EXEC @returnValue = [dbo].[SalesByCategory] @CategoryName, @OrdYear", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }

        public virtual async Task<List<TenMostExpensiveProductsResult>> TenMostExpensiveProductsAsync(OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                parameterreturnValue,
            };
            var _ = await _context.SqlQueryAsync<TenMostExpensiveProductsResult>("EXEC @returnValue = [dbo].[Ten Most Expensive Products]", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
