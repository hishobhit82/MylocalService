using MyLocalEntities;
using MyLocalService;
using MyLocalServiceClient;
using MyWPFApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyWPFApp.Model
{
	public class PersonsModel : INotifyPropertyChanged
	{
		public PersonsModel(MainViewModel parent)
		{
			MainViewModel = parent;
			GetPersonsUri = ConfigurationManager.AppSettings["GetPersonsUri"];
			NumberOfPersonsToFetch = Convert.ToInt32(ConfigurationManager.AppSettings["DefaultPersons"]);
		}

		public MainViewModel MainViewModel { get; set; }

		private List<Person> _persons;
		public List<Person> Persons
		{
			get { return _persons; }
			set
			{
				_persons = value;
				OnPropertyChanged("Persons");
			}
		}

		public string GetPersonsUri { get; set; }

		private int _numbersOfPersonsToFetch;
		public int NumberOfPersonsToFetch
		{
			get
			{
				return _numbersOfPersonsToFetch;
			}
			set
			{
				_numbersOfPersonsToFetch = value;
				GetListOfPersons();
			}
		}

		private async void GetListOfPersons()
		{
			MainViewModel.ProgressBarInProgress = Visibility.Visible;

			await Task.Run(() =>
			{
				MainViewModel.StatusMessage = "Getting Persons...";
				string responseStream;
				try
				{
					responseStream = HttpWebClient.SendRequest($"{GetPersonsUri}{NumberOfPersonsToFetch}", "GET", null, null);
					var ser = new DataContractJsonSerializer(typeof(ServiceResult<Person>));
					MemoryStream ms = new MemoryStream(Encoding.Unicode.GetBytes(responseStream));
					var result = ser.ReadObject(ms) as ServiceResult<Person>;
					Persons = result.Result.ToList();
					MainViewModel.StatusMessage = "Finished getting list of persons.";
				}
				catch (Exception ex)
				{
					responseStream = "";
					Persons = new List<Person> { };
					MainViewModel.StatusMessage = ex.Message;
				}								
				MainViewModel.ProgressBarInProgress = Visibility.Hidden;				
			});

		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}
