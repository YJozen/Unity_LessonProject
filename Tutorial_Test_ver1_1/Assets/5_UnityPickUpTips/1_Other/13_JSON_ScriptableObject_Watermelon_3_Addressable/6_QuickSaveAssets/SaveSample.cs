using UnityEngine;

namespace QuickSave_Sample
{
    public class SaveSample : MonoBehaviour
    {
        UserData userData;

        void Start()
        {
            userData = new UserData();
            userData.Start();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.W)) {
                userData.SaveUserData("a",12);
            }
            if (Input.GetKeyDown(KeyCode.R)) {
                userData.LoadUserData();
            }
        }
    }
}
