using UnityEngine;

public class SinMove : IMovable
{
    private readonly Vector2 _startPoint;
    private readonly float _speed;
    private readonly float _amplitude;

    public SinMove(Vector2 startPoint, float speed, float amplitude)
    {
        _startPoint = startPoint;
        _speed = speed;
        _amplitude = amplitude;
    }

    public void Move(float totalTime, Transform transform)
    {
        var x = _startPoint.x + Mathf.Sin(totalTime * _speed) * _amplitude;
        var y = _startPoint.y - _speed * totalTime;
        transform.position = new Vector3(x, y, 0);
    }
}