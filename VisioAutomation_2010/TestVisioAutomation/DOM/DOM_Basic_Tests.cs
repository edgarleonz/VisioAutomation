﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using VA = VisioAutomation;
using System.Linq;
using IVisio = Microsoft.Office.Interop.Visio;
using VisioAutomation.Extensions;

namespace TestVisioAutomation
{
    [TestClass]
    public class DOM_Basic_Tests : VisioAutomationTest
    {

        [TestMethod]
        public void DrawEmptyDOM()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            dompage.Size = new VA.Drawing.Size(5, 5);
            var page = dompage.Render(doc);

            Assert.AreEqual(0, page.Shapes.Count);
            Assert.AreEqual(new VA.Drawing.Size(5, 5), page.GetSize());

            page.Delete(0);
            doc.Close(true);
        }

        [TestMethod]
        public void DropLine()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var dom_line_0 = dompage.Shapes.DrawLine(1, 1, 3, 3);
            var page = dompage.Render(doc);

            Assert.AreEqual(1, page.Shapes.Count);
            Assert.AreNotEqual(0, dom_line_0.VisioShapeID);
            Assert.IsNotNull(dom_line_0.VisioShape);
            Assert.AreEqual(2.0, dom_line_0.VisioShape.CellsU["PinX"].Result[IVisio.VisUnitCodes.visNoCast]);
            page.Delete(0);
            doc.Close(true);
        }

        [TestMethod]
        public void DropBezier()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var dom_bez_0 = dompage.Shapes.DrawBezier(new double[] { 1, 2, 3, 3, 6, 3, 3, 4 });

            var page = dompage.Render(doc);

            Assert.AreEqual(1, page.Shapes.Count);
            Assert.AreNotEqual(0, dom_bez_0.VisioShapeID);
            Assert.IsNotNull(dom_bez_0.VisioShape);

            page.Delete(0);
            doc.Close(true);
        }

        [TestMethod]
        public void DropMaster()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var stencil = doc.Application.Documents.OpenStencil("basic_u.vss");
            var master1 = stencil.Masters["Rectangle"];

            var dom_master_0 = dompage.Shapes.Drop(master1, 3, 3);
            var dom_master_1 = dompage.Shapes.Drop("Rectangle", "basic_u.vss", 5, 5);

            var page = dompage.Render(doc);

            Assert.AreEqual(2, page.Shapes.Count);

            // Verify that the shapes created both have IDs and shape objects associated with them
            Assert.AreNotEqual(0, dom_master_0.VisioShapeID);
            Assert.AreNotEqual(0, dom_master_1.VisioShapeID);
            Assert.IsNotNull(dom_master_0.VisioShape);
            Assert.IsNotNull(dom_master_1.VisioShape);
            page.Delete(0);
            doc.Close(true);
        }

        [TestMethod]
        public void ShapeFormat()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var stencil = doc.Application.Documents.OpenStencil("basic_u.vss");
            var master1 = stencil.Masters["Rectangle"];

            var dom_master_0 = dompage.Shapes.Drop(master1, 3, 3);
            var dom_bez_0 = dompage.Shapes.DrawBezier(new double[] { 1, 2, 3, 3, 6, 3, 3, 4 });
            var dom_line_0 = dompage.Shapes.DrawLine(1, 1, 3, 3);

            dom_master_0.Cells.LineWeight = 0.1;
            dom_bez_0.Cells.LineWeight = 0.3;
            dom_line_0.Cells.LineWeight = 0.5;

            var page = dompage.Render(doc);

            Assert.AreEqual(3, page.Shapes.Count);
            page.Delete(0);
            doc.Close(true);
        }

        [TestMethod]
        public void Connect()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var basic_stencil = doc.Application.Documents.OpenStencil("basic_u.vss");
            var basic_masters = basic_stencil.Masters;

            var connectors_stencil = doc.Application.Documents.OpenStencil("connec_u.vss");
            var connectors_masters = connectors_stencil.Masters;

            var master1 = basic_masters["Rectangle"];
            var master2 = connectors_masters["Dynamic Connector"];

            var dom_master_0 = dompage.Shapes.Drop(master1, 3, 3);
            var dom_master_1 = dompage.Shapes.Drop(master1, 6, 5);
            var dc = dompage.Shapes.Connect(master2, dom_master_0, dom_master_1);

            var page = dompage.Render(doc);

            Assert.AreEqual(3, page.Shapes.Count);

            page.Delete(0);
            doc.Close(true);
        }

        [TestMethod]
        public void ConnectDeferred()
        {
            // Deferred means that the stencils (and thus masters) are loaded when rendering
            // and are no loaded by the caller before Render() is called

            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var dom_master_0 = dompage.Shapes.Drop("Rectangle", "basic_u.vss", 3, 3);
            var dom_master_1 = dompage.Shapes.Drop("Rectangle", "basic_u.vss", 6, 5);
            var dc = dompage.Shapes.Connect("Dynamic Connector", "connec_u.vss", dom_master_0, dom_master_1);
            var page = dompage.Render(doc);

            Assert.AreEqual(3, page.Shapes.Count);

            page.Delete(0);
            doc.Close(true);
        }
        
        [TestMethod]
        public void DropUnknownMaster()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var dom_master_0 = dompage.Shapes.Drop("RectangleXXX", "basic_u.vss", 3, 3);

            IVisio.Page page=null;
            bool caught = false;
            try
            {
                page = dompage.Render(doc);
            }
            catch (VA.AutomationException)
            {
                caught = true;
            }
            
            if (caught == false)
            {
                Assert.Fail("Expected an AutomationException");
            }
            
            if (page!=null)
            {
                page.Delete(0);
            }
            doc.Close(true);
        }


        [TestMethod]
        public void DropUnknownStencil()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var dom_master_0 = dompage.Shapes.Drop("RectangleXXX", "basic_uXXX.vss", 3, 3);

            IVisio.Page page = null;
            bool caught = false;
            try
            {
                page = dompage.Render(doc);
            }
            catch (VA.AutomationException)
            {
                caught = true;
            }
            
            if (caught == false)
            {
                Assert.Fail("Expected an AutomationException");
            }

            if (page!=null)
            {
                page.Delete(0);                
            }
            doc.Close(true);
        }

        [TestMethod]
        public void VerifyDropVersusDraw()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();
            var rect = new VA.Drawing.Rectangle(3, 4, 7, 8);
            var dropped_shape = dompage.Shapes.Drop("Rectangle", "basic_u.vss", rect);
            var drawn_shape = dompage.Shapes.DrawRectangle(rect);
            var page = dompage.Render(doc);

            var xfrms = VA.Layout.LayoutHelper.GetXForm(page,
                                                        new int[] {dropped_shape.VisioShapeID, drawn_shape.VisioShapeID});

            Assert.AreEqual(xfrms[1].PinX,xfrms[0].PinX);
            Assert.AreEqual(xfrms[1].PinY, xfrms[0].PinY);

            Assert.AreEqual(xfrms[1].Width, xfrms[0].Width);
            Assert.AreEqual(xfrms[1].Height, xfrms[0].Height);

            page.Delete(0);
            doc.Close(true);
        }

        [TestMethod]
        public void VerifyDropVersusDraw2()
        {
            var doc = this.GetNewDoc();
            var dompage = new VA.DOM.Page();

            var rect0 = new VA.Drawing.Rectangle(3, 4, 7, 8);
            var rect1 = new VA.Drawing.Rectangle(8, 1, 9, 5);
            var dropped_shape0 = dompage.Shapes.Drop("Rectangle", "basic_u.vss", rect0);
            var drawn_shape0 = dompage.Shapes.DrawRectangle(rect0);

            var dropped_shape1 = dompage.Shapes.Drop("Rectangle", "basic_u.vss", rect1);
            var drawn_shape1 = dompage.Shapes.DrawRectangle(rect1);

            var page = dompage.Render(doc);

            var xfrms = VA.Layout.LayoutHelper.GetXForm(page,
                                                        new int[] { dropped_shape0.VisioShapeID, 
                                                            drawn_shape0.VisioShapeID, 
                                                            dropped_shape1.VisioShapeID, 
                                                            drawn_shape1.VisioShapeID });

            Assert.AreEqual(xfrms[1].PinX, xfrms[0].PinX);
            Assert.AreEqual(xfrms[1].PinY, xfrms[0].PinY);

            Assert.AreEqual(xfrms[1].Width, xfrms[0].Width);
            Assert.AreEqual(xfrms[1].Height, xfrms[0].Height);

            Assert.AreEqual(xfrms[3].PinX,   xfrms[2].PinX);
            Assert.AreEqual(xfrms[3].PinY,   xfrms[2].PinY);
            Assert.AreEqual(xfrms[3].Width,  xfrms[2].Width);
            Assert.AreEqual(xfrms[3].Height, xfrms[2].Height);

            page.Delete(0);
            doc.Close(true);
        }
    }
}