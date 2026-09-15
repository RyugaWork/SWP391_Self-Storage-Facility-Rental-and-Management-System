using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace BackendAPI.Models {
    public class Ctest {
        public string String { get; set; }
        [Key]
        public int Int { get; set; }
        public DateTime Date { get; set; }
    }
}
