using UnityEngine;

namespace CMAPI
{
    public class Quit : MonoBehaviour
    {
        private void OnApplicationQuit()
        {
            Application.Quit();
        }
    }
}
