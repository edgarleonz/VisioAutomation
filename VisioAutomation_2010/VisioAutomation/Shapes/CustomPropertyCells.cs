﻿using System.Collections.Generic;
using VisioAutomation.ShapeSheet.CellGroups;
using IVisio = Microsoft.Office.Interop.Visio;
using VisioAutomation.ShapeSheet;
using VisioAutomation.ShapeSheet.Query;

namespace VisioAutomation.Shapes
{
    public class CustomPropertyCells : ShapeSheet.CellGroups.CellGroupMultiRow
    {
        public VisioAutomation.ShapeSheet.CellValueLiteral Ask { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral Calendar { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral Format { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral Invisible { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral Label { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral LangID { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral Prompt { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral SortKey { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral Type { get; set; }
        public VisioAutomation.ShapeSheet.CellValueLiteral Value { get; set; }

        public CustomPropertyCells()
        {

        }

        private string SmartStringToFormulaString(ShapeSheet.CellValueLiteral formula, bool force_no_quoting)
        {
            if (!formula.HasValue)
            {
                return null;
            }

            if (formula.Value.Length == 0)
            {
                return VisioAutomation.Utilities.Convert.StringToFormulaString(formula.Value);
            }

            if (formula.Value[0] != '\"')
            {
                if (force_no_quoting)
                {
                    return formula.Value;
                }
                return VisioAutomation.Utilities.Convert.StringToFormulaString(formula.Value);
            }

            return formula.Value;
        }

        public override IEnumerable<SrcValuePair> SrcValuePairs
        {
            get
            {
                var cp = this;

                string str_label = this.SmartStringToFormulaString(cp.Label.Value, false);
                string str_value = null;
                if (cp.Type.Value == "0" || cp.Type.Value == null)
                {
                    // if type has no value or is a "0" then it is a string
                    str_value = this.SmartStringToFormulaString(cp.Value.Value, false);
                }
                else
                {
                    // For non-stringd don't add any extra quotes
                    str_value = this.SmartStringToFormulaString(cp.Value.Value, true);
                }
                string str_format = this.SmartStringToFormulaString(cp.Format.Value, false);
                string str_prompt = this.SmartStringToFormulaString(cp.Prompt.Value, false);

                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropLabel, str_label);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropValue, str_value);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropFormat, str_format);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropPrompt, str_prompt);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropCalendar, cp.Calendar);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropLangID, cp.LangID);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropSortKey, cp.SortKey);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropInvisible, cp.Invisible);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropType, cp.Type);
                yield return SrcValuePair.Create(ShapeSheet.SrcConstants.CustomPropAsk, cp.Ask);
            }
        }

        public static List<List<CustomPropertyCells>> GetCells(IVisio.Page page, IList<int> shapeids, CellValueType cvt)
        {
            var query = CustomPropertyCells.lazy_query.Value;
            return query.GetValues(page, shapeids, cvt);
        }
        
        public static List<CustomPropertyCells> GetCells(IVisio.Shape shape, CellValueType cvt)
        {
            var query = CustomPropertyCells.lazy_query.Value;
            return query.GetValues(shape, cvt);
        }

        private static readonly System.Lazy<CustomPropertyCellsReader> lazy_query = new System.Lazy<CustomPropertyCellsReader>();


        public class CustomPropertyCellsReader : ReaderMultiRow<CustomPropertyCells>
        {
            public SectionQueryColumn SortKey { get; set; }
            public SectionQueryColumn Ask { get; set; }
            public SectionQueryColumn Calendar { get; set; }
            public SectionQueryColumn Format { get; set; }
            public SectionQueryColumn Invis { get; set; }
            public SectionQueryColumn Label { get; set; }
            public SectionQueryColumn LangID { get; set; }
            public SectionQueryColumn Prompt { get; set; }
            public SectionQueryColumn Value { get; set; }
            public SectionQueryColumn Type { get; set; }

            public CustomPropertyCellsReader()
            {
                var sec = this.query.SectionQueries.Add(IVisio.VisSectionIndices.visSectionProp);


                this.SortKey = sec.Columns.Add(SrcConstants.CustomPropSortKey, nameof(SrcConstants.CustomPropSortKey));
                this.Ask = sec.Columns.Add(SrcConstants.CustomPropAsk, nameof(SrcConstants.CustomPropAsk));
                this.Calendar = sec.Columns.Add(SrcConstants.CustomPropCalendar, nameof(SrcConstants.CustomPropCalendar));
                this.Format = sec.Columns.Add(SrcConstants.CustomPropFormat, nameof(SrcConstants.CustomPropFormat));
                this.Invis = sec.Columns.Add(SrcConstants.CustomPropInvisible, nameof(SrcConstants.CustomPropInvisible));
                this.Label = sec.Columns.Add(SrcConstants.CustomPropLabel, nameof(SrcConstants.CustomPropLabel));
                this.LangID = sec.Columns.Add(SrcConstants.CustomPropLangID, nameof(SrcConstants.CustomPropLangID));
                this.Prompt = sec.Columns.Add(SrcConstants.CustomPropPrompt, nameof(SrcConstants.CustomPropPrompt));
                this.Type = sec.Columns.Add(SrcConstants.CustomPropType, nameof(SrcConstants.CustomPropType));
                this.Value = sec.Columns.Add(SrcConstants.CustomPropValue, nameof(SrcConstants.CustomPropValue));

            }

            public override CustomPropertyCells CellDataToCellGroup(VisioAutomation.Utilities.ArraySegment<string> row)
            {
                var cells = new CustomPropertyCells();
                cells.Value = row[this.Value];
                cells.Calendar = row[this.Calendar];
                cells.Format = row[this.Format];
                cells.Invisible = row[this.Invis];
                cells.Label = row[this.Label];
                cells.LangID = row[this.LangID];
                cells.Prompt = row[this.Prompt];
                cells.SortKey = row[this.SortKey];
                cells.Type = row[this.Type];
                cells.Ask = row[this.Ask];
                return cells;
            }
        }

    }
}