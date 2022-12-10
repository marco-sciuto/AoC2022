var elfs = new List<Elf>();
var lines = File.ReadLinesAsync("input");

Elf elf = CreateAdnAddElf(elfs);
await foreach (var line in lines)
{
    if (string.IsNullOrWhiteSpace(line))
    {
        elf = CreateAdnAddElf(elfs);
    }
    else
    {
        var calories = int.Parse(line);
        elf.calories += calories;
        elf.items++;
    }
}
Console.WriteLine($"Part 1: {elfs.Max(e => e.calories)}");

var top3 = elfs.OrderByDescending(e => e.calories).Take(3).Sum(e => e.calories);
Console.WriteLine($"Part 2: {top3}");

static Elf CreateAdnAddElf(List<Elf> elfs)
{
    var elf = new Elf();
    elfs.Add(elf);
    return elf;
}