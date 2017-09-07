﻿using System.Collections.Generic;
using VisioAutomation.ShapeSheet.CellGroups;
using IVisio = Microsoft.Office.Interop.Visio;

namespace VisioAutomation.Shapes
{
    public class ShapeFormatCells : ShapeSheet.CellGroups.CellGroupSingleRow
    {
        public VisioAutomation.ShapeSheet.CellValueLiteral FillBackground { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillBackgroundTransparency { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillForeground { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillForegroundTransparency { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillPattern { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowObliqueAngle { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowOffsetX { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowOffsetY { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowScaleFactor { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowType { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowBackground { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowBackgroundTransparency { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowForeground { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowForegroundTransparency { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral FillShadowPattern { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineBeginArrow { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineBeginArrowSize { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineEndArrow { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineEndArrowSize { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineCap { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineColor { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineColorTransparency { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LinePattern { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineWeight { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LineRounding { get; set; }

        public override IEnumerable<SrcFormulaPair> SrcFormulaPairs
        {
            get
            {
                yield return this.newpair(ShapeSheet.SrcConstants.FillBackground, this.FillBackground.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillBackgroundTransparency, this.FillBackgroundTransparency.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillForeground, this.FillForeground.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillForegroundTransparency, this.FillForegroundTransparency.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillPattern, this.FillPattern.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowObliqueAngle, this.FillShadowObliqueAngle.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowOffsetX, this.FillShadowOffsetX.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowOffsetY, this.FillShadowOffsetY.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowScaleFactor, this.FillShadowScaleFactor.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowType, this.FillShadowType.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowBackground, this.FillShadowBackground.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowBackgroundTransparency, this.FillShadowBackgroundTransparency.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowForeground, this.FillShadowForeground.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowForegroundTransparency, this.FillShadowForegroundTransparency.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.FillShadowPattern, this.FillShadowPattern.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineBeginArrow, this.LineBeginArrow.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineBeginArrowSize, this.LineBeginArrowSize.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineEndArrow, this.LineEndArrow.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineEndArrowSize, this.LineEndArrowSize.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineCap, this.LineCap.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineColor, this.LineColor.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineColorTransparency, this.LineColorTransparency.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LinePattern, this.LinePattern.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineWeight, this.LineWeight.Value);
                yield return this.newpair(ShapeSheet.SrcConstants.LineRounding, this.LineRounding.Value);
            }
        }


        public static List<ShapeFormatCells> GetCells(IVisio.Page page, IList<int> shapeids, VisioAutomation.ShapeSheet.CellValueType cvt)
        {
            var query = ShapeFormatCells.lazy_query.Value;
            return query.GetCellGroups(page, shapeids, cvt);
        }

        public static ShapeFormatCells GetCells(IVisio.Shape shape, VisioAutomation.ShapeSheet.CellValueType cvt)
        {
            var query = ShapeFormatCells.lazy_query.Value;
            return query.GetCellGroup(shape, cvt);
        }

        private static readonly System.Lazy<ShapeFormatCellsReader> lazy_query = new System.Lazy<ShapeFormatCellsReader>();
    }
}

