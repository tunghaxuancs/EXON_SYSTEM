namespace EXON.Data.Repositories
{
    public class DbFactory : Disposable, IDbFactory
    {
        private EXONDbContext dbContext;

        public EXONDbContext Init()
        {
            return dbContext ?? (dbContext = new EXONDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}