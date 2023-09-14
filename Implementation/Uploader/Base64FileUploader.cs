using Application.Uploader;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Uploader
{
    public class Base64FileUploader : IBase64FileUploader
    {
        private List<string> _allowedExtensions = new List<string>
        {
            "jpg", "png", "mp4"
        };
        public string GetExtension(string base64File)
        {
            throw new NotImplementedException();
        }

        public bool IsExtensionValid(string base64File)
        {
            throw new NotImplementedException();
        }

        
        private string GetPath(UploadType type, string ext)
        {
            var path = "Image/";

            var fileName = Guid.NewGuid().ToString() + "." + ext;

            

            return Path.Combine(path,fileName);
        }

        public IEnumerable<string> Upload(IEnumerable<string> base64Files, UploadType type)
        {
            throw new NotImplementedException();
        }

        public string GetExtension(string base64File, UploadType type)
        {
            throw new NotImplementedException();
        }

        public string Upload(string base64File)
        {
            var extension = base64File.GetFileExtension();

            if (!_allowedExtensions.Contains(extension))
            {
                throw new InvalidOperationException("Unspported file extension.");
            }

            var path = GetPath(UploadType.Post,extension);

            System.IO.File.WriteAllBytes(path, Convert.FromBase64String(base64File));

            return path;
        }
    }
}
