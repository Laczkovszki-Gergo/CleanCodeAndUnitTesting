using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Week04Homework.Source
{
    public class UserInputValidator
    {
        public bool ValidateUserInput(string input)
        {
            return IsInputValidLength(input) && IsInputValidCharacters(input);            
        }

        private bool IsInputValidLength(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length >= 5 && input.Length <= 20;
        }

        private bool IsInputValidCharacters(string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-Z0-9]+$");
        }

    }
}
