using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MixShapeFactories : IShapeFactory
{
    private readonly List<IShapeFactory> _factories;

    public MixShapeFactories(params IShapeFactory[] factories)
    {
        _factories = factories.ToList();
    }

    public Shape GetShape(Vector2 position)
    {
        var index = Random.Range(0, _factories.Count);
        return _factories[index].GetShape(position);
    }
}