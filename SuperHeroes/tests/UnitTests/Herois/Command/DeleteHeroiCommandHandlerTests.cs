using Application.Herois.Command.Delete;
using Application.Herois.Command.Update;
using Domain.HeroisAggregated;
using Domain.HeroisAggregated.Errors;
using FluentAssertions;
using Moq;
using SharedKernel;

namespace UnitTests.Herois.Command;

public class DeleteHeroiCommandHandlerTests
{
    private readonly DeleteHeroiCommandHandler _handler;
    private readonly Mock<IHeroisRepository> _mockHeroiRepository;
    
    private static readonly CancellationToken CancellationToken = It.IsAny<CancellationToken>();

    public DeleteHeroiCommandHandlerTests()
    {
        _mockHeroiRepository = new Mock<IHeroisRepository>();
        _handler = new(_mockHeroiRepository.Object);
    }

    [Fact]
    public async Task Handle_HeroiNotFound()
    {
        //Arrange
        int heroiId = 1;
        _mockHeroiRepository.Setup(rep => rep.GetHeroiByIdAsync(heroiId, CancellationToken))!.ReturnsAsync((Heroi)null);
        
        DeleteHeroiCommand command = new(heroiId);
        
        //Act
        Result<string> result = await _handler.Handle(command, CancellationToken);
        
        //Assert
        result.Should().NotBeNull();
        result.Error.Should().NotBeNull();
        result.Error.Should().Be(HeroiErrors.NotFound);
    }

    [Fact]
    public async Task Handle_Success()
    {
        //Arrange
        int heroiId = 1;
        Heroi heroi = new("heroiTest", "heroiTest", DateTime.Now, 2, 30, [], heroiId );
        _mockHeroiRepository.Setup(rep => rep.GetHeroiByIdAsync(heroiId, CancellationToken)).ReturnsAsync(heroi);
        DeleteHeroiCommand command = new(heroiId);
        
        //Act
        Result<string> result = await _handler.Handle(command, CancellationToken);
        
        //Assert
        result.Should().NotBeNull();
        result.Value.Should().Be("Herói deletado");
    }
}
