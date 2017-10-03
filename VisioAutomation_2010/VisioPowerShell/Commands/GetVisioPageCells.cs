﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using VisioPowerShell.Models;
using IVisio = Microsoft.Office.Interop.Visio;

namespace VisioPowerShell.Commands
{
    [Cmdlet(VerbsCommon.Get, VisioPowerShell.Commands.Nouns.VisioPageCells)]
    public class GetVisioPageCells: VisioCmdlet
    {
        [Parameter(Mandatory = false)]
        public IVisio.Page Page { get; set; }

        [Parameter(Mandatory = false)]
        public VisioPowerShell.Models.CellOutputType OutputType = VisioPowerShell.Models.CellOutputType.Formula;

        protected override void ProcessRecord()
        {
            var target_page = this.Page ?? this.Client.Page.Get();
            var celldic = VisioPowerShell.Models.BaseCells.GetDictionary(CellType.Page);
            var cells = celldic.Keys.ToArray();
            var query = _CreateQuery(celldic, cells);
            var surface = this.Client.ShapeSheet.GetShapeSheetSurface();
            var target_shapeids = new List<int> { target_page.PageSheet.ID };
            var dt = VisioPowerShell.Models.DataTableHelpers.QueryToDataTable(query, this.OutputType, target_shapeids, surface);
            this.WriteObject(dt);
        }

        private VisioAutomation.ShapeSheet.Query.CellQuery _CreateQuery(
            VisioPowerShell.Models.NamedCellDictionary celldic,
            IList<string> cells)
        {
            var invalid_names = cells.Where(cellname => !celldic.ContainsKey(cellname)).ToList();

            if (invalid_names.Count > 0)
            {
                string msg = "Invalid cell names: " + string.Join(",", invalid_names);
                throw new ArgumentException(msg);
            }

            var query = new VisioAutomation.ShapeSheet.Query.CellQuery();

            foreach (string cell in cells)
            {
                foreach (var resolved_cellname in celldic.ExpandKeyWildcard(cell))
                {
                    if (!query.Columns.Contains(resolved_cellname))
                    {
                        var resolved_src = celldic[resolved_cellname];
                        query.Columns.Add(resolved_src, resolved_cellname);
                    }
                }
            }

            return query;
        }
    }

}