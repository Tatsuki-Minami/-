using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float timecnt = 0f;//弾が消える時間測定数値
    private float speed = 0.03f;
    private int vectol;
    private GameManager _GameManager;
    private TextControll TextControll;
    private Stage1 StageControll;
      
    // Start is called before the first frame update
    void Start()
    {
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        TextControll = GameObject.Find("TextScript").GetComponent<TextControll>();
        vectol = _GameManager.vectol;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position += new Vector3(speed*vectol, 0, 0);
  
    timecnt += Time.deltaTime;

        if (timecnt>7||TextControll.isFadeout)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")//PlayerとEnemyがあたった時の処理
        {
            //TextControll.SetGameOver();
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
            _GameManager.GameOverProcess();
            TextControll.isFadeout = true;

        }
    }
}
