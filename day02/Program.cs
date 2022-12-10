var results = new int[3,3] {
{3, 6, 0},
{0, 3, 6},
{6, 0, 3}
};
var lines = File.ReadLinesAsync("input");
var part1 = 0;
var part2 = 0;
await foreach (var line in lines)
{
    // result
    part1 += results[FirstSymbol(line), SecondSymbol(line)];
    // shape
    part1 += SecondSymbol(line) + 1;

    // result
    part2 += SecondSymbol(line) * 3;
    //shape
    for (int i = 0; i < 3; i++)
    {
        if (results[FirstSymbol(line), i] == SecondSymbol(line) * 3)
        {
            part2 += i + 1;
        }
    }
}

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");

static int FirstSymbol(string line)
{
    return line.ElementAt(0) - 'A';
}

static int SecondSymbol(string line)
{
    return line.ElementAt(2) - 'X';
}