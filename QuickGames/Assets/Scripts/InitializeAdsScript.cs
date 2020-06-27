using UnityEngine;
using UnityEngine.Advertisements;

public class InitializeAdsScript : MonoBehaviour
{
    #if UNITY_ANDROID

    string gameId = "3517444";
    bool testMode = false;

    void Start() => Advertisement.Initialize(gameId, testMode);

    #endif
}