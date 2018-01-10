using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dairy_departure
{
    class Export
    {
        public void ExportDocument(DataGridView dataGridView)
        {
            // Create a MigraDoc document
            Document document = new Document();

            //string ddl = MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToString(document);
            MigraDoc.DocumentObjectModel.IO.DdlWriter.WriteToFile(document, "MigraDoc.mdddl");

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;

            Section section = document.AddSection();
            section.PageSetup.OddAndEvenPagesHeaderFooter = true;
            section.PageSetup.StartingNumber = 1;

            HeaderFooter header = section.Headers.Primary;
            header.AddParagraph("\tCheck");

            header = section.Headers.EvenPage;
            header.AddParagraph("Even Page Header");

            // Create a paragraph with centered page number. See definition of style "Footer".
            Paragraph paragraph = new Paragraph();
            paragraph.AddTab();
            paragraph.AddPageField();

            // Add paragraph to footer for odd pages.
            section.Footers.Primary.Add(paragraph);
            // Add clone of paragraph to footer for odd pages. Cloning is necessary because an object must
            // not belong to more than one other object. If you forget cloning an exception is thrown.
            section.Footers.EvenPage.Add(paragraph.Clone());

            document.LastSection.AddParagraph("Simple Tables", "Heading2");

            Table table = new Table();
            table.Borders.Width = 0.75;

            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (dataGridView.Columns[i].Visible && dataGridView.Columns[i].Name != "btnDel" && dataGridView.Columns[i].Name != "DiscountInfo")
                {
                    table.AddColumn(60);
                }
            }
            Column column = table.Columns[0];
            column.Format.Alignment = ParagraphAlignment.Center;

            Row row = table.AddRow();
            row.Shading.Color = Colors.PaleGoldenrod;
            Cell cell;
            int j = 0;
            for (int i = 0; i < dataGridView.ColumnCount; i++)
            {
                if (dataGridView.Columns[i].Visible && dataGridView.Columns[i].Name != "btnDel" && dataGridView.Columns[i].Name != "DiscountInfo")
                {
                    cell = row.Cells[j];
                    cell.AddParagraph(dataGridView.Columns[i].HeaderText);
                    j++;
                }
            }

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                int m = 0;
                row = table.AddRow();
                for (int k = 0; m < j; k++)
                {
                    if (dataGridView.Columns[k].Visible && dataGridView.Columns[k].Name != "btnDel" && dataGridView.Columns[k].Name != "DiscountInfo")
                    {
                        if (dataGridView.Rows[i].Cells[k].Value == null)
                        {
                            row.Cells[m].AddParagraph("  ");
                            m++;
                            continue;
                        }
                        row.Cells[m].AddParagraph(dataGridView.Rows[i].Cells[k].Value.ToString());
                        m++;
                    }
                }
            }

            table.SetEdge(0, 0, j, dataGridView.RowCount + 1, Edge.Box, MigraDoc.DocumentObjectModel.BorderStyle.Single, 1.5, Colors.Black);

            document.LastSection.Add(table);


            renderer.RenderDocument();

            string filename = "Report.pdf";
            renderer.PdfDocument.Save(filename);
            Process.Start(filename);
        }

    }
}
