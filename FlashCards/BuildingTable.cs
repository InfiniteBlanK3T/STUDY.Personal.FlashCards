using ConsoleTableExt;

namespace FlashCards
{
    public class BuildingTable
    {
        public void MakingStackTable(List<StacksManagement> list)
        {
            Console.Clear();
            var tableData = new List<List<object>> { };
            foreach (var data in list)
            {
                tableData.Add(new List<object> { data.Id, data.StackName });
            }

            ConsoleTableBuilder
                .From(tableData)
                .WithTitle($"Stack Table", ConsoleColor.Green, ConsoleColor.Black)
                .WithColumn("Id", "Stack Name")
                .WithMinLength(new Dictionary<int, int> {
                    { 1, 25 },
                    { 2, 25 }
                })
                .WithTextAlignment(new Dictionary<int, TextAligntment>
                {
                {2, TextAligntment.Right }
                })
                .WithCharMapDefinition(new Dictionary<CharMapPositions, char> {
                    {CharMapPositions.BottomLeft, '=' },
                    {CharMapPositions.BottomCenter, '=' },
                    {CharMapPositions.BottomRight, '=' },
                    {CharMapPositions.BorderTop, '=' },
                    {CharMapPositions.BorderBottom, '=' },
                    {CharMapPositions.BorderLeft, '|' },
                    {CharMapPositions.BorderRight, '|' },
                    {CharMapPositions.DividerY, '|' },
                })
                .WithHeaderCharMapDefinition(new Dictionary<HeaderCharMapPositions, char> {
                    {HeaderCharMapPositions.TopLeft, '=' },
                    {HeaderCharMapPositions.TopCenter, '=' },
                    {HeaderCharMapPositions.TopRight, '=' },
                    {HeaderCharMapPositions.BottomLeft, '|' },
                    {HeaderCharMapPositions.BottomCenter, '-' },
                    {HeaderCharMapPositions.BottomRight, '|' },
                    {HeaderCharMapPositions.Divider, '|' },
                    {HeaderCharMapPositions.BorderTop, '=' },
                    {HeaderCharMapPositions.BorderBottom, '-' },
                    {HeaderCharMapPositions.BorderLeft, '|' },
                    {HeaderCharMapPositions.BorderRight, '|' },
                })
                .ExportAndWriteLine(TableAligntment.Center);
        }

        public void MakingCardTable(List<CardsManagement> list, string tableName)
        {
            Console.Clear();
            var tableData = new List<List<object>> { };
            foreach (var data in list)
            {
                tableData.Add(new List<object> { data.Id, data.CardFront, data.CardBack });
            }

            ConsoleTableBuilder
                .From(tableData)
                .WithTitle($"{tableName}", ConsoleColor.Green, ConsoleColor.Black)
                .WithColumn("Id", "Stack Name")
                .WithMinLength(new Dictionary<int, int> {
                    { 1, 25 },
                    { 2, 25 }
                })
                .WithTextAlignment(new Dictionary<int, TextAligntment>
                {
                {2, TextAligntment.Right }
                })
                .WithCharMapDefinition(new Dictionary<CharMapPositions, char> {
                    {CharMapPositions.BottomLeft, '=' },
                    {CharMapPositions.BottomCenter, '=' },
                    {CharMapPositions.BottomRight, '=' },
                    {CharMapPositions.BorderTop, '=' },
                    {CharMapPositions.BorderBottom, '=' },
                    {CharMapPositions.BorderLeft, '|' },
                    {CharMapPositions.BorderRight, '|' },
                    {CharMapPositions.DividerY, '|' },
                })
                .WithHeaderCharMapDefinition(new Dictionary<HeaderCharMapPositions, char> {
                    {HeaderCharMapPositions.TopLeft, '=' },
                    {HeaderCharMapPositions.TopCenter, '=' },
                    {HeaderCharMapPositions.TopRight, '=' },
                    {HeaderCharMapPositions.BottomLeft, '|' },
                    {HeaderCharMapPositions.BottomCenter, '-' },
                    {HeaderCharMapPositions.BottomRight, '|' },
                    {HeaderCharMapPositions.Divider, '|' },
                    {HeaderCharMapPositions.BorderTop, '=' },
                    {HeaderCharMapPositions.BorderBottom, '-' },
                    {HeaderCharMapPositions.BorderLeft, '|' },
                    {HeaderCharMapPositions.BorderRight, '|' },
                })
                .ExportAndWriteLine(TableAligntment.Center);
        }
    }
}
