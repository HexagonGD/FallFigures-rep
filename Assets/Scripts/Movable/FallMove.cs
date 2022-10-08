using UnityEngine;

public class FallMove : IMovable
{
    private readonly Vector2 _startPoint;
    private readonly float _speed;

    public FallMove(Vector2 startPoint, float speed)
    {
        _startPoint = startPoint;
        _speed = speed;
    }

    public void Move(float totalTime, Transform transform)
    {
        var x = _startPoint.x;
        var y = _startPoint.y - totalTime * _speed;
        transform.position = new Vector3(x, y, 0);
    }
}