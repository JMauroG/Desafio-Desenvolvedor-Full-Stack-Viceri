using Application.Abstractions.Messaging;

namespace Application.Herois.Queries.GetAll;

public record GetAllHeroisQuery(
    ):IQuery<List<GetAllHeroisDto>>;
