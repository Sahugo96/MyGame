using UnityEngine;
using Game.Shared;

namespace Game.Server
{
    public class ServerBootProbe : MonoBehaviour
    {
        private void Start() => Log.Info("Server", "Server probe started");
    }
}