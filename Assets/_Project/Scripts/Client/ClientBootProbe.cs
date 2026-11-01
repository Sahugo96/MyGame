using UnityEngine;
using Game.Shared;

namespace Game.Client
{
    public class ClientBootProbe : MonoBehaviour
    {
        private void Start() => Log.Info("Client", "Client probe started");
    }
}