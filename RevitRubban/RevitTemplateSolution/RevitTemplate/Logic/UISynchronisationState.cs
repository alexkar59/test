using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevitTemplate.Logic
{
    class UISynchronisationState : UIState
    {
        public override string NameRightButton => "Sync";

        public override void Cancel(ViewModel viewModel)
        {
           
        }

        public override void EnterState(ViewModel viewModel)
        {
            viewModel.StateName = "SynchronisationState";
            viewModel.MainPage.Main.Content = viewModel.MainPage.synchronisationPage;
        }

        public override void Submit(ViewModel viewModel)
        {
            MessageBox.Show("On est en UISyncState");
        }
    }
}
