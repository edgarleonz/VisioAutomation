﻿using IVisio = Microsoft.Office.Interop.Visio;

public static partial class VS2010_CSharp_Samples
{
    public static void Shape_GetFormulas(IVisio.Document doc)
    {
        var page = VisioInterop.Util.CreateStandardPage(doc, "SGF");
        var shape = VisioInterop.Util.CreateStandardShape(page);
        var request = VisioInterop.Util.Create_SGF_Request();

        // MAP THE REQUEST TO THE STRUCTURES VISIO EXPECTS
        var SRCStream = new short[request.Length*3];
        for (int i = 0; i < request.Length; i++)
        {
            SRCStream[i*3 + 0] = request[i].CellSRC.SectionIndex;
            SRCStream[i*3 + 1] = request[i].CellSRC.RowIndex;
            SRCStream[i*3 + 2] = request[i].CellSRC.CellIndex;
        }

        // EXECUTE THE REQUEST
        System.Array formulas_sa;
        shape.GetFormulasU(SRCStream, out formulas_sa);

        // MAP OUTPUT BACK TO SOMETHING USEFUL 
        var formulas = new string[formulas_sa.Length];
        formulas_sa.CopyTo(formulas, 0);

        // DISPLAY THE INFORMATION
        shape.Text = string.Format("Formulas={0},{1}", formulas[0], formulas[1]);
    }
}