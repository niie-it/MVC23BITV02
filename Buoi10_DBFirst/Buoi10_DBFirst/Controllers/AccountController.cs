using Buoi10_DBFirst.Entities;
using Buoi10_DBFirst.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace Buoi10_DBFirst.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyeStoreContext _context;

        public AccountController(MyeStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model, string? ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                //check khách hàng
                var khachHang = _context.KhachHangs.FirstOrDefault(kh => kh.MaKh == model.Username && kh.MatKhau == model.Password);
                if (khachHang != null)
                {
                    //khai báo claims (đặc trưng người dùng)
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, khachHang.HoTen),
                        new Claim(ClaimTypes.NameIdentifier, khachHang.MaKh),
                        new Claim(ClaimTypes.Email, khachHang.Email),
                        new Claim(ClaimTypes.Role, khachHang.VaiTro.ToString())
                    };
                    var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                    ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    //login thành công
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    //login thất bại
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng");
                }
            }
            return View();
        }
    }
}
