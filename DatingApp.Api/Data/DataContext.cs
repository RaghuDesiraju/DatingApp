using Microsoft.EntityFrameworkCore;
using DatingApp.Api.Models;
namespace DatingApp.Api.Data
{
    public class DataContext:DbContext
    {
         //dbcontext represents session in db and can be used to query and save instances of entities
         //Its a combn of the unit of work and repository patterns 
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {            
        }

        //THIS is going to be table name
        public DbSet<DatingApp.Api.Models.Value>Values{get;set;}
    }
}