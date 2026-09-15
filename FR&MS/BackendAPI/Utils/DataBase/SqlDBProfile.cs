namespace BackendAPI.Utils.DataBase; 
public class SqlDBProfile: IDbPofile {
    public string host { get; set; } = "localhost";
    public string name { get; set; } = "demoFRMS";
    public string user { get; set; } = "sa";
    public string password { get; set; } = "12345";
   
    public SqlDBProfile() { }

    public SqlDBProfile(string host, string name, string user, string password) {
        this.host = host;
        this.name = name;
        this.user = user;
        this.password = password;
    }

    public string GetConnectionString() {
        return $"Data Source={host};" +
               $"Initial Catalog={name};" +
               $"User ID={user};" +
               $"Password={password};" +
               $"TrustServerCertificate=True;";
    }
}
