using VisioAutomation.ShapeSheetQuery.Columns;
using SRCCON = VisioAutomation.ShapeSheet.SRCConstants;

namespace VisioAutomation.ShapeSheetQuery.CommonQueries
{
    class ShapeLayoutCellsQuery : Query
    {
        public ColumnQuery ConFixedCode { get; set; }
        public ColumnQuery ConLineJumpCode { get; set; }
        public ColumnQuery ConLineJumpDirX { get; set; }
        public ColumnQuery ConLineJumpDirY { get; set; }
        public ColumnQuery ConLineJumpStyle { get; set; }
        public ColumnQuery ConLineRouteExt { get; set; }
        public ColumnQuery ShapeFixedCode { get; set; }
        public ColumnQuery ShapePermeablePlace { get; set; }
        public ColumnQuery ShapePermeableX { get; set; }
        public ColumnQuery ShapePermeableY { get; set; }
        public ColumnQuery ShapePlaceFlip { get; set; }
        public ColumnQuery ShapePlaceStyle { get; set; }
        public ColumnQuery ShapePlowCode { get; set; }
        public ColumnQuery ShapeRouteStyle { get; set; }
        public ColumnQuery ShapeSplit { get; set; }
        public ColumnQuery ShapeSplittable { get; set; }
        public ColumnQuery DisplayLevel { get; set; }
        public ColumnQuery Relationships { get; set; }

        public ShapeLayoutCellsQuery() :
            base()
        {
            this.ConFixedCode = this.AddCell(SRCCON.ConFixedCode, nameof(SRCCON.ConFixedCode));
            this.ConLineJumpCode = this.AddCell(SRCCON.ConLineJumpCode, nameof(SRCCON.ConLineJumpCode));
            this.ConLineJumpDirX = this.AddCell(SRCCON.ConLineJumpDirX, nameof(SRCCON.ConLineJumpDirX));
            this.ConLineJumpDirY = this.AddCell(SRCCON.ConLineJumpDirY, nameof(SRCCON.ConLineJumpDirY));
            this.ConLineJumpStyle = this.AddCell(SRCCON.ConLineJumpStyle, nameof(SRCCON.ConLineJumpStyle));
            this.ConLineRouteExt = this.AddCell(SRCCON.ConLineRouteExt, nameof(SRCCON.ConLineRouteExt));
            this.ShapeFixedCode = this.AddCell(SRCCON.ShapeFixedCode, nameof(SRCCON.ShapeFixedCode));
            this.ShapePermeablePlace = this.AddCell(SRCCON.ShapePermeablePlace, nameof(SRCCON.ShapePermeablePlace));
            this.ShapePermeableX = this.AddCell(SRCCON.ShapePermeableX, nameof(SRCCON.ShapePermeableX));
            this.ShapePermeableY = this.AddCell(SRCCON.ShapePermeableY, nameof(SRCCON.ShapePermeableY));
            this.ShapePlaceFlip = this.AddCell(SRCCON.ShapePlaceFlip, nameof(SRCCON.ShapePlaceFlip));
            this.ShapePlaceStyle = this.AddCell(SRCCON.ShapePlaceStyle, nameof(SRCCON.ShapePlaceStyle));
            this.ShapePlowCode = this.AddCell(SRCCON.ShapePlowCode, nameof(SRCCON.ShapePlowCode));
            this.ShapeRouteStyle = this.AddCell(SRCCON.ShapeRouteStyle, nameof(SRCCON.ShapeRouteStyle));
            this.ShapeSplit = this.AddCell(SRCCON.ShapeSplit, nameof(SRCCON.ShapeSplit));
            this.ShapeSplittable = this.AddCell(SRCCON.ShapeSplittable, nameof(SRCCON.ShapeSplittable));
            this.DisplayLevel = this.AddCell(SRCCON.DisplayLevel, nameof(SRCCON.DisplayLevel));
            this.Relationships = this.AddCell(SRCCON.Relationships, nameof(SRCCON.Relationships));


        }

        public Shapes.Layout.ShapeLayoutCells GetCells(ShapeSheet.CellData<double>[] row)
        {
            var cells = new Shapes.Layout.ShapeLayoutCells();
            cells.ConFixedCode = Extensions.CellDataMethods.ToInt(row[this.ConFixedCode]);
            cells.ConLineJumpCode = Extensions.CellDataMethods.ToInt(row[this.ConLineJumpCode]);
            cells.ConLineJumpDirX = Extensions.CellDataMethods.ToInt(row[this.ConLineJumpDirX]);
            cells.ConLineJumpDirY = Extensions.CellDataMethods.ToInt(row[this.ConLineJumpDirY]);
            cells.ConLineJumpStyle = Extensions.CellDataMethods.ToInt(row[this.ConLineJumpStyle]);
            cells.ConLineRouteExt = Extensions.CellDataMethods.ToInt(row[this.ConLineRouteExt]);
            cells.ShapeFixedCode = Extensions.CellDataMethods.ToInt(row[this.ShapeFixedCode]);
            cells.ShapePermeablePlace = Extensions.CellDataMethods.ToInt(row[this.ShapePermeablePlace]);
            cells.ShapePermeableX = Extensions.CellDataMethods.ToInt(row[this.ShapePermeableX]);
            cells.ShapePermeableY = Extensions.CellDataMethods.ToInt(row[this.ShapePermeableY]);
            cells.ShapePlaceFlip = Extensions.CellDataMethods.ToInt(row[this.ShapePlaceFlip]);
            cells.ShapePlaceStyle = Extensions.CellDataMethods.ToInt(row[this.ShapePlaceStyle]);
            cells.ShapePlowCode = Extensions.CellDataMethods.ToInt(row[this.ShapePlowCode]);
            cells.ShapeRouteStyle = Extensions.CellDataMethods.ToInt(row[this.ShapeRouteStyle]);
            cells.ShapeSplit = Extensions.CellDataMethods.ToInt(row[this.ShapeSplit]);
            cells.ShapeSplittable = Extensions.CellDataMethods.ToInt(row[this.ShapeSplittable]);
            cells.DisplayLevel = Extensions.CellDataMethods.ToInt(row[this.DisplayLevel]);
            cells.Relationships = Extensions.CellDataMethods.ToInt(row[this.Relationships]);
            return cells;
        }
    }
}