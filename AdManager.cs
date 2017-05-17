using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{

    int numberOfLoops;
    int adTrashold = 3;

    void Start()
    {
        showBannerAd();
        RequestInterstitialAds();
        numberOfLoops = PlayerPrefs.GetInt("NumberOfLoops", 0);
        Debug.Log("<color=red><b>numberOfLoops on start" + numberOfLoops + "</b></color>");
    }

    #region SMALL BANNER

    private void showBannerAd()
    {
        string adID = "ca-app-pub-2701902353444444/1253192611";

        AdRequest request = new AdRequest.Builder().Build();

        BannerView bannerAd = new BannerView(adID, AdSize.SmartBanner, AdPosition.Top);
        bannerAd.LoadAd(request);
    }

    #endregion

    #region LARGE AD
    #region LARGE AD COUNTER

    public void UpdateCounter()
    {
        if (numberOfLoops == 0)
        {
            RequestInterstitialAds();
        }
        numberOfLoops += 1;
        PlayerPrefs.SetInt("NumberOfLoops", numberOfLoops);
        if (numberOfLoops >= adTrashold)
        {
            numberOfLoops = 0;
            PlayerPrefs.SetInt("NumberOfLoops", numberOfLoops);
            showInterstitialAd();
        }
    }

    #endregion
    public void showInterstitialAd()
    {
        //Show Ad
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }

    }

    InterstitialAd interstitial;
    public void RequestInterstitialAds()
    {
        string adID = "ca-app-pub-2701902353444444/7160125415";

#if UNITY_ANDROID
        string adUnitId = adID;
#elif UNITY_IOS
        string adUnitId = adID;
#else
        string adUnitId = adID;
#endif

        interstitial = new InterstitialAd(adUnitId);

        AdRequest request = new AdRequest.Builder().Build();

        //Register Ad Close Event
        interstitial.OnAdClosed += Interstitial_OnAdClosed;

        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    //Ad Close Event
    private void Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {


    }
    #endregion
}
