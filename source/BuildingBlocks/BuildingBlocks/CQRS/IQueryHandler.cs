using MediatR;

namespace BuildingBlocks.CQRS;

public interface IQueryHander<in TQuery> : IRequestHandler<TQuery, Unit> 
    where TQuery : IQuery<Unit>
{
}


public interface IQueryHandler<in TQuery, TResonose>:IRequestHandler<TQuery, TResonose> 
    where TQuery : IQuery<TResonose>
    where TResonose: notnull
{
}
