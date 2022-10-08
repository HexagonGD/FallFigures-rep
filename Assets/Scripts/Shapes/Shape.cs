using System;
using UnityEngine;

public class Shape
{
    public event Action<Shape> ShapeCollectedEvent;
    public event Action<Shape> DestroyEvent;

    private readonly IMovable _movable;
    private readonly ColliderObject _collider;
    private float _lifeTime = 0;

    public Shape(IMovable movable, ColliderObject collider)
    {
        _movable = movable;
        _collider = collider;

        _collider.MouseDownEvent += OnMouseDownEvent;
    }

    public void Update(float deltaTime)
    {
        _lifeTime += deltaTime;
        _movable.Move(_lifeTime, _collider.transform);
    }

    public void Destroy()
    {
        if(_collider != null)
        {
            _collider.MouseDownEvent -= OnMouseDownEvent;
            GameObject.Destroy(_collider.gameObject);
        }
        DestroyEvent?.Invoke(this);
    }

    private void OnMouseDownEvent()
    {
        ShapeCollectedEvent?.Invoke(this);
    }
}