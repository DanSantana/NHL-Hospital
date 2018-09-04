using System;

namespace NLHospitalLibrary
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class CurrentUser
	{
		private string user;

		public string UserName
		{
			get
			{
				return user;
			}
			set
			{
				user = value;
			}
		}

		public CurrentUser()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public CurrentUser(string userID)
		{
			UserName = userID;
		}
	}
}
