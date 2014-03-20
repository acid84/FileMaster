using System;
using System.IO;
using FileMaster.Domain;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FileMaster.UI.ViewModels
{
	public class SettingsViewViewModel : BaseViewModel
	{
		private SettingsManager _settingsManager;
		private readonly Action<bool> _closeAction;

		public string DestinationFolder
		{
			get { return Get(() => DestinationFolder); }
			set { Set(() => DestinationFolder, value); }
		}

		public string TorrentFileFolder
		{
			get { return Get(() => TorrentFileFolder); }
			set { Set(() => TorrentFileFolder, value); }
		}

		public string WorkingFolder
		{
			get { return Get(() => WorkingFolder); }
			set { Set(() => WorkingFolder, value); }
		}

		public RelayCommand SaveCommand { get; private set; }
		public RelayCommand CancelCommand { get; private set; }
		

		public SettingsViewViewModel(Action<bool> closeAction)
		{
			_settingsManager = new SettingsManager();
			Settings settings = _settingsManager.GetSettings();

			_closeAction = closeAction;
			SaveCommand = new RelayCommand(Save, CanBeSaved);
			CancelCommand = new RelayCommand(Cancel);

			if (settings != null)
			{
				DestinationFolder = settings.DestinationFolder;
				TorrentFileFolder = settings.TorrentFileFolder;
				WorkingFolder = settings.WorkingFolder;
			}
		}

		private void Cancel()
		{
			_closeAction(false);
		}

		private void Save()
		{
			SaveSettings();
			_closeAction(true);
		}

		private void SaveSettings()
		{
			Settings settings = new Settings();
			settings.DestinationFolder = DestinationFolder;
			settings.TorrentFileFolder = TorrentFileFolder;
			settings.WorkingFolder = WorkingFolder;

			
			_settingsManager.SaveSettings(settings);
		}

		private bool CanBeSaved()
		{
			if (string.IsNullOrEmpty(DestinationFolder) || string.IsNullOrEmpty(TorrentFileFolder) ||
			    string.IsNullOrEmpty(WorkingFolder))
			{
				return false;
			}
			
			return true;
		}
	}
}
