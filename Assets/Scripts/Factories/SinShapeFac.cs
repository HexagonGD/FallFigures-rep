using System.Collections.Generic;
using UnityEngine;

public class SinShapeFactory : IShapeFactory
{
    private List<ColliderObject> _prefabs;
    private float _speed;
    private float _amplitude;

    public SinShapeFactory(List<ColliderObject> prefabs, float speed, float amplitude)
    {
        _prefabs = prefabs;
        _speed = speed;
        _amplitude = amplitude;
    }

    public Shape GetShape(Vector2 position)
    {
        var index = Random.Range(0, _prefabs.Count);
        var collider = GameObject.Instantiate(_prefabs[index]);
        return new Shape(new SinMove(position, _speed, _amplitude), collider);
    }
}