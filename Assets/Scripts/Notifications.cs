using System;
using UnityEngine;

namespace Assets.SimpleAndroidNotifications
{
    public class Notifications : MonoBehaviour
    {
        [SerializeField] int time;

        private void OnApplicationQuit()
        {
            NotificationManager.Send(TimeSpan.FromSeconds(time), "Transfusion", "Bobet needs you! Come back!", new Color(1, 0.5f, 0.5f));
        }

        private void OnApplicationPause(bool pause)
        {
            NotificationManager.Send(TimeSpan.FromSeconds(time), "Transfusion", "Bobet needs you! Come back!", new Color(1, 0.5f, 0.5f));
        }
    }
}
