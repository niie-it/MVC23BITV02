using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Buoi08_EFCoreCodeFirst.Models
{
    [Table("KhachHang")]
    public class KhachHang
    {
        [Key]
        public string MaKh { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string Email { get; set; }
    }

    [Table("Order")]
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }
        public DateTime NgayDatHang { get; set; }
        public string DiaChiGiaoHang { get; set; }
        public string? MaKh { get; set; }
        [ForeignKey("MaKh")]
        public KhachHang? KhachHang { get; set; }

    }

    public class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int MaHh { get; set; }
        public int MaHD { get; set; }

        [ForeignKey("MaHh")]
        public HangHoa HangHoa { get; set; }
        [ForeignKey("MaHD")]
        public HoaDon HoaDon { get; set; }
    }
}
