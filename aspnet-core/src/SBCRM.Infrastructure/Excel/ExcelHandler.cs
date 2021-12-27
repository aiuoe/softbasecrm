using OfficeOpenXml;
using SBCRM.Infrastructure.Attribute;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SBCRM.Infrastructure.Excel
{
    public static class ExcelHandler
    {
        public static async Task<List<T>> ReadIntoList<T>(byte[] bin, int startFromRow = 1, bool allowEverySheet = true)
        {
            //create a list to hold all the values
            List<T> excelData = new List<T>();

            //read the Excel file as byte array
            //byte[] bin = await File.ReadAllBytesAsync(path);

            var properties = typeof(T).GetProperties();

            //create a new Excel package in a memorystream
            using (var stream = new MemoryStream(bin))
            using (var excelPackage = new ExcelPackage(stream))
            {
                //loop all worksheets
                foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                {
                    int counter = 1;
                    //loop all rows
                    for (int i = worksheet.Dimension.Start.Row; i <= worksheet.Dimension.End.Row; i++)
                    {
                        if (i >= startFromRow)
                        {
                            var instance = Activator.CreateInstance<T>();
                            foreach (PropertyInfo prop in properties)
                            {
                                var positionAttribute = prop.GetCustomAttributes(typeof(PositionExcelAttribute), true).FirstOrDefault();
                                if (positionAttribute != null)
                                {
                                    prop.SetValue(instance, worksheet.Cells[i, ((PositionExcelAttribute)positionAttribute).Column]?.Value?.ToString());
                                }

                                var counterAttribute = prop.GetCustomAttributes(typeof(CounterColumnAttribute), true).FirstOrDefault();
                                if (counterAttribute != null)
                                {
                                    prop.SetValue(instance, counter);
                                }
                            }
                            excelData.Add(instance);
                            counter++;
                        }
                    }

                    if (!allowEverySheet)
                    {
                        break;
                    }
                }
            }

            return excelData;
        }
    }
}
