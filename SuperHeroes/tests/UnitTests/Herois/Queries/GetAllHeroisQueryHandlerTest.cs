using Application.Herois.Queries.GetAll;
using Application.Herois.Queries.GetById;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using FluentAssertions;
using Moq;
using SharedKernel;

namespace UnitTests.Herois.Queries;

public class GetAllHeroisQueryHandlerTest
{
    private readonly GetAllHeroisQueryHandler _handler;
    private readonly Mock<IHeroisRepository> _mockHeroisRepository;

    private static readonly CancellationToken CancellationToken = It.IsAny<CancellationToken>();

    public GetAllHeroisQueryHandlerTest()
    {
        _mockHeroisRepository = new Mock<IHeroisRepository>();
        _handler = new GetAllHeroisQueryHandler(_mockHeroisRepository.Object);
    }

    [Fact]
    public async Task Handle_TableEmpty()
    {
        //Arrange
        _mockHeroisRepository.Setup(rep => rep.GetAllHeroisReadOnlyAsync()).ReturnsAsync([]);
        GetAllHeroisQuery query = new GetAllHeroisQuery();

        //Act
        Result<List<GetAllHeroisDto>> result = await _handler.Handle(query, CancellationToken);

        //Assert
        result.Error.Should().Be(HeroiErrors.TableEmpty);
    }

    [Fact]
    public async Task Handle_Success()
    {
        //Assert
        List<Superpoder> superpoderes = new List<Superpoder>([
            new Superpoder(1, "", "Velocidade"),
            new Superpoder(2, "", "Força")
        ]);

        List<Heroi> herois = new List<Heroi>([
            new("test", "test", DateTime.Now, 2, 40, superpoderes, 1),
            new("test1", "test1", DateTime.Now, 1f, 21, superpoderes, 2),
            new("test2", "test2", DateTime.Now, 1.32f, 33, superpoderes, 3),
        ]);
        
        _mockHeroisRepository.Setup(rep => rep.GetAllHeroisReadOnlyAsync()).ReturnsAsync(herois);
        GetAllHeroisQuery query = new GetAllHeroisQuery();
        
        //Act
        Result<List<GetAllHeroisDto>> result = await _handler.Handle(query, CancellationToken);
        
        //Assert
        result.Value.Should().BeEquivalentTo(herois);
    }
}
