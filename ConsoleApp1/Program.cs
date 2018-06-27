using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PdfSharpCore.Pdf;
using PdfSharpCore.Pdf.IO;
using PdfSharpCore.Drawing; 
using PdfSharpCore.Fonts; 
using System.Text;
using PdfSharpCore.Drawing.BarCodes;
using PdfSharpCore.Pdf.AcroForms;
using PdfSharpCore.Pdf.Advanced;
using PdfSharpCore.Pdf.Content;
using PdfSharpCore.Pdf.Content.Objects;
using MigraDocCore.DocumentObjectModel;
using MigraDocCore.DocumentObjectModel.Shapes;
using MigraDocCore.DocumentObjectModel.Tables;
using MigraDocCore.Rendering;
using PdfSharpCore.Drawing.Layout;


namespace PdfSharpCoreSample
{
    public class Program
    {
        static void Main(string[] args)
        {
            GlobalFontSettings.FontResolver = new FontResolver();
            //DrawGraphics();
            //DrawBox();
            //ReadPdfContents();
            //CreateBarcode();
            //CreateBarcodeAsText();
            verticalBarCode();
            Console.WriteLine("Hello World!");
        }

        public static void verticalBarCode()
        {
            string reportFilename = "verticalBarCode.pdf";
            Document document = new Document();
            
            Console.WriteLine(document.DefaultPageSetup.LeftMargin);
            Section section = document.AddSection();
           section.PageSetup.TopMargin = Unit.FromPoint(30);
           section.PageSetup.LeftMargin = Unit.FromPoint(20);

            TextFrame leftTF = section.AddTextFrame();
            leftTF.Orientation = TextOrientation.Downward;
            leftTF.WrapFormat.Style = WrapStyle.None;
           // leftTF.MarginLeft = Unit.FromInch(1);
            //leftTF.MarginRight = Unit.FromInch(1);

            //make sure the font is embedded
            var options = new XPdfFontOptions(PdfFontEncoding.Unicode);
            Font fontEan = new Font("mrvcode39s", 20);

            leftTF.AddParagraph().AddFormattedText("*12343*", fontEan);
            // Now generate a pdf
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

            // Set the MigraDoc document
            pdfRenderer.Document = document;

            // Create the PDF document
            pdfRenderer.RenderDocument();

            // Save the PDF document...
            pdfRenderer.Save(reportFilename);

        }

        public static void verticalText()
        {
            string reportFilename = "verticalText.pdf";
            Document document = new Document();
            Section section = document.AddSection();
            Table dataTbl = section.AddTable();


            // Two columns - the first vertical, the next horisontal
            Column column = dataTbl.AddColumn("0.5cm"); // Left vertical text...
            column = dataTbl.AddColumn("4.25cm");

            // Create a number of rows
            for (int i = 0; i <= 20; i++)
                dataTbl.AddRow();


            //Merge the cells in the first column and write vertical text in it
            Cell leftSideCell = dataTbl.Rows[0].Cells[0];
            leftSideCell.MergeDown = dataTbl.Rows.Count - 1;
            leftSideCell.VerticalAlignment = VerticalAlignment.Center;
            TextFrame leftTF = leftSideCell.AddTextFrame();
            leftTF.Orientation = TextOrientation.Upward;
            leftTF.WrapFormat.Style = WrapStyle.None;

            Paragraph leftPar = leftTF.AddParagraph("How do I avoid this text getting wrapped ?");

            // Now generate a pdf
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(true);

            // Set the MigraDoc document
            pdfRenderer.Document = document;

            // Create the PDF document
            pdfRenderer.RenderDocument();

            // Save the PDF document...
            pdfRenderer.Save(reportFilename);

        }
        public static void CreateBarcodeAsText()
        {
            using (PdfDocument document = new PdfDocument())
            {
                //create pdf header
                document.Info.Title = "My barcode";
                document.Info.Author = "Me";
                document.Info.Subject = "Barcode";
                document.Info.Keywords = "Barcode, Ean13";
                document.Info.CreationDate = DateTime.Now;

                //create new pdf page
                PdfPage page = document.AddPage();
                page.Width = XUnit.FromMillimeter(210);
                page.Height = XUnit.FromMillimeter(297);

                using (XGraphics gfx = XGraphics.FromPdfPage(page))
                {
                    //make sure the font is embedded
                    var options = new XPdfFontOptions(PdfFontEncoding.Unicode);

                    //declare a font for drawing in the PDF
                    XFont fontEan = new XFont("mrvcode39s", 75, XFontStyle.Regular, options);
                    XTextFormatter tf = new XTextFormatter(gfx);
                    var stringFormat = new XStringFormat();
                    stringFormat.Alignment = XStringAlignment.Center;

                    //create the barcode from string
                    gfx.DrawString("12234", fontEan, XBrushes.Black, new XRect(15, 40, page.Width, page.Height), stringFormat);
                }


                document.Save("BarCodeTest3.pdf");
            }
        }
        
        public static void CreateBarcodeAsImage()
        {
            var document = new PdfDocument();
            var page = document.AddPage();
            var formGfx = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);

            XPoint point = new XPoint(20, 20);

            XSize BARCODE_SIZE = new XSize(Convert.ToDouble(120), Convert.ToDouble(60));
            var barCode39 = BarCode.FromType(CodeType.Code3of9Standard, "1234", BARCODE_SIZE, CodeDirection.TopToBottom);
//            XSize BARCODE_SIZE = new XSize(Convert.ToDouble(120), Convert.ToDouble(60));
          //  barCode39.Size = BARCODE_SIZE;
            formGfx.DrawBarCode(barCode39, point);


           
                                 
            document.Save("barcodetest.pdf");
        }


        public static void DrawBox()
        { 
            PdfDocument input = PdfReader.Open("20180416STMT_PRD3.pdf", PdfDocumentOpenMode.Modify);

            //Iterate pages
           
            PdfPage page = input.Pages[0];

            var formGfx = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
            XColor back = XColors.White;
            //back.A = 1;
            XSolidBrush brush = new XSolidBrush(back);
            formGfx.DrawRectangle(brush, 40, 20, 250, 70);
            formGfx.DrawRectangle(brush, 40, 557, 250, 40);
            formGfx.Save();

            PdfPage page2 = input.Pages[1];

            var formGfx2 = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page2);
            XColor back2 = XColors.White;
            //back2.A = 1;
            XSolidBrush brush2 = new XSolidBrush(back2);
            formGfx2.DrawRectangle(brush2, 40, 20, 250, 70);
            formGfx2.Save();


            input.Save("20180416STMT_PRD3.pdf");

        }

        public static void DrawGraphics()
        {
            var document = new PdfDocument();
            var page = document.AddPage();
            var formGfx = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
            // Create an empty XForm object with the specified width and height
            // A form is bound to its target document when it is created. The reason is that the form can
            // share fonts and other objects with its target document.
            XForm form = new XForm(document, XUnit.FromPoint(40), XUnit.FromPoint(600));
           
            // Create an XGraphics object for drawing the contents of the form.
           // XGraphics formGfx = XGraphics.FromForm(form);
            // Draw a large transparent rectangle to visualize the area the form occupies
            XColor back = XColors.Orange;
            back.A = 0.2;
            XSolidBrush brush = new XSolidBrush(back);
            formGfx.DrawRectangle(brush, 40, 600, 200, 80);

            // On a form you can draw...
            // ... text
            formGfx.DrawString("Text, Graphics, Images, and Forms", new XFont("OpenSans", 10, XFontStyle.Regular), XBrushes.Navy, 3, 0, XStringFormats.TopLeft);

            //XPen pen = XPens.LightBlue.Clone();
            //pen.Width = 2.5;
            
            // ... graphics like Bézier curves
          //  formGfx.DrawBeziers(pen, XPoint.ParsePoints("30,120 80,20 100,140 175,33.3"));
            
            // ... raster images like GIF files
           // XGraphicsState state = formGfx.Save();
            //formGfx.RotateAtTransform(17, new XPoint(30, 30));
            //var pathName = Path.GetFullPath("Rotating_earth_(large).gif");
            //var xImage = XImage.FromFile(pathName);
            //formGfx.DrawImage(xImage, 20, 20);
            //formGfx.Restore(state);
            
            //// ... and forms like XPdfForm objects
            //state = formGfx.Save();
            //formGfx.RotateAtTransform(-8, new XPoint(165, 115));
            //formGfx.DrawImage(XPdfForm.FromFile("SomeLayout.pdf"), new XRect(140, 80, 50, 50 * Math.Sqrt(2)));
            //formGfx.Restore(state);
            
            // When you finished drawing on the form, dispose the XGraphic object.
            //formGfx.Dispose();



            //step 2
            //// Draw the form on the page of the document in its original size
            //formGfx.DrawImage(form, 20, 50);
            
            //// Draw it stretched
            //formGfx.DrawImage(form, 300, 100, 250, 40);
            //// Draw and rotate it
            //const int d = 25;
            //for (int idx = 0; idx < 360; idx += d)
            //{
            //    formGfx.DrawImage(form, 300, 480, 200, 200);
            //    formGfx.RotateAtTransform(d, new XPoint(300, 480));
            //}
          
            document.Save("graphics.pdf");
            //formGfx.Dispose();
            
        }
        public static void SplitPdfFile()
        {
            string filename = "testOutputMerge.pdf";

            //open the file
            PdfDocument inputDocument = PdfReader.Open(filename, PdfDocumentOpenMode.Import);

            string name = Path.GetFileNameWithoutExtension(filename);

            for (int idx = 0; idx < inputDocument.PageCount; idx++)
            {
                // Create new document
                PdfDocument outputDocument = new PdfDocument();
                outputDocument.Version = inputDocument.Version;
                outputDocument.Info.Title =
                String.Format("Page {0} of {1}", idx + 1, inputDocument.Info.Title);
                outputDocument.Info.Creator = inputDocument.Info.Creator;
                
                // Add the page and save it
                outputDocument.AddPage(inputDocument.Pages[idx]);
                outputDocument.Save(String.Format("{0} - Page {1}_tempfile.pdf", name, idx + 1));
            }
        }

        public static void MergePdfFiles()
        {
            string[] files = new string[]{"test.pdf", "test2.pdf"};

            // create a new pdf
            PdfDocument outputDoc = new PdfDocument();

            foreach (var file in files)
            {
                PdfDocument input = PdfReader.Open(file, PdfDocumentOpenMode.Import);

                //Iterate pages
                int count = input.PageCount;
                for (int idx = 0; idx < count; idx++)
                {
                    PdfPage page = input.Pages[idx];
                    outputDoc.AddPage(page);
                }
            }

            //save the document
            string fileName = "testOutputMerge.pdf";
            outputDoc.Save(fileName);
            

        }
        public static void ReadPdfContents()
        {


            var document = PdfReader.Open("Clinical_A_test.pdf", PdfDocumentOpenMode.Import);

            foreach (PdfPage page in document.Pages)
            {
                //var parser = new CParser(page);
               // var seq1 = parser.ReadContent();
                var seq = ContentReader.ReadContent(page);
                var lines = ExtractText(seq);

                if(lines.Any(l=>l.Contains("INVOICE")))
                {
                    var containsInvoice = true;
                }
                var ele = page.Contents.Elements; 

            }
            //        Console.WriteLine("Hello World!");


        }
        public static void CrateAndWriteToPdf()
        {
            var document = new PdfDocument();
            var page = document.AddPage();
            var formGfx = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);

            var font = new XFont("OpenSans", 20, XFontStyle.Bold);

            formGfx.DrawString("How are you?", font, XBrushes.Black, new XRect(20, 20, page.Width, page.Height), XStringFormats.Center);

            document.Save("test2.pdf");
        }

        private static IEnumerable<string> ExtractText(CObject cObject)
        {
            var textList = new List<string>();
            if (cObject is COperator)
            {
                var cOperator = cObject as COperator;
                if (cOperator.OpCode.Name == OpCodeName.Tj.ToString() ||
                    cOperator.OpCode.Name == OpCodeName.TJ.ToString())
                {
                    foreach (var cOperand in cOperator.Operands)
                    {
                        textList.AddRange(ExtractText(cOperand));
                    }
                }
            }
            else if (cObject is CSequence)
            {
                var cSequence = cObject as CSequence;
                foreach (var element in cSequence)
                {
                    textList.AddRange(ExtractText(element));
                }
            }
            else if (cObject is CString)
            {
                var cString = cObject as CString;
                textList.Add(cString.Value);
            }
            return textList;
        }

    }



    //This implementation is obviously not very good --> Though it should be enough for everyone to implement their own.
    public class FontResolver : IFontResolver
    {
        public string DefaultFontName => "OpenSans";

        public byte[] GetFont(string faceName)
        {
            using (var ms = new MemoryStream())
            {
                using (var fs = File.Open(faceName, FileMode.Open))
                {
                    fs.CopyTo(ms);
                    ms.Position = 0;
                    return ms.ToArray();
                }
            }
        }
        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            if (familyName.Equals("OpenSans", StringComparison.CurrentCultureIgnoreCase) || familyName.Equals("Open Sans", StringComparison.CurrentCultureIgnoreCase))
            {
                if (isBold && isItalic)
                {
                    return new FontResolverInfo("./fonts/open-sans/OpenSans-BoldItalic.ttf");
                }
                else if (isBold)
                {
                    return new FontResolverInfo("./fonts/open-sans/OpenSans-Bold.ttf");
                }
                else if (isItalic)
                {
                    return new FontResolverInfo("./fonts/open-sans/OpenSans-Italic.ttf");
                }
                else
                {
                    return new FontResolverInfo("./fonts/open-sans/OpenSans-Regular.ttf");
                }
            }
            if (familyName.Equals("mrvcode39s", StringComparison.CurrentCultureIgnoreCase) || familyName.Equals("MRV Code39S", StringComparison.CurrentCultureIgnoreCase))
            {
                return new FontResolverInfo("./fonts/mrvcode39s.ttf");
            }
                return null;
        }
    }

    //public static class PdfSharpExtensions
    //{
    //    public static IEnumerable<string> ExtractText(this PdfPage page)
    //    {
    //        var content = ContentReader.ReadContent(page);
    //        var text = content.ExtractText();
    //        return text;
    //    }

    //    public static IEnumerable<string> ExtractText(this CObject cObject)
    //    {
    //        if (cObject is COperator)
    //        {
    //            var cOperator = cObject as COperator;
    //            if (cOperator.OpCode.Name == OpCodeName.Tj.ToString() ||
    //                cOperator.OpCode.Name == OpCodeName.TJ.ToString())
    //            {
    //                foreach (var cOperand in cOperator.Operands)
    //                foreach (var txt in ExtractText(cOperand))
    //                    yield return txt;
    //            }
    //        }
    //        else if (cObject is CSequence)
    //        {
    //            var cSequence = cObject as CSequence;
    //            foreach (var element in cSequence)
    //            foreach (var txt in ExtractText(element))
    //                yield return txt;
    //        }
    //        else if (cObject is CString)
    //        {
    //            var cString = cObject as CString;
    //            yield return cString.Value;
    //        }
    //    }
    //}
}
