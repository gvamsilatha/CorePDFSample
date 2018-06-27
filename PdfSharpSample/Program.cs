using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Fonts;

namespace PdfSharpSample
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);

            //var font = new XFont("OpenSans", 20, XFontStyle.Bold);

            //gfx.DrawString("Hello World!", font, XBrushes.Black, new XRect(20, 20, page.Width, page.Height), XStringFormats.Center);

            //document.Save("test.pdf");

            //using (var memoryStream = new FileStream("test.pdf", FileMode.Open))
            //{

                var readerDco = PdfReader.Open("test.pdf", PdfDocumentOpenMode.Import);
                Console.WriteLine("Hello World!");
            //}


            Console.WriteLine("Hello World!");
        }


    }

    
}
