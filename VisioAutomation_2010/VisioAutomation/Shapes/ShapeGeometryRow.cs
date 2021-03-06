using IVisio = Microsoft.Office.Interop.Visio;
using VA = VisioAutomation;

namespace VisioAutomation.Shapes
{
    public class ShapeGeometryRow
    {
        public ShapeSheet.CellValueLiteral X { get; set; }
        public ShapeSheet.CellValueLiteral Y { get; set; }
        public ShapeSheet.CellValueLiteral A { get; set; }
        public ShapeSheet.CellValueLiteral B { get; set; }
        public ShapeSheet.CellValueLiteral C { get; set; }
        public ShapeSheet.CellValueLiteral D { get; set; }
        public ShapeSheet.CellValueLiteral E { get; set; }
        public IVisio.VisRowTags RowTag { get; set; }

        public ShapeGeometryRow(IVisio.VisRowTags tag)
        {
            this.RowTag = tag;
        }

        public virtual IVisio.VisRowTags GetRowTagType()
        {
            return this.RowTag;
        }

        public void AddTo(IVisio.Shape shape, ShapeSheet.Writers.SrcWriter writer, short row, short section)
        {
            short row_index = shape.AddRow(section, row, (short) this.GetRowTagType());
            this.Update(section, row_index, writer);
        }


        private void Update(short section_index, short row_index, ShapeSheet.Writers.SrcWriter writer)
        {
            var x_src = new VA.ShapeSheet.Src(section_index, row_index,ShapeSheet.SrcConstants.GeometryVertexX.Cell);
            var y_src = new VA.ShapeSheet.Src(section_index, row_index,ShapeSheet.SrcConstants.GeometryVertexY.Cell);
            var a_src = new VA.ShapeSheet.Src(section_index, row_index,ShapeSheet.SrcConstants.GeometryVertexA.Cell);
            var b_src = new VA.ShapeSheet.Src(section_index, row_index,ShapeSheet.SrcConstants.GeometryVertexB.Cell);
            var c_src = new VA.ShapeSheet.Src(section_index, row_index,ShapeSheet.SrcConstants.GeometryVertexC.Cell);
            var d_src = new VA.ShapeSheet.Src(section_index, row_index,ShapeSheet.SrcConstants.GeometryVertexD.Cell);
            var e_src = new VA.ShapeSheet.Src(section_index, row_index,ShapeSheet.SrcConstants.GeometryVertexE.Cell);

            writer.SetValue(x_src, this.X);
            writer.SetValue(y_src, this.Y);
            writer.SetValue(a_src, this.A);
            writer.SetValue(b_src, this.B);
            writer.SetValue(c_src, this.C);
            writer.SetValue(d_src, this.D);
            writer.SetValue(e_src, this.E);
        }

        public static ShapeGeometryRow CreateLineTo(ShapeSheet.CellValueLiteral x, ShapeSheet.CellValueLiteral y)
        {
            // http://msdn.microsoft.com/en-us/library/aa195656(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagLineTo);
            row.X = x;
            row.Y = y;
            return row;
        }

        public static ShapeGeometryRow CreateMoveTo(ShapeSheet.CellValueLiteral x, ShapeSheet.CellValueLiteral y)
        {
            // http://msdn.microsoft.com/en-us/library/aa195679(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagMoveTo);
            row.X = x;
            row.Y = y;
            return row;
        }

        public static ShapeGeometryRow CreateArcTo(ShapeSheet.CellValueLiteral x, ShapeSheet.CellValueLiteral y,
                                              ShapeSheet.CellValueLiteral a)
        {
            // http://msdn.microsoft.com/en-us/library/aa195698(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagArcTo);
            row.X = x;
            row.Y = y;
            row.A = a;
            return row;
        }

        public static ShapeGeometryRow CreateEllipticalArcTo(ShapeSheet.CellValueLiteral x,
                                                        ShapeSheet.CellValueLiteral y,
                                                        ShapeSheet.CellValueLiteral a,
                                                        ShapeSheet.CellValueLiteral b,
                                                        ShapeSheet.CellValueLiteral c,
                                                        ShapeSheet.CellValueLiteral d)
        {
            // http://msdn.microsoft.com/en-us/library/aa195660(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagEllipticalArcTo);
            row.X = x;
            row.Y = y;
            row.A = a;
            row.B = b;
            row.C = c;
            row.D = d;
            return row;
        }

        public static ShapeGeometryRow CreateEllipse(ShapeSheet.CellValueLiteral x,
                                                ShapeSheet.CellValueLiteral y,
                                                ShapeSheet.CellValueLiteral a,
                                                ShapeSheet.CellValueLiteral b,
                                                ShapeSheet.CellValueLiteral c,
                                                ShapeSheet.CellValueLiteral d)
        {

            // http://msdn.microsoft.com/en-us/library/aa195692(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagEllipse);
            row.X = x;
            row.Y = y;
            row.A = a;
            row.B = b;
            row.C = c;
            row.D = d;
            return row;
        }

        public static ShapeGeometryRow CreateNurbsTo(ShapeSheet.CellValueLiteral x,
                                                ShapeSheet.CellValueLiteral y,
                                                ShapeSheet.CellValueLiteral a,
                                                ShapeSheet.CellValueLiteral b,
                                                ShapeSheet.CellValueLiteral c,
                                                ShapeSheet.CellValueLiteral d,
                                                ShapeSheet.CellValueLiteral e)
        {
            // http://msdn.microsoft.com/en-us/library/aa195685(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagEllipse);
            row.X = x;
            row.Y = y;
            row.A = a;
            row.B = b;
            row.C = c;
            row.D = d;
            row.E = e;
            return row;
        }

        public static ShapeGeometryRow CreatePolylineTo(ShapeSheet.CellValueLiteral x,
                                        ShapeSheet.CellValueLiteral y,
                                        ShapeSheet.CellValueLiteral a)
        {
            // http://msdn.microsoft.com/en-us/library/aa195682(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagPolylineTo);
            row.X = x;
            row.Y = y;
            row.A = a;
            return row;
        }

        public static ShapeGeometryRow CreateInfiniteLine(ShapeSheet.CellValueLiteral x,
                                ShapeSheet.CellValueLiteral y,
                                ShapeSheet.CellValueLiteral a,
                                ShapeSheet.CellValueLiteral b)
        {
            // http://msdn.microsoft.com/en-us/library/aa195682(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagInfiniteLine);
            row.X = x;
            row.Y = y;
            row.A = a;
            row.B = b;
            return row;
        }

        public static ShapeGeometryRow CreateSplineKnot(ShapeSheet.CellValueLiteral x,
                                ShapeSheet.CellValueLiteral y,
                                ShapeSheet.CellValueLiteral a)
        {
            // http://msdn.microsoft.com/en-us/library/aa195667(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagSplineSpan);
            row.X = x;
            row.Y = y;
            row.A = a;
            return row;
        }

        public static ShapeGeometryRow CreateSplineStart(ShapeSheet.CellValueLiteral x,
                                                ShapeSheet.CellValueLiteral y,
                                                ShapeSheet.CellValueLiteral a,
                                                ShapeSheet.CellValueLiteral b,
                                                ShapeSheet.CellValueLiteral c,
                                                ShapeSheet.CellValueLiteral d)
        {

            // http://msdn.microsoft.com/en-us/library/aa195663(v=office.11).aspx

            var row = new ShapeGeometryRow(IVisio.VisRowTags.visTagSplineBeg);
            row.X = x;
            row.Y = y;
            row.A = a;
            row.B = b;
            row.C = c;
            row.D = d;
            return row;
        }
    }
}