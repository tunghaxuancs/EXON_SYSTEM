namespace EXON.Data.Repositories
{
    public interface IDbFactory
    {
        EXONDbContext Init();
    }
}