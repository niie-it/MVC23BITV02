using Buoi04.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Buoi04.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult SyncDemo()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Demo.A();
            Demo.B();
            Demo.C();
            sw.Stop();
            return Content($"Elapsed time: {sw.ElapsedMilliseconds} ms");
        }

        public async Task<IActionResult> AsyncDemo()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            var a = Demo.AA();
            var b = Demo.BB();
            var c = Demo.CC();
            await a;
            await b;
            await c;
            //Task.WaitAll(a, b, c);
            sw.Stop();
            return Content($"Elapsed time: {sw.ElapsedMilliseconds} ms");
        }
    }
}
