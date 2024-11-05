
using System.Linq.Expressions;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{




    [Header("Panels")]
    [SerializeField] private GameObject inGamePanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject mainPanel;




    [Header("Button")]
    [SerializeField] public Button optionsButton;
    [SerializeField] public Button menuButton;
    [SerializeField] public Button optionsExitButton;
    [SerializeField] public Button menuOptionsButton;
    [SerializeField] public Button menuExitButton;
    [SerializeField] public Button menuPlayButton;


    [Header("Audio")]
    [SerializeField] private AudioSource audioSourceButton;

    [SerializeField] private TMP_Text lifeText;

    int value;


    private void Awake()
    {
        Time.timeScale = 1;
        optionsButton.onClick.AddListener(OnOptionsButtonClicked);
        optionsExitButton.onClick.AddListener(OnOptionsExitButtonClicked);
        menuOptionsButton.onClick.AddListener(OnMenuOptionsButtonClicked);
        menuExitButton.onClick.AddListener(OnMenuExitButtonClicked);
        menuPlayButton.onClick.AddListener(OnmenuPlayButtonClicked);
        menuButton.onClick.AddListener(OnMenuButtonClicked);



    }


    private void OnOptionsButtonClicked()
    {
        inGamePanel.SetActive(false);
        optionsPanel.SetActive(true);
        audioSourceButton.Play();
        Time.timeScale = 0;

    }
    private void OnMenuButtonClicked()
    {
        inGamePanel.SetActive(false);
        mainPanel.SetActive(true);
        audioSourceButton.Play();
        Time.timeScale = 0;

    }
    private void OnOptionsExitButtonClicked()
    {

        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        inGamePanel.SetActive(true);
        audioSourceButton.Play();
        Time.timeScale = 1;

    }
    private void OnmenuPlayButtonClicked()
    {
        mainPanel.SetActive(false);
        inGamePanel.SetActive(true);
        audioSourceButton.Play();
        Time.timeScale = 1;

    }
    private void OnMenuExitButtonClicked()
    {

        audioSourceButton.Play();
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif


    }
    private void OnMenuOptionsButtonClicked()
    {
        mainPanel.SetActive(false);
        optionsPanel.SetActive(true);
        audioSourceButton.Play();


    }




    private void OnDestroy()
    {

        optionsButton.onClick.RemoveAllListeners();
        optionsExitButton.onClick.RemoveAllListeners();
        menuOptionsButton.onClick.RemoveAllListeners();
        menuExitButton.onClick.AddListener(OnMenuExitButtonClicked);
        menuPlayButton.onClick.RemoveAllListeners();
        menuButton.onClick.RemoveAllListeners();
    }

}