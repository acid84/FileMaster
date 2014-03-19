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
using FileMaster.Domain;

namespace FileMaster.UI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			FileNotifier fileNotifier = new FileNotifier();
			fileNotifier.StartWatchingForFilesInFolder("D:\\Test");
		}

		protected override void OnDragEnter(DragEventArgs e)
		{
			base.OnDragEnter(e);
		}
	}
}
