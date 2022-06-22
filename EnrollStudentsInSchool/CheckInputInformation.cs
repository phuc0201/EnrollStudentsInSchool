using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace EnrollStudentsInSchool_
{
    public static class CheckInputInformation
    {
        public static bool CheckStringContainsSpecialCharacters(this TextBox txt)
        {
            for (int i = 0; i < txt.Text.Length; i++)
            {
                if (txt.Text[i] == '\\' || txt.Text[i] == '"')
                {
                    return false;
                }            
            }
            if (new Regex("[`~!@#$%^&*()\\-_+=|{}[\\]:;',.<>?/]").IsMatch(txt.Text))
            {
                return false;
            }
            return true;
        }
        public static bool CheckStringIsNumber(this TextBox txt)
        {
            if(new Regex("[^0-9]").IsMatch(txt.Text))
            {
                return false;
            }
            return true;
        }
        public static bool CheckStringIsNumberAndChar(this TextBox txt)
        {
            if(new Regex("[^0-9a-zA-Z]").IsMatch(txt.Text))
            {
                return false;
            }
            return true;
        }
        public static bool CheckAddress(this TextBox txt)
        {
            for (int i = 0; i < txt.Text.Length; i++)
            {
                if (txt.Text[i] == '\\' || txt.Text[i] == '"')
                {
                    return false;
                }
            }
            if (new Regex("[`~!@#$%^&*()\\-_+=|{}[\\]:;'.<>?]").IsMatch(txt.Text))
            {
                return false;
            }
            return true;
        }
        public static bool CheckInforInputIsEmpty(this Panel control)
        {
            foreach (Control txt in control. Controls)
            {
                if (txt is TextBox && (string)txt.Tag == "Infor")
                {
                    if (!(new Regex("[^' ']").IsMatch(txt.Text)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}