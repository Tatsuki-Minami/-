using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Stage1 : MonoBehaviour
{
    private GameManager GameManager;
    private TextControll TextControll;
    private bool NotEvent;//Eventが発生しなかったらという意味でNotにしたけど、わかりにくい気がする...
#pragma warning disable 0649
    [SerializeField]
    GameObject PrefabEnemy;//Prefabをアタッチする方法はPrefab変更でエラーが出やすい

    // Start is called before the first frame update
    void Start()
    {
        NotEvent = true;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        TextControll = GameObject.Find("TextScript").GetComponent<TextControll>();
    }
    // Update is called once per frame

    private void Update()
    {
        if (TextControll.isFadein)
        {
            NotEvent = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (NotEvent)//AND構文にしたら読みづらい？好み？
            {
                MakeEnemy(-2.8f, 2.18f);
                GameManager.vectol = -1;
                NotEvent = false;
            }
        }
        }

     void MakeEnemy(float posx,float posy)
    {
        Vector3 Position = new Vector3(posx, posy,0f);
        var player = Instantiate(PrefabEnemy,Position,Quaternion.identity);
        player.name = PrefabEnemy.name;
    }


}
