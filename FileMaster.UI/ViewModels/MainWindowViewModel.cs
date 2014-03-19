using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMaster.UI.ViewModels
{
	public class MainWindowViewModel : GalaSoft.MvvmLight.ViewModelBase
	{
		public string Item { get { return GetPropertyName()} }
	}
}
