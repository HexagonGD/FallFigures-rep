using System;

public class Counter
{
    public event Action<uint> ValueChangedEvent;

    public uint Value { get; private set; } = 0;

    public void Add() => Add(1);

    public void Add(uint value)
    {
        Value += value;
        ValueChangedEvent?.Invoke(Value);
    }

    public void Reset()
    {
        Value = 0;
        ValueChangedEvent?.Invoke(Value);
    }
}