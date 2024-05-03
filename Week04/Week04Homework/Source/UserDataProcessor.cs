using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week04Homework.Source
{
    public class UserDataProcessor
    {
    public string ProcessUserData(UserRequest userData)
    {
        if (userData.IsUserSearchRequested && userData.IsDataProcessingRequested)            
            return SearchForUser(userData.UserList, userData.SearchTerm);            
        else if (!userData.IsUserSearchRequested && userData.IsDataProcessingRequested)            
            return ProcessData(userData.ProcessingIterations);            
        else            
            return "No action taken.";            
    }
    private string SearchForUser(string[] userList, string searchTerm)
    {
        foreach (var user in userList)
        {
            if (user == searchTerm)                
                return $"User found: {searchTerm}";                
        }
        return "User not found.";
    }

    private string ProcessData(int iterations)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < iterations; i++)
        {
            result.Append("Processing... ");
        }
        return result.ToString();
    }
}
}
