using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class App : MonoBehaviour
{
    [SerializeField] private List<ColliderObject> _prefabs;

    [SerializeField] private CanvasGroup _pausePanel;
    [SerializeField] private CanvasGroup _resumePanel;
    [SerializeField] private Button _pauseButton;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Text _text;

    private UIController _uiController;
    private Spawner _spawner;
    private ShapeManager _shapeManager;
    private Updater _updater;
    private Counter _counter;

    private void Awake()
    {
        var factory = new MixShapeFactories(
            new SinShapeFactory(_prefabs, 1f, 2f),
            new FallShapeFactory(_prefabs, 1f),
            new DiagonalShapeFactory(_prefabs, 1f, 2f),
            new SinShapeFactory(_prefabs, -1f, 2f)
            );

        _spawner = new Spawner(factory, 1.5f, 12f, -3f, 3f);
        _shapeManager = new ShapeManager();
        _counter = new Counter();
        _updater = new Updater(_spawner, _shapeManager);
        _uiController = new UIController(_pauseButton, _resumeButton, _pausePanel, _resumePanel);

        _spawner.ShapeCreatedEvent += _shapeManager.AddShape;
        _shapeManager.ShapeCollectedEvent += _counter.Add;
        _counter.ValueChangedEvent += (value) => { _text.text = value.ToString(); };
        _uiController.PauseChanged += _updater.SetPause;
    }

    private void Update()
    {
        _updater.Update(Time.deltaTime);
    }
}