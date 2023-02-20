namespace Clocker.Helpers
{
    public class Uploader
    {
        public static IWebHostEnvironment? Environment { get; set; }
        //public string Upload()
        //{
        //    string wwwPath = Environment.WebRootPath;
        //    string contentPath = Environment.ContentRootPath;

        //    string path = Path.Combine(Environment.WebRootPath, "Uploads");
        //    if (!Directory.Exists(path))
        //    {
        //        Directory.CreateDirectory(path);
        //    }

        //    List<string> uploadedFiles = new List<string>();
        //    foreach (IFormFile postedFile in postedFiles)
        //    {
        //        string fileName = Path.GetFileName(postedFile.FileName);
        //        using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
        //        {
        //            postedFile.CopyTo(stream);
        //            uploadedFiles.Add(fileName);
        //            ViewBag.Message += string.Format("<b>{0}</b> uploaded.<br />", fileName);
        //        }
        //    }
        //}
    }
}
