namespace Buoi12_ThiThu.Models
{
    public class MyTool
    {
        public static async Task<string> SaveFile(IFormFile file, string folderPath)
        {
            try
            {
                // Generate a unique file name for the uploaded image
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", folderPath, fileName);
                // Save the uploaded image to the server
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName;
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
