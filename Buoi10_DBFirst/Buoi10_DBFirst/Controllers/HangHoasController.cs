using Buoi10_DBFirst.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Buoi10_DBFirst.Controllers
{
    public class HangHoasController : Controller
    {
        private readonly MyeStoreContext _context;

        public HangHoasController(MyeStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dsHangHoa = _context.HangHoas
                .Select(h => new Models.HangHoaVM
                {
                    MaHh = h.MaHh,
                    TenHh = h.TenHh,
                    Hinh = h.Hinh,
                    DonGia = h.DonGia ?? 0,
                    TenLoai = h.MaLoaiNavigation.TenLoai,
                    NhaCungCap = h.MaNccNavigation.TenCongTy
                }) .ToList();
            return View(dsHangHoa);
        }
    }
}
