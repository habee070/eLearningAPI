using eLearning.API.Extensions;
using eLearning.API.Middlewares;
using eLearning.Core;
using eLearning.Core.Mappers;
using eLearning.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//Allow cors
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("MultipleOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add Identity services
builder.Services.AddIdentityServices(builder.Configuration);

//Add controllers to the service collection
builder.Services.AddControllers();

//Add AutoMapper services
builder.Services.AddAutoMapper(typeof(UserMappingProfile).Assembly);

//Add Swagger service
builder.Services.AddSwaggerService();

//Build the web application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Add exception handling middleware
app.UseExceptionHandlingMinddleware();

//Routing
app.UseRouting();

//Use core
app.UseCors("MultipleOrigins");

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller routes
app.MapControllers();

app.Run();
