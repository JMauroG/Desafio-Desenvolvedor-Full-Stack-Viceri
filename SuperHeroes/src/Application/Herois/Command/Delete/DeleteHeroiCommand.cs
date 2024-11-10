using Application.Abstractions.Messaging;

namespace Application.Herois.Command.Delete;

public record DeleteHeroiCommand(
    int heroidId
): ICommand<string>;
