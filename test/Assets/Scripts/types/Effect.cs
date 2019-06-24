using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{

    public Effect(F2 obj, Sprite sprite,float target_x,float target_y,float angle)
    {
        gameObj = obj.gameObj;
        target_x = target_x;
        target_y = target_y;
        angle = angle;

        // 获取SpriteRenderer对象
        spriteRd = gameObj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        // 添加图片
        spriteRd.sprite = sprite;
        // 移动位置
        spriteRd.transform.position = new Vector2(this.target_x, this.target_y);

        gameObj.transform.Translate(new Vector2(obj.x,obj.y));
    }

    public void remove()
    {

    }

    GameObject gameObj;
    SpriteRenderer spriteRd;
    private F2 obj;
    private float target_x = 0;
    private float target_y = 0;
    private float width = 0;
    private float higth = 0;
    private float angle = 0;
    private int id = 0;
}
