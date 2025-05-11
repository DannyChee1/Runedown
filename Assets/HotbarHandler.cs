using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarHandler : MonoBehaviour
{
    public Button cripplingStrike;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        cripplingStrike.onClick.AddListener(player.GetComponent<PlayerController>().PerformBasicAttack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
