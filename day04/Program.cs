var lines = File.ReadLinesAsync("input");
var part1 = 0;
var part2 = 0;
await foreach (var line in lines)
{
    var areas = line.Split(',');
    var zone1 = areas[0].Split('-').Select(c => int.Parse(c));
    var zone2 = areas[1].Split('-').Select(c => int.Parse(c));
    if (IsIncluded(zone1, zone2) || IsIncluded(zone2, zone1))
    {
        part1++;
    }
    if (IsOverlapping(zone1, zone2) || IsOverlapping(zone2, zone1))
    {
        part2++;
    }
}

Console.WriteLine($"Part 1: {part1}");
Console.WriteLine($"Part 2: {part2}");

bool IsIncluded(IEnumerable<int> zoneA, IEnumerable<int> zoneB)
{
    if (zoneA.First() >= zoneB.First() && zoneA.Last() <= zoneB.Last())
    {
        return true;
    }
    return false;
}

bool IsOverlapping(IEnumerable<int> zoneA, IEnumerable<int> zoneB)
{
    return IsContained(zoneA.First(), zoneB) || IsContained(zoneA.Last(), zoneB);
}

bool IsContained(int point, IEnumerable<int> zone)
{
    if(point >= zone.First() && point <= zone.Last())
    {
        return true;
    }
    return false;
}