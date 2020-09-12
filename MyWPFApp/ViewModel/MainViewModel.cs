using MyWPFApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWPFApp.ViewModel
{
	public class MainViewModel : INotifyPropertyChanged
	{
		public MainViewModel()
		{
			PersonsModel = new PersonsModel(this);
			ProgressBarInProgress = Visibility.Hidden;
		}

		private PersonsModel _personsModel;
		public PersonsModel PersonsModel
		{
			get { return _personsModel; }
			set
			{
				_personsModel = value;
				OnPropertyChanged("PersonsModel");
			}
		}

		private string _statusMessage;
		public string StatusMessage
		{
			get
			{
				return _statusMessage;
			}
			set
			{
				_statusMessage = value;
				OnPropertyChanged("StatusMessage");
			}
		}

		private Visibility _progressBarInProgress;
		public Visibility ProgressBarInProgress
		{
			get
			{
				return _progressBarInProgress;
			}
			set
			{
				_progressBarInProgress = value;
				OnPropertyChanged("ProgressBarInProgress");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}
