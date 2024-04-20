using Photon.Pun;
using TMPro;
using UnityEngine;

public class UsernameSetter : MonoBehaviour
{
    public TMP_InputField usernameInputField;
    public TMP_Text MyUserName;
    private void Start()
    {

        if (PlayerPrefs.GetString("Username") == "" || PlayerPrefs.GetString("Username") == null)
        {
            Debug.Log("Username Empty");
        }
        else
        {
            PhotonNetwork.NickName = PlayerPrefs.GetString("Username");
            if (MyUserName != null)
            {
                MyUserName.text = PlayerPrefs.GetString("Username");
            }

        }
    }
    public void SetUsername()
    {
        SoundEffects.Instance.ButtonSoundPlay();
        if (usernameInputField != null)
        {
            PhotonNetwork.NickName = usernameInputField.text;
            PlayerPrefs.SetString("Username", usernameInputField.text);
            MyUserName.text = usernameInputField.text;
        }


    }
}
