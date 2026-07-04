namespace Buoi08_EFCoreCodeFirst.Models
{
    public class MyTool
    {
        public static async Task<string> UploadFileToFolder(IFormFile file, string folderName)
        {
            try
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hinh", folderName, fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return fileName;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }
    }
}
