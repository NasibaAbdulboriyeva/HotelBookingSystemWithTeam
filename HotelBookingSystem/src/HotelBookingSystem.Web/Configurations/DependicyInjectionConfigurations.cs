using FluentValidation;
using HotelBookingSystem.Application;
using HotelBookingSystem.Application.Dtos.CardDtos;
using HotelBookingSystem.Application.Dtos.HotelDtos;
using HotelBookingSystem.Application.Dtos.PaymentDtos;
using HotelBookingSystem.Application.Dtos.UserDtos;
using HotelBookingSystem.Application.RepositoryInterfaces;
using HotelBookingSystem.Application.Services.AffairService;
using HotelBookingSystem.Application.Services.AuthService;
using HotelBookingSystem.Application.Services.CardServices;
using HotelBookingSystem.Application.Services.ComplaintService;
using HotelBookingSystem.Application.Services.ReviewService;
using HotelBookingSystem.Application.Services.TokenService;
using HotelBookingSystem.Application.Validators.CardValidator;
using HotelBookingSystem.Application.Validators.HotelValidator;
using HotelBookingSystem.Application.Validators.PaymentValidator;
using HotelBookingSystem.Application.Validators.UserValidator;
using HotelBookingSystem.Infrastructure;
using HotelBookingSystem.Infrastructure.Persistence.Repositories;

namespace HotelBookingSystem.Web.Configurations;

public static class DependicyInjectionConfigurations
{
    public static void ConfigureDI(this WebApplicationBuilder builder)
    {



        builder.Services.AddScoped<IValidator<CreateUserDto>, UserCreateValidator>();
        builder.Services.AddScoped<IValidator<UserLoginDto>, UserLoginValidator>();
        builder.Services.AddScoped<IValidator<CreateCardDto>, CardCreateValidator>();
        builder.Services.AddScoped<IValidator<CreatePaymentDto>, PaymentCreateValidator>();
        builder.Services.AddScoped<IValidator<CreateHotelDto>, HotelCreateValidator>();
        // builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        //builder.Services.AddScoped<IUserService, UserService>();

        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
        //builder.Services.AddScoped<IUserRoleService, UserRoleService>();

        builder.Services.AddScoped<IBookingRepository, BookingRepository>();

        builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();
        builder.Services.AddScoped<IComplaintService, ComplaintService>();



        builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
        builder.Services.AddScoped<IReviewService, ReviewService>();

        builder.Services.AddScoped<IHotelRepository, HotelRepository>();
        builder.Services.AddScoped<IRoomRepository, RoomRepository>();
        builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
        builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
        builder.Services.AddScoped<IRoleRepository, RoleRepository>();
        builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
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
