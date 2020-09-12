using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MyLocalService
{
	[DataContract]
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class ServiceResult<T>
	{
		[DataMember(Order = 1), JsonProperty]
		public T[] Result { get; set; }

		[DataMember(Order = 2), JsonProperty]
		public string Exception { get; set; }

		public ServiceResult(T[] result)
		{
			Result = result;
			Exception = string.Empty;
		}

		public ServiceResult(string exceptionMessage)
		{
			Result = new T[0];
			Exception = exceptionMessage;
		}

		public ServiceResult(Exception exception) : this(exception.Message)
		{
		}
	}
}