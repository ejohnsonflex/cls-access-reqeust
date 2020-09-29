using UnityEngine;

namespace CMAPI
{
    public class Quit : MonoBehaviour
    {
        public void OnApplicationQuit()
        {
            Application.Quit();
        }
    }
}
