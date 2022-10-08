using System.Collections.Generic;
using UnityEngine;

public class FallShapeFactory : IShapeFactory
{
    [SerializeField] private List<ColliderObject> _prefabs;
    private float _speed;

    public FallShapeFactory(List<ColliderObject> prefabs, float speed)
    {
        _prefabs = prefabs;
        _speed = speed;
    }

    public Shape GetShape(Vector2 position)
    {
        var index = Random.Range(0, _prefabs.Count);
        var collider = GameObject.Instantiate(_prefabs[index]);
        return new Shape(new FallMove(position, _speed), collider);
    }
}