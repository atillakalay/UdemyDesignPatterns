using Microsoft.AspNetCore.Mvc;

namespace WebApp.Command.Commands
{
    public class CreateExcelTableActionCommand<T> : ITableActionCommand
    {
        private readonly ExcelFile<T> _excelFile;

        public CreateExcelTableActionCommand(ExcelFile<T> excelFile)
        {
            _excelFile = excelFile;
        }


        public IActionResult Execute()
        {
            var excelMemoryStream = _excelFile.Create();
            return new FileContentResult(excelMemoryStream.ToArray(), _excelFile.FileType) { FileDownloadName = _excelFile.FileName };
        }
    }
}
