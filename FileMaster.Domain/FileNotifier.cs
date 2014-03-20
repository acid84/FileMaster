using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace FileMaster.Domain
{
	public class FileFoundEventArgs : EventArgs
	{
		public string FilePath { get; set; }
		public string FileName { get; set; }
		
		public FileFoundEventArgs()
		{
			
		}

		public FileFoundEventArgs(string filePath, string fileName)
		{
			FilePath = filePath;
			FileName = fileName;
		}
	}

	public class FileNotifier
	{
		public event EventHandler<FileFoundEventArgs> FileFound;
		private readonly Dictionary<Guid, FileSystemWatcher> _fileSystemWatchers = new Dictionary<Guid, FileSystemWatcher>();

		public FileNotifier()
		{
		}

		public void StopWatching(Guid id)
		{
			FileSystemWatcher watcher;
			if(_fileSystemWatchers.TryGetValue(id, out watcher))
			{
				watcher.EnableRaisingEvents = false;
				watcher.Dispose();
				_fileSystemWatchers.Remove(id);
				watcher = null;
			}
		}

		public Guid StartWatchingForFilesInFolder(string folder)
		{
			Guid id = Guid.NewGuid();
			FileSystemWatcher watcher = new FileSystemWatcher(folder);
			_fileSystemWatchers.Add(id, watcher);
			watcher.Created += watcher_Created;
			watcher.Error += watcher_Error;
			watcher.Changed += watcher_Changed;
			// Start watching
			watcher.EnableRaisingEvents = true;

			return id;
		}

		void watcher_Changed(object sender, FileSystemEventArgs e)
		{
			Console.WriteLine("Changed");
		}

		void watcher_Error(object sender, ErrorEventArgs e)
		{
			Console.WriteLine("Error");
		}

		private void watcher_Created(object sender, FileSystemEventArgs e)
		{
			string filePath = e.FullPath;
			string fileName = e.Name;

			WaitUntilFileIsDone(filePath);
			OnFileFound(new FileFoundEventArgs(filePath, fileName));
		}

		private void WaitUntilFileIsDone(string filePath)
		{
			do
			{
				if (!IsFileLocked(new FileInfo(filePath)))
				{
					break;
				}
				Thread.Sleep(TimeSpan.FromSeconds(1));
			} while (true);
		}

		protected virtual void OnFileFound(FileFoundEventArgs e)
		{
			EventHandler<FileFoundEventArgs> handler = FileFound;
			if (handler != null) handler(this, e);
		}


		private bool IsFileLocked(FileInfo file)
		{
			FileStream stream = null;

			try
			{
				stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
			}
			catch (IOException)
			{
				return true;
			}
			finally
			{
				if (stream != null)
					stream.Close();
			}

			//file is not locked
			return false;
		}
	}
}
