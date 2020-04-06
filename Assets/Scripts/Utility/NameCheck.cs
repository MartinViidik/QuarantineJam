using System.Text.RegularExpressions;

public static class NameCheck
{
    private static string errorMessage;
    public static bool IsValid(string input)
    {
        if(CheckLength(input, 4, 12) && CheckSpecialCharacters(input))
        {
            return true;
        } else {
            return false;
        }
    }
    static bool CheckLength(string input, int minLength, int maxLength)
    {
        if(input.Length <= minLength)
        {
            errorMessage = "Not long enough";
            return false;
        }
        if(input.Length >= maxLength)
        {
            errorMessage = "Too long";
            return false;
        }
        return true;
    }
    static bool CheckSpecialCharacters(string input)
    {
        if(Regex.IsMatch(input, ("[^a-zA-Z0-9_.]+")))
        {
            errorMessage = "No special characters";
            return false;
        } else {
            return true;
        }
    }
    public static string SendError()
    {
        return errorMessage;
    }
}
