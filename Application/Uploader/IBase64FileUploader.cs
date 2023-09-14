using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Uploader
{
    public enum UploadType
    {
        ProfileImage,
        Post
    }
    public interface IBase64FileUploader
    {
        bool IsExtensionValid(string base64File);
        string GetExtension(string base64File, UploadType type);
        string Upload(string base64File);
        IEnumerable<string> Upload(IEnumerable<string> base64Files, UploadType type);
    }
}
