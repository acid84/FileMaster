using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace FileMaster.Domain
{
	
	public class SettingsManager
	{
		private const string SETTINGS_FILE = "settings.dat";

		public Settings GetSettings()
		{
			if (!File.Exists(SETTINGS_FILE))
			{
				return null;
			}

			using (FileStream stream = File.OpenRead(SETTINGS_FILE))
			{
				XmlSerializer serializer = new XmlSerializer(typeof (Settings));
				return serializer.Deserialize(stream) as Settings;
			}
		}

		public void SaveSettings(Settings settings)
		{
			if (File.Exists(SETTINGS_FILE))
			{
				File.Delete(SETTINGS_FILE);
			}

			using (FileStream stream = File.OpenWrite(SETTINGS_FILE))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Settings));
				serializer.Serialize(stream, settings);
			}
		}
	}

	

	[DataContract]
	public class Settings
	{
		[DataMember]
		public string DestinationFolder { get; set; }
		[DataMember]
		public string TorrentFileFolder { get; set; }
		[DataMember]
		public string WorkingFolder { get; set; }
	}
}
