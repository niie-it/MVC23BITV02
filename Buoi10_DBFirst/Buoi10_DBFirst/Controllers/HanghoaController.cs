using Buoi10_DBFirst.Entities;
using Buoi10_DBFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi10_DBFirst.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly MyeStoreContext _context;

        public HangHoaController(MyeStoreContext context)
        {
            _context = context;
        }


        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Search(string? Keyword, double? FromPrice, double? ToPrice)
        {
            var dsHangHoa = _context.HangHoas.AsQueryable();
            if (!string.IsNullOrEmpty(Keyword))
            {
                dsHangHoa = dsHangHoa.Where(h => h.TenHh.Contains(Keyword));
            }
            if (FromPrice.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(h => h.DonGia >= FromPrice.Value);
            }
            if (ToPrice.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(h => h.DonGia <= ToPrice.Value);
            }
            var data = dsHangHoa.Select(h => new HangHoaVM
            {
                MaHh = h.MaHh,
                TenHh = h.TenHh,
                Hinh = h.Hinh ?? "no-image.png",
                DonGia = h.DonGia ?? 0,
                TenLoai = h.MaLoaiNavigation.TenLoai,
                NhaCungCap = h.MaNccNavigation.TenCongTy
            }).ToList();
            return View(data);
        }
    }
}
