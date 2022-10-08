using System;
using System.Collections.Generic;

public class ShapeManager : IUpdate
{
    public event Action ShapeCollectedEvent;

    private List<Shape> _shapes = new List<Shape>();

    public void AddShape(Shape shape)
    {
        _shapes.Add(shape);
        shape.ShapeCollectedEvent += OnShapeCollected;
        shape.DestroyEvent += OnShapeDestroyed;

        if (_shapes.Count > 15)
            _shapes[0].Destroy();
    }

    public void ClearShape()
    {
        for (var i = _shapes.Count - 1; i >= 0; i--)
            _shapes[i].Destroy();
    }

    public void Update(float deltaTime)
    {
        _shapes.ForEach(x => x.Update(deltaTime));
    }

    private void OnShapeCollected(Shape shape)
    {
        ShapeCollectedEvent?.Invoke();
        shape.Destroy();
    }

    private void OnShapeDestroyed(Shape shape)
    {
        _shapes.Remove(shape);
        shape.ShapeCollectedEvent -= OnShapeCollected;
        shape.ShapeCollectedEvent -= OnShapeDestroyed;
    }
}