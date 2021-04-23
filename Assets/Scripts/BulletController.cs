using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private GameObject Player;//GameObjectはPlayerなど分かりやすいほうが良かった？
    private test test;
    private int cnt=0;//プレイヤーの向きを判別する整数
    private float timecnt = 0f;//弾が消える時間測定数値
    private float bulletspeed = 0.03f;

    private TextControll TextControll;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        test = Player.GetComponent<test>();
        TextControll = GameObject.Find("TextScript").GetComponent<TextControll>();
        cnt = test.reversecount;//ここで違う変数に入れないともしかしたらとんでもないことになるかも？
    }
    // Update is called once per frame
    void Update()
    {
        //弾にインターバルを設けたい
        shooting();
        if (TextControll.isFadein)
        {
            Destroy(this.gameObject);
        }
    }

    void shooting()//弾を発射する関数
    {
        if (cnt % 2 == 1)//cntはプレイヤーの向きであり 反転＝奇数とする
        {
            transform.position -= new Vector3(bulletspeed, 0, 0);
        }
        else//偶数なので右側に弾が飛ぶ
        {
            transform.position += new Vector3(bulletspeed, 0, 0);
        }
        timecnt += Time.deltaTime;

        if (timecnt > 3)//3秒経つと、弾が破壊される
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DestroyObject")//破壊できるオブジェクトに触れた時の動き
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag=="Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }

    }
}
