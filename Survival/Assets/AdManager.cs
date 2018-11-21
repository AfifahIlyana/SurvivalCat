using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
//using GoogleMobileAds.Api;

// Android App ID
// ca-app-pub-7336770594939704~2094770057 
// RewardBasedVideo ID
// ca-app-pub-7336770594939704/2848366959

// iOS App ID
// ca-app-pub-7336770594939704~2815457808
// RewardBasedVideo ID
// ca-app-pub-7336770594939704/3709613363

public class AdManager : MonoBehaviour {

    [SerializeField] string gameID;

  //  private RewardBasedVideoAd rewardBasedVideoAd;
    private GameObject player;

    private void Awake() {
#if UNITY_EDITOR
        gameID = "unused";
#elif UNITY_ANDROID
        gameID = "2918569";
#elif UNITY_IPHONE
        gameID = "2918567";
#else
        gameID = "unexpected_platform";
#endif

        Advertisement.Initialize(gameID, true);
    }

    private void Start() {


        // MobileAds.Initialize(gameID);

        //  rewardBasedVideoAd = RewardBasedVideoAd.Instance;
        // rewardBasedVideoAd.OnAdRewarded += HandleOnAdRewarded;

        player = GameObject.FindGameObjectWithTag("Player");
    }

 //   public void ShowRewardBasedAd() {
 //       if (rewardBasedVideoAd.IsLoaded()) {
  //          rewardBasedVideoAd.Show();
   //     } else {
  //          MonoBehaviour.print("Ad not loaded yet");
    //    }
  //  }

   // public void LoadRewardBasedAd() {
//#if UNITY_EDITOR
 //       string adUnitId = "ca-app-pub-7336770594939704/2848366959";
//#elif UNITY_ANDROID
  //      string adUnitId = "ca-app-pub-7336770594939704/2848366959";
//#elif UNITY_IPHONE
  //      string adUnitId = "ca-app-pub-7336770594939704/3709613363";
//#else
    //    string adUnitId = "unexpected_platform";
//#endif

      //  rewardBasedVideoAd.LoadAd(new AdRequest.Builder().Build(), adUnitId);
      //  ShowRewardBasedAd();
   // }

   // public void HandleOnAdRewarded(object sender, EventArgs msg) {
   //     ResetContinue();
   // }
    
    public void ShowAd(string zone = "") {
#if UNITY_EDITOR
        StartCoroutine(WaitForAd());
#endif

        if (string.Equals(zone, ""))
            zone = null;

        ShowOptions options = new ShowOptions();
        options.resultCallback = AdCallbackhandler;

        if (Advertisement.IsReady(zone)) {
            Advertisement.Show(zone, options);
        } else {
            // handle error when theres not ad to show
            // setActive the usual game over panel
        }
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
                ResetContinue();
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

        player.transform.position = new Vector3(platform.lastPlatform.transform.position.x, platform.lastPlatform.transform.position.y + 4f, platform.lastPlatform.transform.position.z);

        //Debug.Log(platform.lastPlatform.transform.position);

        GameOver gameOver = GameObject.Find("Canvas").GetComponent<GameOver>();
        gameOver.ContinueGame();

        Debug.Log(gameObject.name);
        gameObject.SetActive(false);
        

    }

}
