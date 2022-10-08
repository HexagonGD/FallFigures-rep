using System;
using UnityEngine;

public class Spawner : IUpdate
{
    public event Action<Shape> ShapeCreatedEvent;

    private readonly IShapeFactory _factory;
    private readonly float _delay;
    private readonly float _maxY;
    private readonly float _minX;
    private readonly float _maxX;
    private float _remainingTimeToSpawn;

    public Spawner(IShapeFactory factory, float delay,
        float maxY, float minX, float maxX)
    {
        _factory = factory;
        _delay = delay;
        _maxY = maxY;
        _minX = minX;
        _maxX = maxX;
    }

    public void Update(float deltaTime)
    {
        _remainingTimeToSpawn -= deltaTime;
        if(_remainingTimeToSpawn < 0)
        {
            var x = UnityEngine.Random.Range(_minX, _maxX);
            var shape = _factory.GetShape(new Vector2(x, _maxY));
            ShapeCreatedEvent?.Invoke(shape);
            _remainingTimeToSpawn = _delay;
        }
    }
}