using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControll : MonoBehaviour
{
    GameManager GameManager;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
        GameManager.SavePoint = 2; 
        Destroy(this.gameObject);
        }
    }
}
