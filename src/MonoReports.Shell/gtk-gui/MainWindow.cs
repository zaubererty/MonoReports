
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::MonoReports.Gui.Widgets.MonoreportsDesignerControl monoreportsdesignercontrol2;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Monoreports pre");
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.monoreportsdesignercontrol2 = new global::MonoReports.Gui.Widgets.MonoreportsDesignerControl ();
		this.monoreportsdesignercontrol2.Events = ((global::Gdk.EventMask)(256));
		this.monoreportsdesignercontrol2.Name = "monoreportsdesignercontrol2";
		this.Add (this.monoreportsdesignercontrol2);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1082;
		this.DefaultHeight = 759;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
	}
}
