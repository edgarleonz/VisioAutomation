using VisioAutomation.ShapeSheet;
using VisioAutomation.ShapeSheet.CellGroups;
using VisioAutomation.ShapeSheet.Query;

namespace VisioAutomation.Pages
{
    class PageRulerAndGridCellsReader : ReaderSingleRow<VisioAutomation.Pages.PageRulerAndGridCells>
    {
        public CellColumn XGridDensity { get; set; }
        public CellColumn XGridOrigin { get; set; }
        public CellColumn XGridSpacing { get; set; }
        public CellColumn XRulerDensity { get; set; }
        public CellColumn XRulerOrigin { get; set; }
        public CellColumn YGridDensity { get; set; }
        public CellColumn YGridOrigin { get; set; }
        public CellColumn YGridSpacing { get; set; }
        public CellColumn YRulerDensity { get; set; }
        public CellColumn YRulerOrigin { get; set; }

        public PageRulerAndGridCellsReader()
        {
            this.XGridDensity = this.query.Columns.Add(SrcConstants.XGridDensity, nameof(SrcConstants.XGridDensity));
            this.XGridOrigin = this.query.Columns.Add(SrcConstants.XGridOrigin, nameof(SrcConstants.XGridOrigin));
            this.XGridSpacing = this.query.Columns.Add(SrcConstants.XGridSpacing, nameof(SrcConstants.XGridSpacing));
            this.XRulerDensity = this.query.Columns.Add(SrcConstants.XRulerDensity, nameof(SrcConstants.XRulerDensity));
            this.XRulerOrigin = this.query.Columns.Add(SrcConstants.XRulerOrigin, nameof(SrcConstants.XRulerOrigin));
            this.YGridDensity = this.query.Columns.Add(SrcConstants.YGridDensity, nameof(SrcConstants.YGridDensity));
            this.YGridOrigin = this.query.Columns.Add(SrcConstants.YGridOrigin, nameof(SrcConstants.YGridOrigin));
            this.YGridSpacing = this.query.Columns.Add(SrcConstants.YGridSpacing, nameof(SrcConstants.YGridSpacing));
            this.YRulerDensity = this.query.Columns.Add(SrcConstants.YRulerDensity, nameof(SrcConstants.YRulerDensity));
            this.YRulerOrigin = this.query.Columns.Add(SrcConstants.YRulerOrigin, nameof(SrcConstants.YRulerOrigin));
        }

        public override PageRulerAndGridCells CellDataToCellGroup(VisioAutomation.Utilities.ArraySegment<string> row)
        {
            var cells = new Pages.PageRulerAndGridCells();
            cells.XGridDensity = row[this.XGridDensity];
            cells.XGridOrigin = row[this.XGridOrigin];
            cells.XGridSpacing = row[this.XGridSpacing];
            cells.XRulerDensity = row[this.XRulerDensity];
            cells.XRulerOrigin = row[this.XRulerOrigin];
            cells.YGridDensity = row[this.YGridDensity];
            cells.YGridOrigin = row[this.YGridOrigin];
            cells.YGridSpacing = row[this.YGridSpacing];
            cells.YRulerDensity = row[this.YRulerDensity];
            cells.YRulerOrigin = row[this.YRulerOrigin];
            return cells;
        }
    }
}