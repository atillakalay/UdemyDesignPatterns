using System.Drawing;
using System.IO;

namespace WebApp.Adapter.Services
{
    public class AdvanceImageProcessAdapter : IImageProcess
    {
        private readonly IAdvanceImageProcess _advanceImageProcess;

        public AdvanceImageProcessAdapter(IAdvanceImageProcess advanceImageProcess)
        {
            _advanceImageProcess = advanceImageProcess;
        }

        public void AddWaterMark(string text, string fileName, Stream imageStream)
        {
            _advanceImageProcess.AddWatermarkImage(imageStream, text, $"wwwroot/watermarks/{fileName}", Color.FromArgb(128, 255, 255, 255), Color.FromArgb(0, 255, 255, 255));
        }
    }
}
