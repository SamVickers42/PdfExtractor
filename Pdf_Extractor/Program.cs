using System;
using System.IO;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Filters;
using System.Data;
using System.Text;

namespace Pdf_Extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string inputFile = @args[0];
            string PdfFilePath = string.Empty;
            int StartPage;
            int PageCount;
            string subPdfName;
            PdfDocument PDFDoc = null;

            foreach (string line in File.ReadLines(inputFile, Encoding.UTF8))
            {
                //0 : pdfFilePath
                //1 : StartPage
                //2 : PageCount
                //3 : subPdfName
                string[] fields = line.Split('|');


                if (PdfFilePath != fields[0])
                {
                    PdfFilePath = fields[0];
                    PDFDoc = PdfReader.Open(PdfFilePath, PdfDocumentOpenMode.Import);
                }

                StartPage = Int32.Parse(fields[1]);
                PageCount = Int32.Parse(fields[2]);
                subPdfName = fields[3];

                Console.WriteLine("pdffilepath: " + PdfFilePath);
                Console.WriteLine("StartPage: " + StartPage);
                Console.WriteLine("PageCount: " + PageCount);
                Console.WriteLine("SubPdf Name: " + subPdfName);

                //Sub-pdf
                PdfDocument PDFNewDoc = new PdfDocument();

                for (int i = StartPage; i <= StartPage + PageCount - 1; i++)
                {
                    PdfPage pp = PDFNewDoc.AddPage(PDFDoc.Pages[i - 1]);
                }

                PDFNewDoc.Save(subPdfName);

            }
        }
    }
}
