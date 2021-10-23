using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SeleniumTaskTwo
{
    class TestDataRepository
    {
        string _filePath = Path.Combine(Environment.CurrentDirectory, "testData.xlsx");
        public TestDataRepository()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public string GetCorrectUserName()
        {
            
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["A2"].Text;
            }
        }

        public string GetCorrectPassword()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["B2"].Text;
            }
        }

        public string GetIncorrectUserName()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["A3"].Text;
            }
        }

        public string GetIncorrectPassword()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["B3"].Text;
            }
        }

        public string GetHighestProductPrice()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["C2"].Text;
            }
        }

        public string GetLowestProductPrice()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["D2"].Text;
            }
        }

    }
}
