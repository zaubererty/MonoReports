// 
// PointEditor.cs
//  
// Author:
//       tomek <${AuthorEmail}>
// 
// Copyright (c) 2010 tomek
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
using MonoReports.Model.Controls;
using PropertyGrid;
using MonoReports.Model;

namespace MonoReports.Extensions.PropertyGridEditors
{
	[PropertyEditorType (typeof (Thickness))]
	public class ThicknessEditorCell: PropertyEditorCell
	{
		protected override string GetValueText ()
		{
			return ((Thickness)Value).ToString ();
		}
		
		protected override IPropertyEditor CreateEditor (Gdk.Rectangle cell_area, Gtk.StateType state)
		{
			return new ThicknessEditor ();
		}
	}
	
	public class ThicknessEditor: Gtk.HBox, IPropertyEditor
	{
		Gtk.Entry entry;
		Thickness padding;
		
		public ThicknessEditor()
		{
			entry = new Gtk.Entry ();
			entry.Changed += OnChanged;
			entry.HasFrame = false;
			PackStart (entry, true, true, 0);
			ShowAll ();
		}
		
		public void Initialize (EditSession session)
		{
		}
		
		public object Value {
			get { return padding; }
			set {
				padding = (Thickness) value;
				entry.Changed -= OnChanged;
				entry.Text = String.Format("{0};{1};{2};{3}",padding.Left,padding.Top,padding.Right,padding.Bottom);
				entry.Changed += OnChanged;
			}
		}
		
		void OnChanged (object o, EventArgs a)
		{
			string s = entry.Text;
				try {
					if(s != null) {
					 
					    var doubles =  s.Split(';');
					 
					
						if (doubles.Length > 3) {							
					    	padding = new Thickness(UnitExtensions.FromString(doubles[0]),UnitExtensions.FromString(doubles[1]),UnitExtensions.FromString(doubles[2]),UnitExtensions.FromString(doubles[3])); 
						}else if ( doubles.Length == 1) {						
						    double v = UnitExtensions.FromString(doubles[0]);
							padding = new Thickness(v,v,v,v);
						}
					}
					if (ValueChanged != null)
						ValueChanged (this, a);
					
				} catch {
				}
			
		}
		
		public event EventHandler ValueChanged;
		
		 
	}
}

