using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Utils.DataBase;

public interface IDbService {
    public void SetProfile(IDbPofile profile);
    void Configure(DbContextOptionsBuilder options);

}
