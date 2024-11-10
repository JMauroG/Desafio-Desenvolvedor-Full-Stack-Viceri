using Application.Herois.Queries.GetById;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using FluentAssertions;
using Moq;
using SharedKernel;

namespace UnitTests.Herois.Queries;

public class GetHeroiByIdQueryHandlerTest
{
    private readonly GetHeroiByIdQueryHandler _handler;
    private readonly Mock<IHeroisRepository> _mockHeroisRepository;

    private static readonly CancellationToken CancellationToken = It.IsAny<CancellationToken>();

    public GetHeroiByIdQueryHandlerTest()
    {
        _mockHeroisRepository = new Mock<IHeroisRepository>();
        _handler = new(_mockHeroisRepository.Object);
    }

    [Fact]
    public async Task Handle_HeroiNotFound()
    {
        //Arrange
        int heroiId = 1;
        _mockHeroisRepository.Setup(rep => rep.GetHeroiByIdReadOnlyAsync(heroiId))!.ReturnsAsync((Heroi)null);
        GetHeroiByIdQuery query = new(heroiId);

        //Act
        Result<GetHeroiByIdDto> result = await _handler.Handle(query, CancellationToken);

        //Assert
        result.Error.Should().Be(HeroiErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Success()
    {
        //Arrange
        int heroiId = 1;
        List<Superpoder> superpoderes = new List<Superpoder>([
                new Superpoder(1, "", "Velocidade"),
                new Superpoder(2, "", "Força")
            ]
        );
        Heroi heroi = new("test", "test", DateTime.Now, 2, 40, superpoderes, heroiId);
        _mockHeroisRepository.Setup(rep => rep.GetHeroiByIdReadOnlyAsync(heroiId)).ReturnsAsync(heroi);
        GetHeroiByIdQuery query = new(heroiId);

        //Act
        Result<GetHeroiByIdDto> result = await _handler.Handle(query, CancellationToken);

        //Assert
        result.Value.Nome.Should().Be(heroi.Nome);
        result.Value.NomeHeroi.Should().Be(heroi.NomeHeroi);
        result.Value.Id.Should().Be(heroiId);
        result.Value.DataNascimento.Should().Be(heroi.DataNascimento);
        result.Value.Altura.Should().Be(heroi.Altura);
        result.Value.Peso.Should().Be(heroi.Peso);
        result.Value.Superpoderes.Should().BeEquivalentTo(heroi.Superpoderes);
    }
}
