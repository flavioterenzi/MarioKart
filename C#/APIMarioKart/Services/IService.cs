namespace APIMarioKart.Services
{
    public interface IService<T>
    {
        IEnumerable<T> PrendiliTutti();
    }
}
