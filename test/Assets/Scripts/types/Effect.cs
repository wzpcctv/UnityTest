using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect
{
    void EffectCreate(Sprite sprite)
    {
        //图像
        // 获取SpriteRenderer对象
        spriteRd = gameObj.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        // 添加图片
        spriteRd.sprite = sprite;
        spriteRd.transform.Rotate(new Vector2(0, 30) );
        // 移动位置
        spriteRd.transform.position = new Vector2(this.target_x, this.target_y);
    }

    public Effect(Unit unit,float target_x,float target_y,float angle)
    {
        this.unit = unit;
        this.gameObj = unit.gameObj;
        this.gameObj = gameObj;
        target_x = target_x;
        target_y = target_y;
        angle = angle;
        Sprite sprite = Resources.Load(Table.UnitData[unit.id].spritePath, typeof(Sprite)) as Sprite;
        
        EffectCreate(sprite);
        gameObj.transform.position = new Vector2(unit.x / 100, unit.y / 100);
        //this.gameObj.transform.Translate(new Vector2(unit.x/100, unit.y/100));
    }

    public Effect(Brick brick, float target_x, float target_y, float angle)
    {
        this.brick = brick;
        this.gameObj = brick.gameObj;
        this.gameObj = gameObj;
        target_x = target_x;
        target_y = target_y;
        angle = angle;
        //图像
        Sprite sprite = Resources.Load(Table.BrickData[brick.id].spritePath, typeof(Sprite)) as Sprite;
        EffectCreate(sprite);


        gameObj.transform.position = new Vector2(brick.x / 100, brick.y / 100);
        //this.gameObj.transform.Translate(new Vector2(brick.x/100, brick.y/100));
    }

    public void remove()
    {
        this.unit = null;
        this.brick = null;
        this.gameObj = null;
    }

    private Unit unit;
    private Brick brick;
    GameObject gameObj;
    SpriteRenderer spriteRd;
    private float target_x = 0;
    private float target_y = 0;
    private float width = 0;
    private float hight = 0;
    private float angle = 0;
    private int id = 0;
}
