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

        /// <summary>
        /// Gets correct UserName for login action
        /// </summary>
        /// <returns></returns>
        public string GetCorrectUserName()
        {
            
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["A2"].Text;
            }
        }


        /// <summary>
        /// Gets correct Password for login action
        /// </summary>
        /// <returns></returns>
        public string GetCorrectPassword()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["B2"].Text;
            }
        }


        /// <summary>
        /// Gets incorrect username for login action testing
        /// </summary>
        /// <returns></returns>
        public string GetIncorrectUserName()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["A3"].Text;
            }
        }

        /// <summary>
        /// Gets incorrect Password for login action testing
        /// </summary>
        /// <returns></returns>
        public string GetIncorrectPassword()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["B3"].Text;
            }
        }

        /// <summary>
        /// Gets highest price from products
        /// </summary>
        /// <returns></returns>
        public string GetHighestProductPrice()
        {
            using (var package = new ExcelPackage(new FileInfo(_filePath)))
            {
                var firstSheet = package.Workbook.Worksheets["TestData"];
                return firstSheet.Cells["C2"].Text;
            }
        }


        /// <summary>
        /// Gets lowest price from products
        /// </summary>
        /// <returns></returns>
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
