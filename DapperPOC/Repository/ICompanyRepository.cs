using DapperPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPOC.Repository
{
    public interface ICompanyRepository
    {
        Company Find(int companyId);
        List<Company> GetCompanies();
        Company AddCompany(Company company);
        Company UpdateCompany(Company company);
        void DeleteCompany(int companyId);
    }
}
