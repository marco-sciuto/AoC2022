var lines = File.ReadLinesAsync("input");
var part1 = 0;
var part2 = 0;
var i = 0;
var group = new string[3];
await foreach (var line in lines)
{
    var first = line.Take(line.Length / 2);
    var second = line.TakeLast(line.Length / 2);
    var common = first.FirstOrDefault(c => second.Contains(c));
    part1 = AddPriority(part1, common);
    group[i] = line;
    i++;
    if (i == 3)
    {
        var commons = group[0].Where(c => group[1].Contains(c));
        common = group[2].FirstOrDefault(c => commons.Contains(c));
        part2 = AddPriority(part2, common);
        i = 0;
    }
}

Console.WriteLine($"Part 1 {part1}");
Console.WriteLine($"Part 2 {part2}");

static int AddPriority(int part1, char common)
{
    part1 += char.IsLower(common) ? common - 'a' + 1 : common - 'A' + 27;
    return part1;
}