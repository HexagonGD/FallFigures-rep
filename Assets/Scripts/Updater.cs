using System.Collections.Generic;
using System.Linq;

public class Updater : IUpdate
{
    private List<IUpdate> _updates = new List<IUpdate>();

    public bool Pause { get; set; } = false;

    public Updater() { }

    public Updater(params IUpdate[] updates)
    {
        _updates = updates.ToList();
    }

    public void Update(float deltaTime)
    {
        if (Pause) return;
        _updates.ForEach(x => x.Update(deltaTime));
    }

    public void SetPause(bool value)
    {
        Pause = value;
    }

    public void Add(IUpdate update)
    {
        _updates.Add(update);
    }

    public void Remove(IUpdate update)
    {
        _updates.Remove(update);
    }
}