using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using SharedKernel;

namespace Application.Herois.Command.Delete;

public class DeleteHeroiCommandHandler(IHeroisRepository heroisRepository): ICommandHandler<DeleteHeroiCommand, string>
{
    public async Task<Result<String>> Handle(DeleteHeroiCommand command, CancellationToken cancellationToken)
    {
        Heroi heroi = await heroisRepository.GetHeroiByIdAsync(command.heroidId,cancellationToken);
        if (heroi == null)
        {
            return Result.Failure<String>(HeroiErrors.NotFound);
        }

        heroisRepository.Delete(heroi);
        
        await heroisRepository.SaveChangesAsync(cancellationToken);

        return Result.Success<string>("Herói deletado");
    }
}
