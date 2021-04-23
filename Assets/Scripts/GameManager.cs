using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject TextScript;
    GameObject Player;

    //他スクリプトの値を使うための処理
    test test;
    TextControll TextControll;
#pragma warning disable 0649
    [SerializeField]
    GameObject PrefabPlayer;
    // Start is called before the first frame update

    private Vector3 Position;

    public int vectol = 1;
    public int SavePoint = 1;
    //GameManagerは統括なので、結構色々なスクリプトをpublicでくっつけると一体性が出る？
    void Start()
    {
        //Player生成
        MakePlayer();

        TextScript = GameObject.Find("TextScript");
        Player = GameObject.Find("Player");

        //テキストで行う初期処理
        test = Player.GetComponent<test>();
        TextControll = TextScript.GetComponent<TextControll>();

    }

    // Update is called once per frame
    void Update()
    {
        //GameOverの条件
        if (TextControll.Full <= 0)
        {
            GameOverProcess();  
        }        
    }

    public void GameOverProcess()
    {
        TextControll.isFadeout=true;
        TextControll.Full = 10;
        Destroy(GameObject.Find("Player").gameObject);
    }
    public void MakePlayer()//プレイヤー生成をGameManagerに作ったのは失敗かもしれない
    //Stage毎にスクリプトで管理した方が,座標等がごちゃごちゃにならないため
    {
        if (SavePoint == 1)
        {
        Position = new Vector3(-4.5f, 1.7f, 0f);
        }
        else if (SavePoint == 2)
        {
        Position = new Vector3(-3.35f, 1.7f, 0f);
        }
        var player = Instantiate(PrefabPlayer,Position,Quaternion.identity);
        player.name = PrefabPlayer.name;
    }
}

//メモ
//関数は何度も行き来するリセット、ゲームオーバーなどの処理をひとまとめにすると効果的
//無駄な記述が多いので、予めどのように作るか設計図の様なものを作ると手間が省けそう
//GameManagerを親にして、フラグ（ゲームオーバー時など）を作成すれば、どのパターンでもその値を変更するだけで良さそう！
//親オブジェクトから子オブジェクトにつながってて、子オブジェクトのGameOver処理の条件をGameManager.Flagにするというイメージ