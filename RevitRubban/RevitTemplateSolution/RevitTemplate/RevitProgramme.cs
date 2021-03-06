﻿using System;
using System.Reflection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using RevitTemplate.view;

namespace RevitTemplate
{
    [Transaction(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    class RevitProgramme : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication a)
        {
            a.CreateRibbonTab("KeepTrack");

            RibbonPanel AECPanelDebug
              = a.CreateRibbonPanel("KeepTrack", "KeepTrack");

            string path = Assembly.GetExecutingAssembly().Location;

            #region DockableWindow
            PushButtonData pushButtonRegisterDockableWindow = new PushButtonData("RegisterDockableWindow", "RegisterDockableWindow", path, "RevitTemplate.RegisterDockableWindow");
            //pushButtonRegisterDockableWindow.LargeImage = GetImage(green.GetHbitmap());
            pushButtonRegisterDockableWindow.AvailabilityClassName = "RevitTemplate.AvailabilityNoOpenDocument";
            PushButtonData pushButtonShowDockableWindow = new PushButtonData("Show DockableWindow", "Show DockableWindow", path, "RevitTemplate.ShowDockableWindow");
            PushButtonData pushButtonHideDockableWindow = new PushButtonData("Hide DockableWindow", "Hide DockableWindow", path, "RevitTemplate.HideDockableWindow");

            RibbonItem ri1 = AECPanelDebug.AddItem(pushButtonRegisterDockableWindow);
            RibbonItem ri2 = AECPanelDebug.AddItem(pushButtonShowDockableWindow);
            RibbonItem ri3 = AECPanelDebug.AddItem(pushButtonHideDockableWindow);
            #endregion

            return Result.Succeeded;
        }

        public Result OnShutdown(
          UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        private System.Windows.Media.Imaging.BitmapSource GetImage(
          IntPtr bm)
        {
            System.Windows.Media.Imaging.BitmapSource bmSource
              = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bm,
                IntPtr.Zero,
                System.Windows.Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());

            return bmSource;
        }
    }

    /// <summary>
    /// You can only register a dockable dialog in "Zero doc state"
    /// </summary>
    public class AvailabilityNoOpenDocument
      : IExternalCommandAvailability
    {
        public bool IsCommandAvailable(
          UIApplication a,
          CategorySet b)
        {
            if (a.ActiveUIDocument == null)
            {
                return true;
            }
            return false;
        }
    }

    /// <summary>
    /// Register your dockable dialog
    /// </summary>
    [Transaction(TransactionMode.Manual)]
    public class RegisterDockableWindow
      : IExternalCommand
    {
        MainPage m_MyDockableWindow = null;

        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            DockablePaneProviderData data
              = new DockablePaneProviderData();

            MainPage MainDockableWindow = new MainPage();

            m_MyDockableWindow = MainDockableWindow;


            data.FrameworkElement = MainDockableWindow
              as System.Windows.FrameworkElement;

            data.InitialState = new DockablePaneState();

            data.InitialState.DockPosition
              = DockPosition.Tabbed;

            data.InitialState.TabBehind = DockablePanes
              .BuiltInDockablePanes.ProjectBrowser;

            DockablePaneId dpid = new DockablePaneId(
              new Guid("{D7C963CE-B7CA-426A-8D51-6E8254D21157}"));

            commandData.Application.RegisterDockablePane(
              dpid, "AEC Dockable Window", MainDockableWindow
              as IDockablePaneProvider);

            commandData.Application.ViewActivated
              += new EventHandler<ViewActivatedEventArgs>(
                Application_ViewActivated);

            return Result.Succeeded;
        }

        void Application_ViewActivated(
          object sender,
          ViewActivatedEventArgs e)
        {
        }
    }

    /// <summary>
    /// Show dockable dialog
    /// </summary>
    [Transaction(TransactionMode.ReadOnly)]
    public class ShowDockableWindow : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            DockablePaneId dpid = new DockablePaneId(
              new Guid("{D7C963CE-B7CA-426A-8D51-6E8254D21157}"));

            DockablePane dp = commandData.Application
              .GetDockablePane(dpid);

            dp.Show();

            return Result.Succeeded;
        }
    }

    /// <summary>
    /// Hide dockable dialog
    /// </summary>
    [Transaction(TransactionMode.ReadOnly)]
    public class HideDockableWindow : IExternalCommand
    {
        public Result Execute(
          ExternalCommandData commandData,
          ref string message,
          ElementSet elements)
        {
            DockablePaneId dpid = new DockablePaneId(
              new Guid("{D7C963CE-B7CA-426A-8D51-6E8254D21157}"));

            DockablePane dp = commandData.Application
              .GetDockablePane(dpid);

            dp.Hide();
            return Result.Succeeded;
        }
    }
}
