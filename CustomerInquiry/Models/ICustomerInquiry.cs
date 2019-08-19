using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiry.Models
{
    public interface ICustomerInquiry : IDisposable
    {
        DbSet<Customer> Customers { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void MarkAsModified(Customer item);    
    }
}
