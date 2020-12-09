//https://stackoverflow.com/questions/19581820/how-to-convert-json-array-to-list-of-objects-in-c-sharp
public class Wrapper
{
    [JsonProperty("JsonValues")]
    public ValueSet ValueSet { get; set; }
}

public class ValueSet
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("values")]
    public Dictionary<string, Value> Values { get; set; }
}

public class Value
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("diaplayName")]
    public string DisplayName { get; set; }
}

public static class JsonArrayToObjectList
{
    public static void Convert()
    {
        string jsonString = @"
        {
            ""JsonValues"": {
                ""id"": ""MyID"",
                ""values"": {
                    ""value1"": {
                        ""id"": ""100"",
                        ""diaplayName"": ""MyValue1""
                    },
                    ""value2"": {
                        ""id"": ""200"",
                        ""diaplayName"": ""MyValue2""
                    }
                }
            }
        }";

        var valueSet = JsonConvert.DeserializeObject<Wrapper>(jsonString).ValueSet;

        Console.WriteLine("id: " + valueSet.Id);
        foreach (KeyValuePair<string, Value> kvp in valueSet.Values)
        {
            Console.WriteLine(kvp.Key + " id: " + kvp.Value.Id);
            Console.WriteLine(kvp.Key + " name: " + kvp.Value.DisplayName);
        }
    }
}
