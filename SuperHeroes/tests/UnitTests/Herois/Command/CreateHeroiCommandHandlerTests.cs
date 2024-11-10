using Application.Herois.Command.Create;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using FluentAssertions;
using Moq;
using SharedKernel;

namespace UnitTests.Herois.Command;

public class CreateHeroiCommandHandlerTests
{
    private readonly CreateHeroiCommandHandler _handler;
    private readonly Mock<IHeroisRepository> _mockHeroiRepository;
    private readonly Mock<ISuperpoderRepository> _mockSuperpoderRepository;

    private static readonly CancellationToken CancellationToken = It.IsAny<CancellationToken>();

    public CreateHeroiCommandHandlerTests()
    {
        _mockHeroiRepository = new Mock<IHeroisRepository>();
        _mockSuperpoderRepository = new Mock<ISuperpoderRepository>();

        _handler = new CreateHeroiCommandHandler(_mockHeroiRepository.Object, _mockSuperpoderRepository.Object);
    }


    [Fact]
    public async Task Handle_NomeHeroiAlreadyExists()
    {
        //Arrange
        _mockHeroiRepository.Setup(rep => rep.CheckIfHeroiNomeExists("Exist")).ReturnsAsync(true);

        CreateHeroiCommand command = new CreateHeroiCommand(
            "Exist",
            "Exist",
            DateTime.Now,
            1,
            40,
            [1, 2]
        );

        //Act
        Result<CreateHeroiDto> result = await _handler.Handle(command, CancellationToken);

        //Assert
        result.Should().NotBeNull();
        result.Error.Should().NotBeNull();
        result.Error.Should().Be(HeroiErrors.NomeHeroiAlreadyExists);
    }

    [Fact]
    public async Task Handle_Sucess()
    {
        //Arrange
        CreateHeroiCommand command = new CreateHeroiCommand(
            "Exist",
            "Exist",
            DateTime.Now,
            1,
            40,
            [1]
        );
        
        List<Superpoder> superpoderes = new List<Superpoder>(
            [
                new Superpoder(1, "", "Forte")
            ]
        );

        Heroi heroi = new Heroi(
            "Exist",
            "Exist",
            DateTime.Now,
            1,
            40,
            superpoderes
        );

        

        _mockHeroiRepository.Setup(rep => rep.GetHeroiByHeroiNomeReadOnlyAsync("Exist")).ReturnsAsync(heroi);
        _mockSuperpoderRepository.Setup(rep => rep.GetAllSuperpoderes()).ReturnsAsync(superpoderes);

        //Act
        Result<CreateHeroiDto> result = await _handler.Handle(command, CancellationToken);

        //Assert
        result.Should().NotBeNull();
        CreateHeroiDto heroiDto =result.Value;
        heroiDto.Nome.Should().Be(heroi.Nome);
        heroiDto.NomeHeroi.Should().Be(heroi.NomeHeroi);
        heroiDto.Altura.Should().Be(heroi.Altura);
        heroiDto.Peso.Should().Be(heroi.Peso);
        heroiDto.DataNascimento.Should().Be(heroi.DataNascimento);
        heroiDto.Superpoderes.Should().BeEquivalentTo(superpoderes);
    }
}
