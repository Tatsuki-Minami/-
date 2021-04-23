using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextControll : MonoBehaviour
{
    public TextMeshProUGUI GameOver;
    public TextMeshProUGUI Time;
    public float Full=10f;

    private float fadespeed = 0.02f;//フェードアウトスピード
    private float r, g, b, alpha;
    public bool isFadeout,isFadein;

    private GameManager _GameManager;

#pragma warning disable 0649
    [SerializeField]
    private Image FadeImage;
    // Start is called before the first frame update

    void Start()
    {
        //GameOverの初期設定
        GameOver.text = "GAME OVER";
        GameOver.enabled = false;
        //Timeの初期設定
        Time.text = "Time="+Full.ToString("f2");

        //FadeOut,Inの初期設定
        r = FadeImage.color.r;
        g = FadeImage.color.g;
        b = FadeImage.color.b;
        alpha = FadeImage.color.a;

        //flagの初期設定
        isFadein = false;
        isFadeout = false;
        _GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (isFadeout)
        {
            StartFadeOut();
        }
        if (isFadein)
        {
            StartFadeIn();
        }
    }
    public void ChangeText(TextMeshProUGUI Text,string st)
    {
        Text.text = st;
    }

    public void SetGameOver()//今回は遷移をするストレスを無くしたいので没
    {
        GameOver.enabled = true;
    }

    public void ResetText()//Resetしたときのテキスト動作
    {
        Full = 10f;
        ChangeText(Time, "Time=" + Full.ToString("f2"));
    }

    void StartFadeIn()
    {
        FadeImage.enabled = true;
        alpha -= fadespeed;//alpha値に足していく
        SetAlpha();
        if (alpha <= 0)
        {
            isFadein = false;
            FadeImage.enabled = false;
        }
    }
    void StartFadeOut()
    {
        FadeImage.enabled = true;
        alpha += fadespeed;//alpha値に足していく
        SetAlpha();
        if (alpha >= 1)
        {
            isFadeout = false;
                //キャラクター生成とテキストリセット
            _GameManager.MakePlayer();
            ResetText();
            isFadein = true;
        }
    }

    void SetAlpha()
    {
        FadeImage.color = new Color(r, g, b, alpha);
    }


}
