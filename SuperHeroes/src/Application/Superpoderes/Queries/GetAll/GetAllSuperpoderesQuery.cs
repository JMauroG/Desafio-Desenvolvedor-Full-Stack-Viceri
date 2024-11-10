using Application.Abstractions.Messaging;

namespace Application.Superpoderes.Queries.GetAll;

public record GetAllSuperpoderesQuery(
) : IQuery<List<GetAllSuperpoderesDto>>;
