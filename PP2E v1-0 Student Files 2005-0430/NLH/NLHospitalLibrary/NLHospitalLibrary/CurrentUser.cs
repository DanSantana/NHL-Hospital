using System;

namespace NLHospitalLibrary
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class CurrentUser
    {
        private string user;
        public string userId
        {
            get { return user; }
            set { user = value; }
        }
        private string _userGroup;
        public string userGroup
        {
            get { return _userGroup; }
            set { _userGroup = value; }
        }
        public CurrentUser(string uId, string ugroup)
        {
            userId = uId;
            userGroup = ugroup;
        }
        public CurrentUser()
        {

        }
    }
}
