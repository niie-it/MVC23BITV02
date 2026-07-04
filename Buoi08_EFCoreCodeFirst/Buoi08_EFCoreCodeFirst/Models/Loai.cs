using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi08_EFCoreCodeFirst.Models
{
    public class Loai
    {
        [Key]
        public int MaLoai { get; set; }
        [MaxLength(50)]
        public string TenLoai { get; set; }

        [MaxLength(100)]
        public string? Hinh { get; set; }
        public string MoTa { get; set; }
    }

    public class HangHoa
    {
        [Key]
        public int MaHh { get; set; }
        [MaxLength(50)]
        public string TenHh { get; set; }
        public int? MaLoai { get; set; }
        public decimal DonGia { get; set; }

        [MaxLength(100)]
        public string? Hinh { get; set; }
        public string MoTa { get; set; }
        // Navigation property
        [ForeignKey(nameof(MaLoai))]
        public Loai? Loai { get; set; }
    }
}
