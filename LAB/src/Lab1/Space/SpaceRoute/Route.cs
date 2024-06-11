using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab1.Space.SpaceRoute;

public class Route
{
    private List<RouteSegment> _segments;

    public Route()
    {
        _segments = new List<RouteSegment>();
    }

    public IReadOnlyCollection<RouteSegment> Segments => _segments;

    public void AddSegment(RouteSegment segment)
    {
        _segments.Add(segment);
    }
}