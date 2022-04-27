namespace CMS.Business.Contracts
{
    public interface IAutoMap
    {
        TDestination MapTo<TSource, TDestination>(TSource source);
        TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination);
        TDestination MapTo<TDestination>(object source);
    }
}
