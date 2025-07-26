using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;

 /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
public static class SetsAndMaps
{
    /// <summary>
    /// Finds all symmetric word pairs in a given array of 2-character words.
    /// For example: "am" and "ma" are symmetric.
    /// Skips words with identical characters like "aa".
    /// </summary>
    /// <param name="words">An array of lowercase, 2-character words with no duplicates.</param>
    /// <returns>Array of formatted strings showing matching symmetric pairs.</returns>

public static string[] FindPairs(string[] words)
{
    HashSet<string> wordSet = new(words);
    HashSet<string> matched = new();
    List<string> result = new(words.Length / 2); // preallocate capacity

    foreach (string word in words)
    {
        char a = word[0], b = word[1];
        if (a == b) continue; // skip same-letter words like "aa"

        string reversed = new string(new[] { b, a });

        if (wordSet.Contains(reversed) && !matched.Contains(reversed))
        {
            result.Add($"{word} & {reversed}");
            matched.Add(word);
        }
    }

    return result.ToArray();
}


    /// <summary>
    /// Reads a CSV census file and summarizes how many people have each degree.
    /// The degree is found in the 4th column (index 3) of the file.
    /// </summary>
    /// <param name="filename">Path to the census CSV file.</param>
    /// <returns>A dictionary where the key is the degree and the value is the count.</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');
            if (fields.Length < 4) continue;

            string degree = fields[3].Trim();
            if (degrees.ContainsKey(degree))
                degrees[degree]++;
            else
                degrees[degree] = 1;
        }

        return degrees;
    }

    /// <summary>
    /// Determines if two words are anagrams (contain the same letters in the same quantities),
    /// ignoring spaces and letter case.
    /// </summary>
    /// <param name="word1">First word to compare.</param>
    /// <param name="word2">Second word to compare.</param>
    /// <returns>True if the words are anagrams, false otherwise.</returns>
    public static bool IsAnagram(string word1, string word2)
    {
        var cleaned1 = word1.Replace(" ", "").ToLower();
        var cleaned2 = word2.Replace(" ", "").ToLower();

        if (cleaned1.Length != cleaned2.Length)
            return false;

        var count = new Dictionary<char, int>();

        foreach (char c in cleaned1)
        {
            if (!count.ContainsKey(c))
                count[c] = 0;
            count[c]++;
        }

        foreach (char c in cleaned2)
        {
            if (!count.ContainsKey(c))
                return false;

            count[c]--;
            if (count[c] < 0)
                return false;
        }

        return true;
    }

    /// <summary>
    /// Retrieves a summary of all earthquakes from today using the USGS GeoJSON feed.
    /// Each summary includes the location and magnitude of the earthquake.
    /// </summary>
    /// <returns>An array of strings in the format "Place - Mag X.XX".</returns>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);
        var summary = new List<string>();

        foreach (var feature in featureCollection.Features)
        {
            if (feature.Properties.Place != null && feature.Properties.Mag != null)
            {
                summary.Add($"{feature.Properties.Place} - Mag {feature.Properties.Mag:F2}");
            }
        }


   // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return summary.ToArray();
    }
}

