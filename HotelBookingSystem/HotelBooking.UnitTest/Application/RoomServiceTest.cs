using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using HotelBookingSystem.Application.Dtos.RoomDtos;
using HotelBookingSystem.Application.Mappings;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.RoomServices;
using HotelBookingSystem.Domain.Entities;
using Moq;

namespace HotelBooking.UnitTest.Application;
public class RoomServiceTest
{
    private readonly RoomService _roomService;
    private readonly Mock<IRoomRepository> _roomRepository;
    private readonly Mock<IValidator<CreateRoomDto>> _createRoomDtoValidator;
    private readonly IMapper _mapper;

    public RoomServiceTest()
    {
        _roomRepository = new Mock<IRoomRepository>();
        _createRoomDtoValidator = new Mock<IValidator<CreateRoomDto>>();

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<RoomMapper>();
        });
        _mapper = config.CreateMapper();

        _roomService = new RoomService(
            _roomRepository.Object,
            _mapper,
         _createRoomDtoValidator.Object
        );
    }

    [Fact]
    public async Task CreateRoomAsync_ShouldReturnRoomId_WhenRoomIsCreatedSuccessfully()
    {
        // Arrange
        var roomDto = new CreateRoomDto
        {
            RoomNumber = 101,
            Price = 150.00m,
            RoomType = "Standard"
        };

        _createRoomDtoValidator
            .Setup(v => v.ValidateAsync(roomDto, default))
            .ReturnsAsync(new ValidationResult());

        _roomRepository
            .Setup(r => r.InsertAsync(It.IsAny<Room>()))
            .ReturnsAsync(1L);

        // Act
        var result = await _roomService.CreateRoomAsync(roomDto);

        // Assert
        Assert.Equal(1L, result);
    }

    [Fact]
    public async Task GetAllRoomsAsync__ShouldReturnAllRooms_WhenCalled()
    {
        // Arrange
        var rooms = new List<Room>
        {
            new Room { RoomId = 1, RoomNumber = 101, Price = 150.00m, RoomType = "Standard" },
            new Room { RoomId = 2, RoomNumber = 102, Price = 200.00m, RoomType = "Deluxe" }
        };
        _roomRepository
            .Setup(r => r.SelectAllAsync())
            .ReturnsAsync(rooms);
        // Act
        var result = await _roomService.GetAllRoomsAsync();
        // Assert
        Assert.Equal(2, result.Count());
    }

}
