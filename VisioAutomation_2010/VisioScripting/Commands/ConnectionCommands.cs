 using System.Collections.Generic;
using VisioAutomation.Shapes;
using VA = VisioAutomation;
using IVisio = Microsoft.Office.Interop.Visio;

namespace VisioScripting.Commands
{
    public class ConnectionCommands : CommandSet
    {
        internal ConnectionCommands(Client client) :
            base(client)
        {

        }
        /// <summary>
        /// Returns all the connected pairs of shapes in the active page
        /// </summary>
        /// <param name="flag"></param>
        /// <returns></returns>
        public List<VA.DocumentAnalysis.ConnectorEdge> GetTransitiveClosureOnActivePage(VA.DocumentAnalysis.ConnectorHandling flag)
        {
            var cmdtarget = this._client.GetCommandTargetPage();

            return VA.DocumentAnalysis.ConnectionAnalyzer.GetTransitiveClosure(cmdtarget.ActivePage, flag);
        }

        public List<VA.DocumentAnalysis.ConnectorEdge> GetDirectedEdgesOnActivePage(VA.DocumentAnalysis.ConnectorHandling flag)
        {
            var cmdtarget = this._client.GetCommandTargetPage();

            var directed_edges = VA.DocumentAnalysis.ConnectionAnalyzer.GetDirectedEdges(cmdtarget.ActivePage, flag);
            return directed_edges;
        }

        public List<IVisio.Shape> ConnectShapes(IList<IVisio.Shape> fromshapes, IList<IVisio.Shape> toshapes, IVisio.Master master)
        {
            var cmdtarget = this._client.GetCommandTargetPage();

            using (var undoscope = this._client.Undo.NewUndoScope(nameof(ConnectShapes)))
            {
                if (master == null)
                {
                    var connectors = ConnectorHelper.ConnectShapes(cmdtarget.ActivePage, fromshapes, toshapes, null, false);
                    return connectors;                    
                }
                else
                {
                    var connectors = ConnectorHelper.ConnectShapes(cmdtarget.ActivePage, fromshapes, toshapes, master);
                    return connectors;
                }
            }
        }
    }
}