using System.Collections.Generic;
using VisioAutomation.ShapeSheet.CellGroups;
using VisioAutomation.ShapeSheet;

namespace VisioAutomation.Shapes
{
    public class ShapeLayoutCells : CellGroup
    {
        public CellValueLiteral ConnectorFixedCode { get; set; }
        public CellValueLiteral LineJumpCode { get; set; }
        public CellValueLiteral LineJumpDirX { get; set; }
        public CellValueLiteral LineJumpDirY { get; set; }
        public CellValueLiteral LineJumpStyle { get; set; }
        public CellValueLiteral LineRouteExt { get; set; }
        public CellValueLiteral ShapeFixedCode { get; set; }
        public CellValueLiteral ShapePermeablePlace { get; set; }
        public CellValueLiteral ShapePermeableX { get; set; }
        public CellValueLiteral ShapePermeableY { get; set; }
        public CellValueLiteral ShapePlaceFlip { get; set; }
        public CellValueLiteral ShapePlaceStyle { get; set; }
        public CellValueLiteral ShapePlowCode { get; set; }
        public CellValueLiteral ShapeRouteStyle { get; set; }
        public CellValueLiteral ShapeSplit { get; set; }
        public CellValueLiteral ShapeSplittable { get; set; }
        public CellValueLiteral ShapeDisplayLevel { get; set; } // new in visio 2010
        public CellValueLiteral Relationships { get; set; } // new in visio 2010

        public override IEnumerable<NamedSrcValuePair> NamedSrcValuePairs
        {
            get
            {


                yield return NamedSrcValuePair.Create(nameof(this.ConnectorFixedCode), SrcConstants.ShapeLayoutConnectorFixedCode, this.ConnectorFixedCode);
                yield return NamedSrcValuePair.Create(nameof(this.LineJumpCode), SrcConstants.ShapeLayoutLineJumpCode, this.LineJumpCode);
                yield return NamedSrcValuePair.Create(nameof(this.LineJumpDirX), SrcConstants.ShapeLayoutLineJumpDirX, this.LineJumpDirX);
                yield return NamedSrcValuePair.Create(nameof(this.LineJumpDirY), SrcConstants.ShapeLayoutLineJumpDirY, this.LineJumpDirY);
                yield return NamedSrcValuePair.Create(nameof(this.LineJumpStyle), SrcConstants.ShapeLayoutLineJumpStyle, this.LineJumpStyle);
                yield return NamedSrcValuePair.Create(nameof(this.LineRouteExt), SrcConstants.ShapeLayoutLineRouteExt, this.LineRouteExt);
                yield return NamedSrcValuePair.Create(nameof(this.ShapeFixedCode), SrcConstants.ShapeLayoutShapeFixedCode, this.ShapeFixedCode);
                yield return NamedSrcValuePair.Create(nameof(this.ShapePermeablePlace), SrcConstants.ShapeLayoutShapePermeablePlace, this.ShapePermeablePlace);
                yield return NamedSrcValuePair.Create(nameof(this.ShapePermeableX), SrcConstants.ShapeLayoutShapePermeableX, this.ShapePermeableX);
                yield return NamedSrcValuePair.Create(nameof(this.ShapePermeableY), SrcConstants.ShapeLayoutShapePermeableY, this.ShapePermeableY);
                yield return NamedSrcValuePair.Create(nameof(this.ShapePlaceFlip), SrcConstants.ShapeLayoutShapePlaceFlip, this.ShapePlaceFlip);
                yield return NamedSrcValuePair.Create(nameof(this.ShapePlaceStyle), SrcConstants.ShapeLayoutShapePlaceStyle, this.ShapePlaceStyle);
                yield return NamedSrcValuePair.Create(nameof(this.ShapePlowCode), SrcConstants.ShapeLayoutShapePlowCode, this.ShapePlowCode);
                yield return NamedSrcValuePair.Create(nameof(this.ShapeRouteStyle), SrcConstants.ShapeLayoutShapeRouteStyle, this.ShapeRouteStyle);
                yield return NamedSrcValuePair.Create(nameof(this.ShapeSplit), SrcConstants.ShapeLayoutShapeSplit, this.ShapeSplit);
                yield return NamedSrcValuePair.Create(nameof(this.ShapeSplittable), SrcConstants.ShapeLayoutShapeSplittable, this.ShapeSplittable);
                yield return NamedSrcValuePair.Create(nameof(this.ShapeDisplayLevel), SrcConstants.ShapeLayoutShapeDisplayLevel, this.ShapeDisplayLevel);
                yield return NamedSrcValuePair.Create(nameof(this.Relationships), SrcConstants.ShapeLayoutRelationships, this.Relationships);
            }
        }
    }
}