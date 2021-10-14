namespace Common.Interfaces
{
    interface IDefinitionItem
    {
        string Name { get; set; }
        string IconPath { get; set; }
        string Label { get; set; }
        string Category { get; set; }

    }
}
