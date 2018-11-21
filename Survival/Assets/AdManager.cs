using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

// Android App ID
// ca-app-pub-7336770594939704~2094770057 

// iOS App ID
// ca-app-pub-7336770594939704~2815457808

public class AdManager : MonoBehaviour {

    [SerializeField] string gameID = "2918569";

    private GameObject player;

    void Awake() {
        Advertisement.Initialize(gameID, true);
    }

    private void OnEnable() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ShowAd(string zone = "") {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone))
            Advertisement.Show(zone, options);
    }

    void AdCallbackhandler(ShowResult result) {
        switch (result) {
            case ShowResult.Finished:
                ResetContinue();

                break;
            case ShowResult.Skipped:
                Debug.Log("Ad skipped. Son, I am dissapointed in you");
                break;
            case ShowResult.Failed:
                Debug.Log("I swear this has never happened to me before");
                break;
        }
    }

    IEnumerator WaitForAd() {
        float currentTimeScale = Time.timeScale;
        Time.timeScale = 0f;
        yield return null;

        while (Advertisement.isShowing)
            yield return null;

        Time.timeScale = currentTimeScale;
    }

    private void ResetContinue() {
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        GroundCheck platform = player.GetComponent<GroundCheck>();
        MyUIManager uiManager = GameObject.Find("Canvas").GetComponent<MyUIManager>();

        playerHealth.ResetHealth(player.GetComponent<PlayerData>());

        uiManager.ResetHealthUpdate();

        player.transform.position = new Vector3(platform.lastPlatform.transform.position.x, platform.lastPlatform.transform.position.y + 3.5f, platform.lastPlatform.transform.position.z);

        //Debug.Log(platform.lastPlatform.transform.position);

        GameOver gameOver = GameObject.Find("Canvas").GetComponent<GameOver>();
        gameOver.ContinueGame();

        Debug.Log(gameObject.name);
        gameObject.SetActive(false);
        

    }

}
