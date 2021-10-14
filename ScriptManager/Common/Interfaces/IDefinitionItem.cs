namespace Common.Interfaces
{
    public interface IDefinitionItem
    {
        string Name { get; set; }
        string IconPath { get; set; }
        string Label { get; set; }
        string Category { get; set; }
        string Path { get; set; }
        string ScriptFileName { get; set; }
    }
}
