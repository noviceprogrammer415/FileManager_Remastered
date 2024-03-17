using System.Diagnostics;
using TemplateEngine.Docx;

namespace FileManager.Core.Report
{
    public sealed class ReportService
    {
        public void GenerateReport(FileInfo templateFile, string path = "")
        {
            var report_file = new FileInfo(path);
            if (report_file.Exists)
                report_file.Delete();
            
            templateFile.CopyTo(report_file.FullName);

            IEnumerable<TableRowContent> rows = Enumerable.Empty<TableRowContent>();

            foreach (var drive in DriveInfo.GetDrives())
            {
                rows = rows.Append(new(new List<FieldContent>
                {
                    new("Name", drive.Name),
                    new("DriveType", drive.DriveType.ToString()),
                    new("DriveFormat", drive.DriveFormat),
                    new("AvailableFreeSpace", drive.AvailableFreeSpace.ToString()),
                    new("TotalSize", drive.TotalSize.ToString()),
                }));
            }
            
            using var document = new TemplateProcessor(report_file.FullName).SetRemoveContentControls(isNeedToRemove: true);
            document.FillContent(content: new(TableContent.Create("Drivers", rows.ToArray())));
            document.SaveChanges();
            
            Process.Start(new ProcessStartInfo(report_file.FullName) { UseShellExecute = true });
        }
    }
}
