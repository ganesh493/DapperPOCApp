using DapperPOC.Data;
using DapperPOC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace DapperPOC.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private IDbConnection database;
        public CompanyRepository(IConfiguration configuration)
        {
            this.database = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }
        public Company AddCompany(Company company)
        {
            //var sqlQuery = "INSERT INTO Companies (Name, Address, City, State, PostalCode) VALUES(@Name, @Address, @City, @State, @PostalCode);"
            //    + "SELECT CAST(SCOPE_IDENTITY() as int); ";
            //var companyId = database.Query<int>(sqlQuery, company).Single();
            var companyId = database.Query<int>("ADDCOMPANY", company, commandType: CommandType.StoredProcedure).Single();
            company.CompanyId = companyId;
            return company;
        }

        public void DeleteCompany(int companyId)
        {
            var sqlQuery = "DELETE FROM Companies WHERE CompanyId = @CompanyId";
            database.Execute(sqlQuery, new { @CompanyId = companyId });
        }

        public Company Find(int companyId)
        {
            var sqlQuery = "SELECT * FROM Companies WHERE CompanyId = @CompanyId";
            return database.Query<Company>(sqlQuery, new { @CompanyId = companyId }).Single();
        }

        public List<Company> GetCompanies()
        {
            //var sqlQuery = "SELECT * FROM Companies";
            //return database.Query<Company>(sqlQuery).ToList();

            return database.Query<Company>("GETCOMAPNIES", commandType: CommandType.StoredProcedure).ToList();
        }

        public Company UpdateCompany(Company company)
        {
            var sqlQuery = "UPDATE Companies SET Name=@Name, Address= @Address, City=@City, State=@State, PostalCode=@PostalCode WHERE CompanyId = @CompanyId";
            database.Execute(sqlQuery, company);
            return company;
        }
    }
}
