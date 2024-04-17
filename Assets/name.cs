using Photon.Pun;
using TMPro;
using UnityEngine;

public class UsernameSetter : MonoBehaviour
{
    public TMP_InputField usernameInputField;

    public void SetUsername()
    {
        string username = usernameInputField.text.Trim(); // Trim any leading or trailing whitespace
        if (!string.IsNullOrEmpty(username))
        {
            PhotonNetwork.NickName = username; // Set the username using PhotonNetwork
            Debug.Log("Username set to: " + username);
            usernameInputField.text = username;
        }
        else
        {
            Debug.LogWarning("Username cannot be empty!");
        }
    }
}
