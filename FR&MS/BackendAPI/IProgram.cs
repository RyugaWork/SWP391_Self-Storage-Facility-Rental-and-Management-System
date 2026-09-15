using BackendAPI.Utils.DataBase;

namespace BackendAPI; 
public interface IProgram {
    public void AddSevice();
    public void AddConfig();
    public void Run();
}

public class FRMS : IProgram {
    public WebApplicationBuilder builder;
    public WebApplication app;
    public IDbService db;

    public FRMS(WebApplicationBuilder builder, IDbService db) : base() {
        this.builder = builder;
        this.db = db;
    }

    public void AddSevice() {
        // Add services to the container.
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // Add SQL Server Connection
        builder.Services.AddDbContext<AppDbContext>(opt => db.Configure(opt));
    }

    public void AddConfig() {
        app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment()) {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    public void Run() {
        AddSevice();
        AddConfig();
    }
}
