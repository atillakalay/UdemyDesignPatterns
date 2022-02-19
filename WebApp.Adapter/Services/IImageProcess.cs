using System.IO;

namespace WebApp.Adapter.Services
{
    public interface IImageProcess
    {
        void AddWaterMark(string text,string fileName,Stream imageStream);
    }
}
