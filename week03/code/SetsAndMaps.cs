using System.Text.Json;

public static class SetsAndMaps
{
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
    public static string[] FindPairs(string[] words)
    {
        // TO DO Problem 1 - ADD YOUR CODE HERE
        // var listOfWords = new [] {"am", "at", "ma", "if", "fi"}; // Example list
        var checkingSet = new HashSet<string>();
        var matchingSet = new HashSet<string>();
        var returningList = new List<string>();
        
        // Add all the words to a set.  If they already match a word in the set, also add them to another set.
        foreach (string word in words)
        {
            if (checkingSet.Contains($"{word[1]}{word[0]}") && word[0] != word[1]) // reversed order, and check for same letters
                matchingSet.Add(word);
            checkingSet.Add(word);
        }

        // Add the matching pairs to a list to return.
        foreach (string word in matchingSet)
        {
            returningList.Add($"{word} & {word[1]}{word[0]}");
        }

        return returningList.ToArray(); // type problem without ToArray; Quick fix advises format: return [.. returningList];
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            // TO DO Problem 2 - ADD YOUR CODE HERE
            var degreeKind = fields[3]; // Don't use index 4 here.
            // While reading, add the items to the dictionary.
            if (degrees.ContainsKey(degreeKind))
            {
                degrees[degreeKind] += 1;
            }
            else
            {
                degrees[degreeKind] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 Os
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        // TO DO Problem 3 - ADD YOUR CODE HERE
        // Create a dictionary where, in a loop, each letter of the word argument becomes a key with incrementing value.
        var letterDictionary1 = new Dictionary<char, int> ();
        var letterDictionary2 = new Dictionary<char, int> ();

        foreach (char a in word1)
        {if (a != ' ')
            {if (letterDictionary1.ContainsKey(char.ToLower(a)))
                letterDictionary1[char.ToLower(a)] += 1;
            else letterDictionary1[char.ToLower(a)] = 1;}}

        foreach (char b in word2)
        {if (b != ' ')
            {if (letterDictionary2.ContainsKey(char.ToLower(b)))
                letterDictionary2[char.ToLower(b)] += 1;
            else letterDictionary2[char.ToLower(b)] = 1;}}

        return letterDictionary1.Count == letterDictionary2.Count &&
            letterDictionary1.Keys.All(key => letterDictionary2.ContainsKey(key) &&       // checks conditions for all of the
                                       letterDictionary1[key] == letterDictionary2[key]); // elements in the Keys collection
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found
    /// at this website:
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
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

        // TO DO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magnitude.
        // 3. Return an array of these string descriptions.
        
        List<string> earthquakeList = new List<string>(); // or just: new(); or [];

        foreach (var feature in featureCollection.Features)
        {
            double mag = feature.Properties.Mag;
            string place = feature.Properties.Place;
            earthquakeList.Add($"{place} - Mag {mag},");
        }

        return earthquakeList.ToArray();
    }
}