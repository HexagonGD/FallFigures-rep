using System;
using UnityEngine;
using UnityEngine.UI;

public class UIController
{
    public event Action<bool> PauseChanged; 

    private readonly Button _pauseButton;
    private readonly Button _resumeButton;
    private readonly CanvasGroup _pausePanel;
    private readonly CanvasGroup _resumePanel;

    public UIController(Button pauseButton, Button resumeButton,
                        CanvasGroup pausePanel, CanvasGroup resumePanel)
    {
        _pauseButton = pauseButton;
        _resumeButton = resumeButton;
        _pausePanel = pausePanel;
        _resumePanel = resumePanel;

        _pauseButton.onClick.AddListener(OnPauseButtonClicked);
        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
    }

    private void OnPauseButtonClicked()
    {
        _resumePanel.alpha = 0;
        _pausePanel.alpha = 1;
        _resumePanel.interactable = false;
        _pausePanel.interactable = true;
        _pausePanel.blocksRaycasts = true;
        PauseChanged?.Invoke(true);
    }

    private void OnResumeButtonClicked()
    {
        _resumePanel.alpha = 1;
        _pausePanel.alpha = 0;
        _resumePanel.interactable = true;
        _pausePanel.interactable = false;
        _pausePanel.blocksRaycasts = false;
        PauseChanged?.Invoke(false);
    }
}