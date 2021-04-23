using UnityEngine;
using System.Collections;
using System;

public class test: MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 startPosition;
    private Vector3 BulletPosition;

    private Boolean healflag;//heal位置に入っているかの判定

    private GameObject TextScript;
    private TextControll TextControll;

    public int reversecount = 0; //反転しているかを偶数奇数で判別する
    public bool DontMake = true;

#pragma warning disable 0649
    [SerializeField]
    public GameObject Bullet;

    private void Start()
    {
        TextScript = GameObject.Find("TextScript");
        TextControll = TextScript.GetComponent<TextControll>();
        startPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            BulletPosition = transform.position;
            Quaternion q = Bullet.transform.rotation;
            var _Bullet = Instantiate(Bullet,BulletPosition,q);
            _Bullet.name = Bullet.name;
        }
    }
    void OnMouseDown()
    {
        {
            this.screenPoint = Camera.main.WorldToScreenPoint(transform.position);
            this.offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
            //マウスと中心座標の距離を求めズレを無くす処理
        }
    }

    void OnMouseDrag()//マウスをドラッグしている間の処理
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;//ここでオフセットを使う
        transform.position = currentPosition;

        //時間の処理（ここは関数にすべきなのか・・・？）
        if (!healflag)//安全地帯出ない時
        {
        TextControll.Full = TextControll.Full - Time.deltaTime;
        TextControll.ChangeText(TextControll.Time, "Time=" + TextControll.Full.ToString("f2"));
        }

        //後に弾幕ゲーにしたいから右クリックしたらキャラが反転するとかにしてみる

        if (Input.GetMouseButtonDown(1))//キャラクターが反転する
        {
            reversecount++;
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }

    private void OnMouseUp()//マウスを上げた時
    {
        if (!healflag)//安全地帯じゃない時
        {
            GameOverProcess();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "OutObject")//OutObjectに触れた時の動き
        {
            GameOverProcess();
        }
        else if (collision.gameObject.tag == "Heal")
        {
            healflag = true;
            TextControll.ResetText();
        }
    }
   private void OnTriggerStay2D(Collider2D collision)
    {
        if (TextControll.Full != 10&& collision.gameObject.tag == "Heal")
        {
            healflag = true;
            TextControll.ResetText();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        healflag = false;
    }
    void GameOverProcess()
    {
        TextControll.isFadeout = true;
        Destroy(this.gameObject);
        DontMake = true;
    }
}
