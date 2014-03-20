using FileMaster.Domain;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FileMaster.UI.ViewModels
{
	public class MainWindowViewModel : GalaSoft.MvvmLight.ViewModelBase
	{
		public ObservableCollection<string> LogRows { get; set; }
		public RelayCommand StartMonitoringCommand { get; set; }
		public RelayCommand ExitCommand { get; set; }
		public RelayCommand SettingsCommand { get; set; }


		private string _monitorText;
		private bool _isMonitoring = false;
		public string MonitorText
		{
			get
			{
				return _monitorText;
			}
			set
			{
				_monitorText = value;
				base.RaisePropertyChanged("MonitorText");
			}
		}

		public MainWindowViewModel()
		{
			MonitorText = "Start Monitoring";
			LogRows = new ObservableCollection<string>();
			AddLog("Application started.");
			ExitCommand = new RelayCommand(() => Exit());
			StartMonitoringCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() => StartMonitoring());
		}

		private void Exit()
		{
			Application.Current.Shutdown();
		}

		private FileNotifier _fileNotifier;
		private Guid _notificationId;
		private void StartMonitoring()
		{
			if(!_isMonitoring)
			{
				string folder = "C:\\Test";
				AddLog("Starting to watch " + folder);
				_fileNotifier = new FileNotifier();
				_fileNotifier.FileFound += _fileNotifier_FileFound;
				_notificationId = _fileNotifier.StartWatchingForFilesInFolder(folder);

				MonitorText = "Stop Monitoring";
				_isMonitoring = true;
			}
			else
			{

				AddLog("Monitoring is stopped.");
				_fileNotifier.StopWatching(_notificationId);
				_isMonitoring = false;
				MonitorText = "Start Monitoring";

			}
		}

		private void _fileNotifier_FileFound(object sender, FileFoundEventArgs e)
		{
			AddLog("Found file " + e.FileName);
		}

		private void AddLog(string text)
		{
			App.Current.Dispatcher.Invoke(() =>
			{
				LogRows.Add(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + ": " + text);
			});
		}

	}
}
