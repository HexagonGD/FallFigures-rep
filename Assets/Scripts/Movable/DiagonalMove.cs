using UnityEngine;

public class DiagonalMove : IMovable
{
    private readonly Vector2 _startPoint;
    private readonly float _speed;
    private readonly float _amplitude;

    public DiagonalMove(Vector2 startPoint, float speed, float amplitude)
    {
        _startPoint = startPoint;
        _speed = speed;
        _amplitude = amplitude;
    }

    public void Move(float totalTime, Transform transform)
    {
        var x = totalTime * _speed % (_amplitude * 4);
        x = x > _amplitude * 2 ? _amplitude * 4 - x : x;
        x -= _amplitude;
        x += _startPoint.x;
        var y = _startPoint.y - _speed * totalTime;
        transform.position = new Vector3(x, y, 0);
    }
}