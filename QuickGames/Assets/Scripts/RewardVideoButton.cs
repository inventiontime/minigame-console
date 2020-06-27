using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;
using UnityEngine.UI;
#if UNITY_ANDROID
[RequireComponent(typeof(Button))]
public class RewardVideoButton : MonoBehaviour, IUnityAdsListener
{
    

    [Serializable] public class ButtonClickedEvent : UnityEvent { }
    [SerializeField] private ButtonClickedEvent OnCompleted = new ButtonClickedEvent();

    private string gameId = "3517444";

    string myPlacementId = "rewardedVideo";
    Button myButton;

    void Start()
    {
        myButton = GetComponent<Button>();
        myButton.interactable = Advertisement.IsReady(myPlacementId);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    // Implement a function for showing a rewarded video ad:
    public void ShowRewardedVideo()
    {
        Advertisement.Show(myPlacementId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string placementId)
    {
        // If the ready Placement is rewarded, activate the button: 
        if (placementId == myPlacementId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            OnCompleted.Invoke();
        }
        else if (showResult == ShowResult.Skipped)
        {
            // Do not reward the user for skipping the ad.
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    
}

#else
public class RewardVideoButton : MonoBehaviour
{

}

#endif