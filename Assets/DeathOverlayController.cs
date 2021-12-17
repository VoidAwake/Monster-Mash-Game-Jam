using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathOverlayController : MonoBehaviour
{
    [SerializeField] private Button retryButton;
    [SerializeField] private GameObject overlay;

    private OxygenTank oxygenTank;

    void Start()
    {
        oxygenTank = FindObjectOfType<OxygenTank>();

        oxygenTank.playerDeath.AddListener(OnPlayerDeath);

        retryButton.onClick.AddListener(OnRetryButtonClicked);
    }

    private void OnPlayerDeath ()
    {
        overlay.SetActive(true);
    }

    public void OnRetryButtonClicked()
    {
        // TODO: Reset scene
        SceneManager.LoadScene(0);
    }
}
