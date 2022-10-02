
using Firebase;
using Firebase.Analytics;
using Firebase.Extensions;
using UnityEngine;

public class AnaliticsManager : MonoBehaviour
{
    private async void Start()
    {
        await FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            FirebaseAnalytics.SetAnalyticsCollectionEnabled(true);
            var app = FirebaseApp.DefaultInstance;
        });
    }
}
