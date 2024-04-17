using Photon.Pun;
using UnityEngine;

public class SpawnPotion : MonoBehaviour
{
    public GameObject potionParent;
    private float x = Screen.width / 2;
    private float y = Screen.height / 2;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 potionParentPosition = new Vector2(x, y);
        PhotonNetwork.Instantiate(potionParent.name, potionParentPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
