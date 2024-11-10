using Application.Abstractions.Messaging;

namespace Application.Herois.Queries.GetById;

public record GetHeroiByIdQuery(
    int Id
    ): IQuery<GetHeroiByIdDto>;
