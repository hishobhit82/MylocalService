using ServiceSettings;
using System;
using System.ServiceModel;
using System.ServiceProcess;
using MyLocalService;

namespace MyLocalServiceHost
{
	partial class LocalServiceHost : ServiceBase
	{
		ServiceHost svcHost = null;
		public LocalServiceHost()
		{
			InitializeComponent();
		}

		protected override void OnStart(string[] args)
		{
			string baseAddress = "http://" + Environment.MachineName + ":8081/MyLocalService";
			svcHost = new ServiceHost(typeof(MyLocalService.MyLocalService), new Uri(baseAddress));
			WebHttpBinding webBinding = new WebHttpBinding();
			webBinding.ContentTypeMapper = new RawMapper();
			svcHost.AddServiceEndpoint(typeof(IMyLocalService), webBinding, "api").Behaviors.Add(new NewtonsoftJsonBehavior());
			svcHost.Open();
		}

		protected override void OnStop()
		{
			if (svcHost != null)
			{
				svcHost.Close();
				svcHost = null;
			}
		}
	}
}