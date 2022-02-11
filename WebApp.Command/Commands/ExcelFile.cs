using ClosedXML.Excel;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace WebApp.Command.Commands
{
    public class ExcelFile<T>
    {
        public readonly List<T> _list;

        public string FileName => $"{typeof(T).Name}.xlsx";

        public string FileType => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        public ExcelFile(List<T> list)
        {
            _list = list;
        }

        public MemoryStream Create()
        {
            var workBook = new XLWorkbook();

            var dataSet = new DataSet();

            dataSet.Tables.Add(GetTable());

            workBook.Worksheets.Add(dataSet);

            var excelMemory = new MemoryStream();

            workBook.SaveAs(excelMemory);
            return excelMemory;
        }

        private DataTable GetTable()
        {
            var table = new DataTable();

            var type = typeof(T);

            type.GetProperties().ToList().ForEach(x => table.Columns.Add(x.Name, x.PropertyType));

            _list.ForEach(x =>
            {
                var values = type.GetProperties().Select(properyInfo => properyInfo.GetValue(x, null)).ToArray();

                table.Rows.Add(values);
            });
            return table;
        }
    }
}