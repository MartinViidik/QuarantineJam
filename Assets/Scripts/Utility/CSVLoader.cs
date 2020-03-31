using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class CSVLoader : MonoBehaviour
{
    private TextAsset csv;
    private char lineSeperator = '\n';
    private char surround = '"';
    private string[] fieldSeperator = {"\",\""};

    public void LoadCSV()
    {
        csv = Resources.Load<TextAsset>("Localization/localisation");
    }
    public Dictionary<string, string>GetDictionaryValues(string attributeId)
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        string[] lines = csv.text.Split(lineSeperator);
        int attributeIndex = -1;
        string[] headers = lines[0].Split(fieldSeperator, System.StringSplitOptions.None);
        for(int i = 0; i< headers.Length; i++)
        {
            if (headers[i].Contains(attributeId))
            {
                attributeIndex = i;
                break;
            }
        }
        Regex CSVParser = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
        for(int i = 1; i<lines.Length; i++)
        {
            string line = lines[i];
            string[] fields = CSVParser.Split(line);
            for(int f=0; f<fields.Length; f++)
            {
                fields[f] = fields[f].TrimStart(' ', surround);
                fields[f] = fields[f].Replace(surround.ToString(), "");
            }
            if(fields.Length > attributeIndex)
            {
                var key = fields[0];
                if(dictionary.ContainsKey(key)) { continue; }
                var value = fields[attributeIndex];
                dictionary.Add(key, value);
            }
        }
        return dictionary;
    }
}
