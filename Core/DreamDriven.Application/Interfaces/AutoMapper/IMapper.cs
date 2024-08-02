namespace DreamDriven.Application.Interfaces.AutoMapper
{
    public interface IMapper
    {
        TDestination Map<TDestination, TSource>(TSource source, string? ignore = null); //tek veri icin

        IList<TDestination> Map<TDestination, TSource>(IList<TSource> source, string? ignore = null); // cok veri icin



        TDestination Map<TDestination>(object source, string? ignore = null); //tek veri icin
        IList<TDestination> Map<TDestination>(IList<object> source, string? ignore = null); //tek veri icin

    }
}
