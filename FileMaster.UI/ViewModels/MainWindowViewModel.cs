using FileMaster.Domain;
using GalaSoft.MvvmLight;
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
	public class MainWindowViewModel : ViewModelBase
	{
		private string _monitorText;
		private bool _isMonitoring;
		private FileNotifier _fileNotifier;
		private Guid _notificationId;
		private Settings _settings;
		private SettingsManager _settingsManager;
		public ObservableCollection<string> LogRows { get; set; }
		public RelayCommand StartMonitoringCommand { get; set; }
		public RelayCommand ExitCommand { get; set; }
		public RelayCommand SettingsCommand { get; set; }


		
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
			_settingsManager = new SettingsManager();
			_settings = _settingsManager.GetSettings();

			MonitorText = "Start Monitoring";
			LogRows = new ObservableCollection<string>();
			AddLog("Application started.");
			ExitCommand = new RelayCommand(Exit);
			StartMonitoringCommand = new RelayCommand(StartMonitoring, () => _settings != null);
			SettingsCommand = new RelayCommand(OpenSettingsWindow);
		}

		private void OpenSettingsWindow()
		{
			SettingsView view = new SettingsView();
			SettingsViewViewModel vm = new SettingsViewViewModel(x =>
			{
				view.Close();

				if (x)
				{
					_settings = _settingsManager.GetSettings();					
				}
			});
			view.DataContext = vm;
			view.ShowDialog();
			
		}

		private void Exit()
		{
			Application.Current.Shutdown();
		}


		private void StartMonitoring()
		{
			if(!_isMonitoring)
			{
				AddLog("Starting to watch " + _settings.WorkingFolder);
				_fileNotifier = new FileNotifier();
				_fileNotifier.FileFound += _fileNotifier_FileFound;
				_notificationId = _fileNotifier.StartWatchingForFilesInFolder(_settings.WorkingFolder);

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
			Application.Current.Dispatcher.Invoke(() => LogRows.Add(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + ": " + text));
		}

	}
}
