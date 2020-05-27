using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitTemplate.Logic
{
    public abstract class UIState
    {
        public abstract string NameRightButton { get; }
        public abstract void EnterState(ViewModel viewModel);
        public abstract void Cancel(ViewModel viewModel);
        public abstract void Submit(ViewModel viewModel);
    }
}
