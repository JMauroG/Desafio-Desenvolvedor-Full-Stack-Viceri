using System.Runtime.InteropServices.JavaScript;
using Application.Herois.Command.Update;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using FluentAssertions;
using Moq;
using SharedKernel;

namespace UnitTests.Herois.Command;

public class UpdateHeroiCommandHandlerTests
{
    private readonly UpdateHeroiCommandHandler _handler;
    private readonly Mock<IHeroisRepository> _mockHeroiRepository;
    private readonly Mock<ISuperpoderRepository> _mockSuperpoderRepository;

    private static readonly CancellationToken CancellationToken = It.IsAny<CancellationToken>();

    public UpdateHeroiCommandHandlerTests()
    {
        _mockHeroiRepository = new Mock<IHeroisRepository>();
        _mockSuperpoderRepository = new Mock<ISuperpoderRepository>();
        _handler = new(_mockHeroiRepository.Object, _mockSuperpoderRepository.Object);
    }

    [Fact]
    public async Task Handle_HeroiNotFound()
    {
        //Arrange
        UpdateHeroiCommand command = new(1, "heroiTest", "heroiTest", DateTime.Now, 2, 30, []);
        _mockHeroiRepository.Setup(rep => rep.GetHeroiByIdAsync(command.Id!.Value, CancellationToken))!
            .ReturnsAsync((Heroi)null);

        //Act
        Result<UpdateHeroiDto> result = await _handler.Handle(command, CancellationToken);

        //Assert
        result.Error.Should().Be(HeroiErrors.NotFound);
    }

    [Fact]
    public async Task Handle_NomeHeroiAlreadyExists()
    {
        //Arrange
        UpdateHeroiCommand command = new(1, "heroiTest", "heroiTest", DateTime.Now, 2, 30, []);
        Heroi heroitToUpdate = new("heroiTest", "heroiTest", DateTime.Now, 2, 30, [], 1);

        _mockHeroiRepository.Setup(rep => rep.GetHeroiByIdAsync(command.Id!.Value, CancellationToken))!.ReturnsAsync(
            heroitToUpdate);
        _mockHeroiRepository
            .Setup(rep =>
                rep.CheckIfHeroiNomeExistsWithIdAsync(command.NomeHeroi!, command.Id!.Value, CancellationToken))
            .ReturnsAsync(true);

        //Act
        Result<UpdateHeroiDto> result = await _handler.Handle(command, CancellationToken);

        //Assert
        result.Error.Should().Be(HeroiErrors.NomeHeroiAlreadyExists);
    }

    [Fact]
    public async Task Handle_Success()
    {
        //Arrange
        List<Superpoder> superpoders = new(
        [
            new Superpoder(1, "loucura", "mente"),
            new Superpoder(2, "", "forte")
        ]);
        UpdateHeroiCommand command = new(1, "heroiTest", "heroiTest", DateTime.Now, 2, 30,
            [2]);
        Heroi heroitToUpdate = new("heroiTest", "heroiTest", DateTime.Now, 2, 30, superpoders, 1);


        _mockHeroiRepository.Setup(rep => rep.GetHeroiByIdAsync(command.Id!.Value, CancellationToken))!.ReturnsAsync(
            heroitToUpdate);
        _mockHeroiRepository
            .Setup(rep =>
                rep.CheckIfHeroiNomeExistsWithIdAsync(command.NomeHeroi!, command.Id!.Value, CancellationToken))
            .ReturnsAsync(false);
        _mockSuperpoderRepository.Setup(rep => rep.GetSuperpoderesListFromIdListAsync(command.SuperPoderesIds, CancellationToken)).ReturnsAsync(superpoders);
        _mockHeroiRepository.Setup(rep => rep.SaveChangesAsync(CancellationToken)).ReturnsAsync(1);

        //Act
        Result<UpdateHeroiDto> result = await _handler.Handle(command, CancellationToken);

        //Assert
        result.Value.NomeHeroi.Should().Be(command.NomeHeroi);
        result.Value.Nome.Should().Be(command.Nome);
        result.Value.DataNascimento.Date.Should().Be(command.DataNascimento.Date);
        result.Value.Altura.Should().Be(command.Altura);
        result.Value.Peso.Should().Be(command.Peso);
        result.Value.Id.Should().Be(command.Id);
        result.Value.Superpoderes.Should().BeEquivalentTo(superpoders);
    }
}
