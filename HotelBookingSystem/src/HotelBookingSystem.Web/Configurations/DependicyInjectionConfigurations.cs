using FluentValidation;
using HotelBookingSystem.Application;
using HotelBookingSystem.Application.Dtos.BookingDtos;
using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Dtos.CityDto;
using HotelBookingSystem.Application.Dtos.ComplaintDtos;
using HotelBookingSystem.Application.Dtos.CountryDto;
using HotelBookingSystem.Application.Dtos.HotelDtos;
using HotelBookingSystem.Application.Dtos.PaymentDtos;
using HotelBookingSystem.Application.Dtos.ReviewDtos;
using HotelBookingSystem.Application.Dtos.RoomDtos;
using HotelBookingSystem.Application.Dtos.RoomPhotoDto;
using HotelBookingSystem.Application.Dtos.RoomTypeDto;
using HotelBookingSystem.Application.Dtos.ServiceDtos;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.AffairService;
using HotelBookingSystem.Application.Services.AuthService;
using HotelBookingSystem.Application.Services.BookingService;
using HotelBookingSystem.Application.Services.CardServices;
using HotelBookingSystem.Application.Services.CityService;
using HotelBookingSystem.Application.Services.ComplaintService;
using HotelBookingSystem.Application.Services.CountryService;
using HotelBookingSystem.Application.Services.CountryServices;
using HotelBookingSystem.Application.Services.HotelService;
using HotelBookingSystem.Application.Services.Implementations;
using HotelBookingSystem.Application.Services.ReviewService;
using HotelBookingSystem.Application.Services.RoomPhotoService;
using HotelBookingSystem.Application.Services.RoomTypeService;
using HotelBookingSystem.Application.Services.RoomTypeServices;
using HotelBookingSystem.Application.Services.TokenService;
using HotelBookingSystem.Application.Services.UserServices;
using HotelBookingSystem.Application.Validators.BookingValidator;
using HotelBookingSystem.Application.Validators.CardValidator;
using HotelBookingSystem.Application.Validators.CityValidator;
using HotelBookingSystem.Application.Validators.ComplaintValidator;
using HotelBookingSystem.Application.Validators.CountryValidator;
using HotelBookingSystem.Application.Validators.HotelValidator;
using HotelBookingSystem.Application.Validators.PaymentValidator;
using HotelBookingSystem.Application.Validators.ReviewValidator;
using HotelBookingSystem.Application.Validators.RoomPhotoValidator;
using HotelBookingSystem.Application.Validators.RoomTypeValidator;
using HotelBookingSystem.Application.Validators.RoomValidator;
using HotelBookingSystem.Application.Validators.ServiceValidator;
using HotelBookingSystem.Application.Validators.UserValidator;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Infrastructure.Persistence.Repositories;
using HotelBookingSystem.Infrastructure.Services.RoomPhotoServices;

namespace HotelBookingSystem.Web.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {

        builder.Services.AddScoped<IValidator<CreateUserDto>, UserCreateValidator>();
        builder.Services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator>();
        builder.Services.AddScoped<IValidator<CreateCardDto>, CardCreateValidator>();
        builder.Services.AddScoped<IValidator<CreatePaymentDto>, PaymentCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateBookingDto>, BookingCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateCityDto>, CityCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateComplaintDto>, ComplaintCreateValidator>();
        builder.Services.AddScoped<IValidator<CountryCreateDto>, CountryCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateReviewDto>, ReviewCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateRoomDto>, RoomCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateRoomPhotoDto>, RoomPhotoCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateRoomTypeDto>, RoomTypeCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateServiceDto>, ServiceCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateHotelDto>, HotelCreateValidator>();
    
        // builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();

        //builder.Services.AddScoped<IUserRoleService, UserRoleService>();

        builder.Services.AddScoped<IBookingRepository, BookingRepository>();
        builder.Services.AddScoped<IBookingService, BookingService>();

        builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();
        builder.Services.AddScoped<IComplaintService, ComplaintService>();


        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IReviewService, ReviewService>();

        builder.Services.AddScoped<IHotelRepository, HotelRepository>();
        builder.Services.AddScoped<IHotelService, HotelService>();

        builder.Services.AddScoped<ICountryRepository, CountryRepository>();
        builder.Services.AddScoped<ICountryService, CountryService>();

        builder.Services.AddScoped<ICityRepository, CityRepository>();
        builder.Services.AddScoped<ICityService, CityService>();

        builder.Services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
        builder.Services.AddScoped<IRoomTypeService, RoomTypeService>();

        builder.Services.AddScoped<IRoomPhotoRepository, RoomPhotoRepository>();
        builder.Services.AddScoped<IRoomPhotoService, RoomPhotoService>();

        builder.Services.AddScoped<IRoomRepository, RoomRepository>();
        builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
        builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
        builder.Services.AddScoped<ICardRepository, CardRepository>();
        builder.Services.AddScoped<ICardService, CardService>();

        // builder.Services.AddScoped<IAuthService, AuthService>();

        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IAffairService, AffairService>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    }
}
