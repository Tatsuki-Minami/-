using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : MonoBehaviour
{
    private GameManager GameManager;
    private TextControll TextControll;
    private bool NotEvent;
#pragma warning disable 0649
    [SerializeField]
    GameObject PrefabEnemy;
    // Start is called before the first frame update
    void Start()
    {
        NotEvent = true;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        TextControll = GameObject.Find("TextScript").GetComponent<TextControll>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TextControll.isFadein)
        {
            NotEvent = true;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (NotEvent)//AND構文にしたら読みづらい？好み？
        {
            if (collision.gameObject.tag == "Player"){
                MakeEnemy(-4f, 1.8f);
                GameManager.vectol = 1;
                NotEvent = false;
                return;
            }
        }

        void MakeEnemy(float posx, float posy)
        {
            Vector3 Position = new Vector3(posx, posy, 0f);
            var player = Instantiate(PrefabEnemy, Position, Quaternion.identity);
            player.name = PrefabEnemy.name;
        }
    }
}
