namespace FlixOne.CQRS.Queries
{
    public interface IQueryHandler<in TQuery, out TResponse>:IQuery<TResponse>
    {
        TResponse Get();
    }
}