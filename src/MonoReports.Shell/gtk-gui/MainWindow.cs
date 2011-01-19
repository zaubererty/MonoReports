
// This file has been generated by the GUI designer. Do not modify.

public partial class MainWindow
{
	private global::Gtk.UIManager UIManager;
	private global::Gtk.Action copyAction;
	private global::Gtk.Action pasteAction;
	private global::Gtk.Action openAction;
	private global::Gtk.Action quitAction;
	private global::Gtk.Action FileAction;
	private global::Gtk.Action openAction1;
	private global::Gtk.Action newAction;
	private global::Gtk.Action fileAction;
	private global::Gtk.Action EditAction;
	private global::Gtk.Action ProjectAction;
	private global::Gtk.Action newAction1;
	private global::Gtk.Action openAction2;
	private global::Gtk.Action saveAction;
	private global::Gtk.Action saveAsAction;
	private global::Gtk.Action quitAction1;
	private global::Gtk.Action ViewAction;
	private global::Gtk.Action mediaPlayAction;
	private global::Gtk.Action undoAction;
	private global::Gtk.Action redoAction;
	private global::Gtk.Action cutAction;
	private global::Gtk.Action copyAction1;
	private global::Gtk.Action pasteAction1;
	private global::Gtk.Action deleteAction;
	private global::Gtk.Action zoomInAction;
	private global::Gtk.Action zoomOutAction;
	private global::Gtk.Action zoom100Action;
	private global::Gtk.Action HelpAction;
	private global::Gtk.Action aboutAction;
	private global::Gtk.VBox vbox2;
	private global::Gtk.MenuBar menubar3;
	private global::MonoReports.Gui.Widgets.MonoreportsDesignerControl monoreportsdesignercontrol1;

	protected virtual void Build ()
	{
		global::Stetic.Gui.Initialize (this);
		// Widget MainWindow
		this.UIManager = new global::Gtk.UIManager ();
		global::Gtk.ActionGroup w1 = new global::Gtk.ActionGroup ("Default");
		this.copyAction = new global::Gtk.Action ("copyAction", global::Mono.Unix.Catalog.GetString ("S_kopiuj"), null, "gtk-copy");
		this.copyAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("S_kopiuj");
		w1.Add (this.copyAction, null);
		this.pasteAction = new global::Gtk.Action ("pasteAction", global::Mono.Unix.Catalog.GetString ("Wk_lej"), null, "gtk-paste");
		this.pasteAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Wk_lej");
		w1.Add (this.pasteAction, null);
		this.openAction = new global::Gtk.Action ("openAction", global::Mono.Unix.Catalog.GetString ("_Otwórz"), null, "gtk-open");
		this.openAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Otwórz");
		w1.Add (this.openAction, null);
		this.quitAction = new global::Gtk.Action ("quitAction", global::Mono.Unix.Catalog.GetString ("Za_kończ"), null, "gtk-quit");
		this.quitAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Za_kończ");
		w1.Add (this.quitAction, null);
		this.FileAction = new global::Gtk.Action ("FileAction", global::Mono.Unix.Catalog.GetString ("File"), null, null);
		this.FileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.FileAction, null);
		this.openAction1 = new global::Gtk.Action ("openAction1", global::Mono.Unix.Catalog.GetString ("_Otwórz"), null, "gtk-open");
		this.openAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Otwórz");
		w1.Add (this.openAction1, null);
		this.newAction = new global::Gtk.Action ("newAction", global::Mono.Unix.Catalog.GetString ("_Nowy"), null, "gtk-new");
		this.newAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Nowy");
		w1.Add (this.newAction, null);
		this.fileAction = new global::Gtk.Action ("fileAction", global::Mono.Unix.Catalog.GetString ("File"), null, "gtk-file");
		this.fileAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("File");
		w1.Add (this.fileAction, null);
		this.EditAction = new global::Gtk.Action ("EditAction", global::Mono.Unix.Catalog.GetString ("Edit"), null, null);
		this.EditAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Edit");
		w1.Add (this.EditAction, null);
		this.ProjectAction = new global::Gtk.Action ("ProjectAction", global::Mono.Unix.Catalog.GetString ("Project"), null, null);
		this.ProjectAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Project");
		w1.Add (this.ProjectAction, null);
		this.newAction1 = new global::Gtk.Action ("newAction1", global::Mono.Unix.Catalog.GetString ("_Nowy"), null, "gtk-new");
		this.newAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Nowy");
		w1.Add (this.newAction1, null);
		this.openAction2 = new global::Gtk.Action ("openAction2", global::Mono.Unix.Catalog.GetString ("_Otwórz"), null, "gtk-open");
		this.openAction2.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Otwórz");
		w1.Add (this.openAction2, null);
		this.saveAction = new global::Gtk.Action ("saveAction", global::Mono.Unix.Catalog.GetString ("_Zapisz"), null, "gtk-save");
		this.saveAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Zapisz");
		w1.Add (this.saveAction, null);
		this.saveAsAction = new global::Gtk.Action ("saveAsAction", global::Mono.Unix.Catalog.GetString ("Zapi_sz jako"), null, "gtk-save-as");
		this.saveAsAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Zapi_sz jako");
		w1.Add (this.saveAsAction, null);
		this.quitAction1 = new global::Gtk.Action ("quitAction1", global::Mono.Unix.Catalog.GetString ("Za_kończ"), null, "gtk-quit");
		this.quitAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Za_kończ");
		w1.Add (this.quitAction1, null);
		this.ViewAction = new global::Gtk.Action ("ViewAction", global::Mono.Unix.Catalog.GetString ("View"), null, null);
		this.ViewAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Help");
		w1.Add (this.ViewAction, null);
		this.mediaPlayAction = new global::Gtk.Action ("mediaPlayAction", global::Mono.Unix.Catalog.GetString ("Execute"), null, "gtk-media-play");
		this.mediaPlayAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Execute");
		w1.Add (this.mediaPlayAction, "<Mod2>F5");
		this.undoAction = new global::Gtk.Action ("undoAction", global::Mono.Unix.Catalog.GetString ("Cof_nij"), null, "gtk-undo");
		this.undoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Cof_nij");
		w1.Add (this.undoAction, null);
		this.redoAction = new global::Gtk.Action ("redoAction", global::Mono.Unix.Catalog.GetString ("P_onów"), null, "gtk-redo");
		this.redoAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("P_onów");
		w1.Add (this.redoAction, null);
		this.cutAction = new global::Gtk.Action ("cutAction", global::Mono.Unix.Catalog.GetString ("_Wytnij"), null, "gtk-cut");
		this.cutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Wytnij");
		w1.Add (this.cutAction, "<Alt><Mod2>x");
		this.copyAction1 = new global::Gtk.Action ("copyAction1", global::Mono.Unix.Catalog.GetString ("S_kopiuj"), null, "gtk-copy");
		this.copyAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("S_kopiuj");
		w1.Add (this.copyAction1, "<Alt><Mod2>c");
		this.pasteAction1 = new global::Gtk.Action ("pasteAction1", global::Mono.Unix.Catalog.GetString ("Wk_lej"), null, "gtk-paste");
		this.pasteAction1.ShortLabel = global::Mono.Unix.Catalog.GetString ("Wk_lej");
		w1.Add (this.pasteAction1, "<Alt><Mod2>v");
		this.deleteAction = new global::Gtk.Action ("deleteAction", global::Mono.Unix.Catalog.GetString ("_Usuń"), null, "gtk-delete");
		this.deleteAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Usuń");
		w1.Add (this.deleteAction, null);
		this.zoomInAction = new global::Gtk.Action ("zoomInAction", global::Mono.Unix.Catalog.GetString ("Po_większ"), null, "gtk-zoom-in");
		this.zoomInAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Po_większ");
		w1.Add (this.zoomInAction, "<Control><Mod2>equal");
		this.zoomOutAction = new global::Gtk.Action ("zoomOutAction", global::Mono.Unix.Catalog.GetString ("Po_mniejsz"), null, "gtk-zoom-out");
		this.zoomOutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Po_mniejsz");
		w1.Add (this.zoomOutAction, "<Control><Mod2>minus");
		this.zoom100Action = new global::Gtk.Action ("zoom100Action", global::Mono.Unix.Catalog.GetString ("_Dopasowanie"), null, "gtk-zoom-100");
		this.zoom100Action.ShortLabel = global::Mono.Unix.Catalog.GetString ("_Dopasowanie");
		w1.Add (this.zoom100Action, "<Control><Mod2>Return");
		this.HelpAction = new global::Gtk.Action ("HelpAction", global::Mono.Unix.Catalog.GetString ("Help"), null, null);
		this.HelpAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("Help");
		w1.Add (this.HelpAction, null);
		this.aboutAction = new global::Gtk.Action ("aboutAction", global::Mono.Unix.Catalog.GetString ("_O programie"), null, "gtk-about");
		this.aboutAction.ShortLabel = global::Mono.Unix.Catalog.GetString ("_O programie");
		w1.Add (this.aboutAction, null);
		this.UIManager.InsertActionGroup (w1, 0);
		this.AddAccelGroup (this.UIManager.AccelGroup);
		this.Name = "MainWindow";
		this.Title = global::Mono.Unix.Catalog.GetString ("Monoreports 0.1");
		this.WindowPosition = ((global::Gtk.WindowPosition)(1));
		// Container child MainWindow.Gtk.Container+ContainerChild
		this.vbox2 = new global::Gtk.VBox ();
		this.vbox2.Name = "vbox2";
		this.vbox2.Spacing = 6;
		// Container child vbox2.Gtk.Box+BoxChild
		this.UIManager.AddUiFromString ("<ui><menubar name='menubar3'><menu name='fileAction' action='fileAction'><menuitem name='newAction1' action='newAction1'/><menuitem name='openAction2' action='openAction2'/><menuitem name='saveAction' action='saveAction'/><menuitem name='saveAsAction' action='saveAsAction'/><menuitem name='quitAction1' action='quitAction1'/></menu><menu name='EditAction' action='EditAction'><menuitem name='undoAction' action='undoAction'/><menuitem name='redoAction' action='redoAction'/><menuitem name='cutAction' action='cutAction'/><menuitem name='copyAction1' action='copyAction1'/><menuitem name='pasteAction1' action='pasteAction1'/><menuitem name='deleteAction' action='deleteAction'/></menu><menu name='ViewAction' action='ViewAction'><menuitem name='zoomInAction' action='zoomInAction'/><menuitem name='zoomOutAction' action='zoomOutAction'/><menuitem name='zoom100Action' action='zoom100Action'/></menu><menu name='ProjectAction' action='ProjectAction'><menuitem name='mediaPlayAction' action='mediaPlayAction'/></menu><menu name='HelpAction' action='HelpAction'><menuitem name='aboutAction' action='aboutAction'/></menu></menubar></ui>");
		this.menubar3 = ((global::Gtk.MenuBar)(this.UIManager.GetWidget ("/menubar3")));
		this.menubar3.Name = "menubar3";
		this.vbox2.Add (this.menubar3);
		global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.menubar3]));
		w2.Position = 0;
		w2.Expand = false;
		w2.Fill = false;
		// Container child vbox2.Gtk.Box+BoxChild
		this.monoreportsdesignercontrol1 = new global::MonoReports.Gui.Widgets.MonoreportsDesignerControl ();
		this.monoreportsdesignercontrol1.Events = ((global::Gdk.EventMask)(256));
		this.monoreportsdesignercontrol1.Name = "monoreportsdesignercontrol1";
		this.vbox2.Add (this.monoreportsdesignercontrol1);
		global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.monoreportsdesignercontrol1]));
		w3.Position = 2;
		this.Add (this.vbox2);
		if ((this.Child != null)) {
			this.Child.ShowAll ();
		}
		this.DefaultWidth = 1082;
		this.DefaultHeight = 759;
		this.Show ();
		this.DeleteEvent += new global::Gtk.DeleteEventHandler (this.OnDeleteEvent);
		this.openAction2.Activated += new global::System.EventHandler (this.OnOpenAction2Activated);
		this.saveAction.Activated += new global::System.EventHandler (this.OnSaveActionActivated);
		this.quitAction1.Activated += new global::System.EventHandler (this.OnQuitAction1Activated);
		this.mediaPlayAction.Activated += new global::System.EventHandler (this.OnMediaPlayActionActivated);
		this.copyAction1.Activated += new global::System.EventHandler (this.OnCopyAction1Activated);
		this.pasteAction1.Activated += new global::System.EventHandler (this.OnPasteAction1Activated);
		this.zoomInAction.Activated += new global::System.EventHandler (this.OnZoomInActionActivated);
		this.zoomOutAction.Activated += new global::System.EventHandler (this.OnZoomOutActionActivated);
		this.zoom100Action.Activated += new global::System.EventHandler (this.OnZoom100ActionActivated);
		this.aboutAction.Activated += new global::System.EventHandler (this.OnAboutActionActivated);
	}
}
