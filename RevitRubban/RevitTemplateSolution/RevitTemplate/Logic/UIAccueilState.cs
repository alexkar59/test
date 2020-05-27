using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevitTemplate.Logic
{
    class UIAccueilState : UIState
    {

        public override string NameRightButton => "Continue";

        public override void Cancel(ViewModel viewModel)
        {
            viewModel.TransitionToState(new UILoginState());
        }

        public override void EnterState(ViewModel viewModel)
        {
            viewModel.StateName = "AccueilState";
            viewModel.MainPage.Main.Content = viewModel.MainPage.accueilPage;
        }

        public override void Submit(ViewModel viewModel)
        {
            viewModel.TransitionToState(new UIConnectState());
        }
    }
}
