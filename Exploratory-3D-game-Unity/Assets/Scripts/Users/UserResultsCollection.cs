using System;
using zm.Util;

namespace zm.Users
{
    /// <summary>
    /// Class holding collection of Users to enable serialization of List<User>
    /// </summary>
    [Serializable]
    public class UserResultsCollection : GenericSerializableCollection<UserResult>
    { }
}