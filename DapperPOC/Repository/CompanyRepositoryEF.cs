using DapperPOC.Data;
using DapperPOC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperPOC.Repository
{
    public class CompanyRepositoryEF : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepositoryEF(ApplicationDbContext _context)
        {
            this._context = _context;
        }
        public Company AddCompany(Company company)
        {
            _context.Add(company);
            _context.SaveChanges();
            return company;
        }

        public void DeleteCompany(int companyId)
        {
            Company company = _context.Companies.FirstOrDefault(m => m.CompanyId == companyId);
            _context.Remove(company);
            _context.SaveChanges();
        }

        public Company Find(int companyId)
        {
            return _context.Companies.FirstOrDefault(m => m.CompanyId == companyId);
        }

        public List<Company> GetCompanies()
        {
            return _context.Companies.ToList();
        }

        public Company UpdateCompany(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();
            return company;
        }
    }
}
