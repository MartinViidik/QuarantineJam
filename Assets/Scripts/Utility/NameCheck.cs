using System.Text.RegularExpressions;
using System.IO;
public static class NameCheck
{
    private static string errorMessage;
    private static string input;
    public static bool IsValid(string newInput)
    {
        input = newInput;
        if(CheckLength(1, 12) && CheckSpecialCharacters() && CheckProfanities())
        {
            return true;
        } else {
            return false;
        }
    }
    static bool CheckLength(int minLength, int maxLength)
    {
        if(input.Length <= minLength)
        {
            errorMessage = "notlongenough";
            return false;
        }
        if(input.Length >= maxLength)
        {
            errorMessage = "toolong";
            return false;
        }
        return true;
    }
    static bool CheckSpecialCharacters()
    {
        if(Regex.IsMatch(input, ("[^a-zA-Z0-9_.]+")))
        {
            errorMessage = "nospecialcharacters";
            return false;
        } else {
            return true;
        }
    }
    static bool CheckProfanities()
    {
        string path = "Assets/Resources/ProfanityFilter/profanities.txt";

        StreamReader reader = new StreamReader(path);
        string i = input.ToLower();
        while (reader.Peek() >= 0)
        {
            if(i.Contains(reader.ReadLine()))
            {
                errorMessage = "noprofanities";
                reader.Close();
                return false;
            }
        }
        reader.Close();
        return true;
    }
    public static string SendError()
    {
        return errorMessage;
    }
}
