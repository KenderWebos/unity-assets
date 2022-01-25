using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour //customEditor
{
    GameManager gm;

    public bool hasAnimation;
    public bool used = false;
    public bool tpIsForScene;

    public itemType type;
    public lightColor color;

    public Vector3 tpPosition;

    GameObject risingTree;
    public GameObject objetoFinal;
    public GameObject santaFinal;
    public GameObject UIGame;


    public enum lightColor
    {
        rojo,
        verde,
        azul,
        amarillo,
    }

    public enum itemType
    {
        gift,
        cultivo,
        danceBox,
        tp,
        light,
        final,
    }


    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;

        if (type == itemType.cultivo)
        {
            risingTree = this.transform.GetChild(0).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hasAnimation)
        {
            this.transform.Rotate(new Vector3(0f, 0f, 30f) * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider obj)
    {
        switch (type)
        {
            case itemType.cultivo:
                print("cultivo");
                //Funcion
                break;

            case itemType.gift:
                print("gift");
                //Funcion
                break;
            case itemType.danceBox:
                print("danceBox");
                //Funcion
                break;
            case itemType.tp:
                print("tp");
                //Funcion
                break;
            case itemType.light:
                print("light");
                lightPlus();
                break;

            case itemType.final:
                print("FINAL");
                //Funcion
                break;

            default:
                break;
        }
    }

    public void startDefaultAnim()
    {

    }

    public void startEndAnim()
    {

        Destroy(this.gameObject);
    }

    void lightPlus()
    {
        switch (color)
        {
            case lightColor.rojo:
                break;
            case lightColor.verde:
                break;
            case lightColor.azul:
                break;
            case lightColor.amarillo:
                break;
            default:
                break;
        }
    }
}
