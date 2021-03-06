// 
// MainDesignView.cs
//  
// Author:
//       Tomasz Kubacki <Tomasz.Kubacki (at) gmail.com>
// 
// Copyright (c) 2010 Tomasz Kubacki 2010 - 2011
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using Gtk;
using MonoReports.Services;
using MonoReports.Core;
using MonoReports.ControlView;
using MonoReports.Model.Engine;
using MonoReports.Model;
using Cairo;
using Gdk;
using MonoReports.Extensions.CairoExtensions;
using System.Reflection;
using System.Collections.Generic;
using MonoReports.Model.Data;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Text;
using Mono.Unix;

namespace MonoReports.Gui.Widgets
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class MainDesignView : Gtk.Bin
	{
		DesignService designService;

		public DesignService DesignService {
			get {
				return this.designService;
			}
			set {				
				designService = value;
				if(designService != null) {
					designService.OnReportChanged += HandleDesignServiceOnReportChanged;
					 codeTextview.Buffer.Text = designService.Report.DataScript;
				}
			}
		}				
		
		bool initMode = false;

		void HandleDesignServiceOnReportChanged (object sender, EventArgs e)
		{		
			initMode = true;
			codeTextview.Buffer.Text = designService.Report.DataScript;		
			if ( this.designService.Report.DataSourceType == DataSourceType.CSharpDataScript)
				csharpRadiobutton.Active = true;
			else
				jsonRadiobutton.Active = true;
			initMode = false;
		}
		
		void HandleCodeTextviewBufferChanged (object sender, EventArgs e)
		{
			if(!initMode) {
				designService.Report.DataScript = codeTextview.Buffer.Text;
				designService.IsDirty = true;
			}
		}


		ReportRenderer reportRenderer;

		public ReportRenderer ReportRenderer {
			get {
				return this.reportRenderer;
			}
			set {
				reportRenderer = value;
			}
		}

		int pageNumber = 0;
		IWorkspaceService workSpaceService;

		public IWorkspaceService WorkSpaceService {
			get {
				return this.workSpaceService;
			}
			set {
				workSpaceService = value;
			}
		}

		ToolBarSpinButton pageSpinButton = null;
		 

		public DrawingArea DesignDrawingArea { 
			get { return drawingarea;}
		}

		public DrawingArea PreviewDrawingArea { 
			get { return previewDrawingArea;}
		}
		
		static Cairo.Color backgroundPageColor = new Cairo.Color(1,1,1);

		public MainDesignView ()
		{
			this.Build ();			
			buildPreviewToolbar ();
			reportRenderer = new ReportRenderer();
			Gtk.Drag.DestSet (DesignDrawingArea, DestDefaults.All, new TargetEntry[]{new TargetEntry ("Field", TargetFlags.OtherWidget,2)}, DragAction.Copy);
			codeTextview.Buffer.Changed += HandleCodeTextviewBufferChanged;
		
				
			DesignDrawingArea.DragDrop += delegate(object o, DragDropArgs args) {
					var source = Gtk.Drag.GetSourceWidget (args.Context);
						if (source.GetType () == typeof(TreeView)){
						TreeIter item;
						TreeView treeView = ((TreeView)source) as TreeView;
						treeView.Selection.GetSelected (out item);
					    var model = treeView.Model as Gtk.TreeStore;					
						var wrapper = model.GetValue (item, 0) as TreeItemWrapper;	 					
						Gtk.Drag.Finish (args.Context, true, false, 0);
					
						if(wrapper.Object is Field) {
							Field f = wrapper.Object as Field;
							designService.CreateTextBlockAtXY (f.Name,f.Name, f.FieldKind,args.X, args.Y);
						} else if(wrapper.Object is KeyValuePair<string,byte[]>) {
							var kvp = (KeyValuePair<string,byte[]>)wrapper.Object;
							designService.CreateImageAtXY(kvp.Key, args.X, args.Y);
						}  
					}
			};								
			
			previewDrawingArea.ModifyBg(Gtk.StateType.Normal,base.Style.Background (StateType.Insensitive));
			DesignDrawingArea.ModifyBg(Gtk.StateType.Normal,base.Style.Background (StateType.Insensitive));
			GuiStream error_stream = new GuiStream ("Error", (x, y) => Output (x, y));
			StreamWriter gui_output = new StreamWriter (error_stream);
			gui_output.AutoFlush = true;
			Console.SetError (gui_output);
			
			GuiStream stdout_stream = new GuiStream ("Stdout", (x, y) => Output (x, y));
			gui_output = new StreamWriter (stdout_stream);
			gui_output.AutoFlush = true;
			Console.SetOut (gui_output);
		 
		}
	
					
		public void Output (string kind, string s)
		{
			TextIter end = outputTextview.Buffer.EndIter;
			outputTextview.Buffer.InsertWithTagsByName (ref end, s, kind);
		}
	
		void buildPreviewToolbar ()
		{
			pageSpinButton = new ToolBarSpinButton (40, 1, 1, 1);
			pageSpinButton.SpinButton.ValueChanged += delegate(object sender, EventArgs e) {
				
				pageNumber = (int)(pageSpinButton.SpinButton.Value);
				pageNumber -= 1;
				previewDrawingArea.QueueDraw ();
			};
			
			ToolBarLabel pagelabel = new ToolBarLabel (Catalog.GetString("Page: "));
			previewToolbar.Insert (pagelabel, 0);
			previewToolbar.Insert (pageSpinButton, 1);
			
		}
		
		
		public void ShowPreview () {
			mainNotebook.Page = 1;
		}
		
		public void ShowDesign () {
			mainNotebook.Page = 0;
		}
		

		protected virtual void OnDrawingareaExposeEvent (object o, Gtk.ExposeEventArgs args)
		{
			if (designService != null) {
				DrawingArea area = (DrawingArea)o;
				Cairo.Context cr = Gdk.CairoHelper.Create (area.GdkWindow);
				cr.Antialias = Cairo.Antialias.Default;
				designService.RedrawReport (cr);
				area.SetSizeRequest ((int)(designService.Width* ReportRenderer.UnitMultipilier+3), (int)(designService.Height* ReportRenderer.UnitMultipilier+3));
				(cr as IDisposable).Dispose ();
			}
		}

		protected virtual void OnPreviewDrawingareaExposeEvent (object o, Gtk.ExposeEventArgs args)
		{
	
			DrawingArea area = (DrawingArea)o;
			if(designService.IsDirty)
				designService.ProcessReport();
			
			
			if (designService.Report.Pages.Count > 0 ) {
				Cairo.Context cr = Gdk.CairoHelper.Create (area.GdkWindow);
				cr.Antialias = Cairo.Antialias.Default;								 				 
				reportRenderer.Context  = cr;
				
				Cairo.Rectangle r = new Cairo.Rectangle (
					0,
					0,
					reportRenderer.UnitMultipilier * designService.Report.WidthWithMargins,
					reportRenderer.UnitMultipilier * designService.Report.HeightWithMargins
					);
				cr.Scale (designService.Zoom, designService.Zoom);			
				cr.FillRectangle (r,backgroundPageColor);				
				cr.Translate (designService.Report.Margin.Left * reportRenderer.UnitMultipilier ,designService.Report.Margin.Top * reportRenderer.UnitMultipilier  );
				reportRenderer.RenderPage (designService.Report.Pages [pageNumber]);
				area.SetSizeRequest ((int)(designService.Report.HeightWithMargins * designService.Zoom * ReportRenderer.UnitMultipilier),(int) (designService.Report.HeightWithMargins * designService.Zoom * ReportRenderer.UnitMultipilier)+5);
			
				(cr as IDisposable).Dispose ();
			}
		}

		protected virtual void OnDrawingareaButtonPressEvent (object o, Gtk.ButtonPressEventArgs args)
		{
			
			if (designService.IsDesign) {
				DesignDrawingArea.GrabFocus();
				workSpaceService.Status (String.Format (Catalog.GetString("press x:{0} y:{1} | xroot:{2} yroot:{3}"), args.Event.X, args.Event.Y, args.Event.XRoot, args.Event.YRoot));
				
				int click = 1;
				if (args.Event.Type == EventType.TwoButtonPress)
					click = 2;
				
				designService.ButtonPress (args.Event.X, args.Event.Y, click);
				 
			}
			
		}

		protected virtual void OnDrawingareaMotionNotifyEvent (object o, Gtk.MotionNotifyEventArgs args)
		{
			
			if (designService.IsDesign) {
				designService.MouseMove (args.Event.X, args.Event.Y);
				workSpaceService.Status (String.Format (Catalog.GetString("move x:{0} y:{1}"),
					((args.Event.X / designService.Renderer.UnitMultipilier) / designService.Zoom).ToUnitString(), ((args.Event.Y  / designService.Renderer.UnitMultipilier) / designService.Zoom).ToUnitString()));
			}
			
		}

		protected virtual void OnDrawingareaButtonReleaseEvent (object o, Gtk.ButtonReleaseEventArgs args)
		{
			if (designService.IsDesign) {
				designService.ButtonRelease (args.Event.X, args.Event.Y);
			}
		}

		protected virtual void OnMainNotebookSwitchPage (object o, Gtk.SwitchPageArgs args)
		{
			if (designService != null) {
				if (args.PageNum == 1) {
					designService.IsDesign = false;					
					pageSpinButton.SpinButton.SetRange (1, designService.Report.Pages.Count);
					previewDrawingArea.QueueDraw ();
				} else {
					designService.IsDesign = true;
					drawingarea.QueueDraw ();
				}
			}
		}
		
		protected virtual void OnDrawingareaKeyPressEvent (object o, Gtk.KeyPressEventArgs args)
		{			 
			DesignService.KeyPress(args.Event.Key);
		}
		
		protected virtual void OnDrawingareaKeyReleaseEvent (object o, Gtk.KeyReleaseEventArgs args)
		{
		}
 
		
		protected virtual void OnDrawingareaLeaveNotifyEvent (object o, Gtk.LeaveNotifyEventArgs args)
		{
		 	workSpaceService.SetCursor (Gdk.CursorType.LeftPtr);
		}
	
		protected virtual void OnJsonRadiobuttonClicked (object sender, System.EventArgs e)
		{
			if(!initMode)
			 	designService.Report.DataSourceType = DataSourceType.Json;
		}
		
		protected virtual void OnCsharpRadiobuttonClicked (object sender, System.EventArgs e)
		{
			if(!initMode)
			 	designService.Report.DataSourceType = DataSourceType.CSharpDataScript;
		}
 
	}
	
	/// <summary>
	/// Taken from GsSharp https://github.com/mono/mono-tools/blob/master/gsharp/Shell.cs
	/// </summary>
	public class GuiStream : Stream {
		string kind;
		Action<string,string> callback;

		public GuiStream (string k, Action<string, string> cb)
		{
			kind = k;
			callback = cb;
		}

		public override bool CanRead { get { return false; } }
		public override bool CanSeek { get { return false; } }
		public override bool CanWrite { get { return true; } }


		public override long Length { get { return 0; } } 
		public override long Position { get { return 0; } set {} }
		public override void Flush () { }
		public override int Read  ( byte[] buffer, int offset, int count) { return -1; }

		public override long Seek (long offset, SeekOrigin origin) { return 0; }

		public override void SetLength (long value) { }

		public override void Write (byte[] buffer, int offset, int count) {
			callback (kind, Encoding.UTF8.GetString (buffer, offset, count));
		}
	}
}

