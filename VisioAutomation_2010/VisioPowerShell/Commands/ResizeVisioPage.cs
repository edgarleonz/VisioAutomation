using System.Management.Automation;
using VisioAutomation.ShapeSheet;

namespace VisioPowerShell.Commands
{
    [Cmdlet(VerbsCommon.Resize, VisioPowerShell.Commands.Nouns.VisioPage)]
    public class ResizeVisioPage : VisioCmdlet
    {
        [Parameter(Mandatory = false)]
        public double Width = -1;

        [Parameter(Mandatory = false)]
        public double Height = -1;

        [Parameter(Mandatory = false)]
        public SwitchParameter FitContents;

        [Parameter(Mandatory = false)]
        public double BorderWidth { get; set; }

        [Parameter(Mandatory = false)]
        public double BorderHeight { get; set; }

        protected override void ProcessRecord()
        {
            if (this.FitContents)
            {
                var bordersize = new VisioAutomation.Geometry.Size(this.BorderWidth, this.BorderWidth);
                this.Client.Page.ResizeToFitContents(bordersize, true);                
            }

            if (this.Width > 0 || this.Height > 0)
            {
                var page = this.Client.Application.Get().ActivePage;
                var old_page_format_cells = VisioAutomation.Pages.PageFormatCells.GetValues(page.PageSheet, CellValueType.Formula);

                var new_page_format_cells = new VisioAutomation.Pages.PageFormatCells();
                
                if (this.Width > 0)
                {
                    new_page_format_cells.Width = this.Width;
                }

                if (this.Height > 0)
                {
                    new_page_format_cells.Height = this.Height;
                }

                var writer = new VisioAutomation.ShapeSheet.Writers.SrcWriter();
                new_page_format_cells.SetFormulas(writer);
                writer.BlastGuards = true;

                writer.Commit(page);
            }
        }
    }
}