using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyLocalServiceHost
{
	class Program
	{
		static void Main(string[] args)
		{
			ServiceBase serviceToRun = new LocalServiceHost();
			ServiceBase.Run(serviceToRun);
		}
	}
}
