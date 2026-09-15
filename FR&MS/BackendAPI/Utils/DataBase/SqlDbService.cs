using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Utils.DataBase;
public class SqlDbService : IDbService {
    private IDbPofile? _profile;

    public void Configure(DbContextOptionsBuilder options) {
        if (_profile == null) {
            throw new InvalidOperationException(
                "Database profile has not been configured."
            );
        }

        options.UseSqlServer(
            _profile.GetConnectionString()
        );
    }

    public void SetProfile(IDbPofile profile) {
        _profile = profile;
    }
}
