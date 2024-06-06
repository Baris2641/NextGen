using Microsoft.EntityFrameworkCore;

namespace efCoreApp.Data
{
    public class CaseFileContext:  DbContext
    {
        public CaseFileContext(DbContextOptions<CaseFileContext> options): base(options)
        {
            
        }
        public DbSet<CaseFile> CaseFiles => Set<CaseFile>();
        public DbSet<User> Users  => Set<User>();
        public DbSet<CaseFileStatus> CaseFileStatuses => Set<CaseFileStatus>();
    }
}