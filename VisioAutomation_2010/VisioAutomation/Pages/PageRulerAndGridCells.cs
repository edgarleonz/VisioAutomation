using System.Collections.Generic;
using VisioAutomation.ShapeSheet.CellGroups;

namespace VisioAutomation.Pages
{
    public class PageRulerAndGridCells : ShapeSheet.CellGroups.CellGroupSingleRow
    {
        public VisioAutomation.ShapeSheet.CellValueLiteral XGridDensity { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral YGridDensity { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral XGridOrigin { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral YGridOrigin { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral XGridSpacing { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral YGridSpacing { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral XRulerDensity { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral XRulerOrigin { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral YRulerDensity { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral YRulerOrigin { get; set; }

        public override IEnumerable<SrcFormulaPair> SrcFormulaPairs
        {
            get
            {
                yield return this.newpair(ShapeSheet.SrcConstants.XGridDensity, this.XGridDensity.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.XGridOrigin, this.XGridOrigin.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.XGridSpacing, this.XGridSpacing.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.XRulerDensity, this.XRulerDensity.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.XRulerOrigin, this.XRulerOrigin.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.YGridDensity, this.YGridDensity.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.YGridOrigin, this.YGridOrigin.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.YGridSpacing, this.YGridSpacing.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.YRulerDensity, this.YRulerDensity.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.YRulerOrigin, this.YRulerOrigin.Value);
            }
        }

        public static PageRulerAndGridCells GetCells(Microsoft.Office.Interop.Visio.Shape shape, VisioAutomation.ShapeSheet.CellValueType cvt)
        {
            var query = PageRulerAndGridCells.lazy_query.Value;
            return query.GetCellGroup(shape, cvt);
        }

        private static readonly System.Lazy<PageRulerAndGridCellsReader> lazy_query = new System.Lazy<PageRulerAndGridCellsReader>();
    }
}