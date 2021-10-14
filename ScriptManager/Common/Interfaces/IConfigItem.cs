namespace Common.Interfaces
{
    interface IConfigItem
    {
        string ConfigKey { get; set; }
        string Value { get; set; }
        string Type { get; set; }
    }
}
