using Autodesk.Revit.UI;
using RevitTemplate.Logic;
using RevitTemplate.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RevitTemplate.view
{
    /// <summary>
    /// Logique d'interaction pour MainPage.xaml
    /// </summary>
    public partial class MainPage : Page, Autodesk.Revit.UI.IDockablePaneProvider
    {
        #region Data
        private Guid m_targetGuid;
        private DockPosition m_position = DockPosition.Bottom;
        private int m_left = 1;
        private int m_right = 1;
        private int m_top = 1;
        private int m_bottom = 1;
        #endregion

        private EntryPage entryPage = new EntryPage() ;
        private StatusPage statusPage = new StatusPage();
        public Connect connectPage = new Connect();
        public Synchronisation synchronisationPage = new Synchronisation();
        public Accueil1 accueilPage = new Accueil1();


        private ViewModel viewModel;

        public MainPage()
        {
            InitializeComponent();
            viewModel = new ViewModel(this);
            this.DataContext = viewModel;
            entryPage.DataContext = viewModel;
            statusPage.DataContext = viewModel;
            connectPage.DataContext = viewModel;
            synchronisationPage.DataContext = viewModel;
            accueilPage.DataContext = viewModel;
        }
        public void SetupDockablePane(Autodesk.Revit.UI.DockablePaneProviderData data)
        {
            data.FrameworkElement = this as FrameworkElement;
            data.InitialState = new Autodesk.Revit.UI.DockablePaneState();
            data.InitialState.DockPosition = DockPosition.Tabbed;
            data.InitialState.TabBehind = Autodesk.Revit.UI.DockablePanes.BuiltInDockablePanes.ProjectBrowser;
        }
        public void SetInitialDockingParameters(int left, int right, int top, int bottom, DockPosition position, Guid targetGuid)
        {
            m_position = position;
            m_left = left;
            m_right = right;
            m_top = top;
            m_bottom = bottom;
            m_targetGuid = targetGuid;
        }

        public void ShowStatusPage(string displayText)
        {
            statusPage.txtStatus.Text = displayText;
            Main.Content = statusPage;
        }

        public void ShowEntryPage()
        {
            entryPage.txtAttendee.Text = "";
            entryPage.txtTicketCont.Password = "";
            Main.Content = entryPage;
        }
    }
}

