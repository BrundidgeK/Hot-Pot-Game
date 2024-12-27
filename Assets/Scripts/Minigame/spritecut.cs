using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureDivider : MonoBehaviour
{

    public Texture2D source;
    private int cuts;
    private bool cutting;
    private bool entered;
    private bool cut;

    private void Update()
    {
        if (cuts >= 1 && cut == false)
        {
            SpriteCut();
            cut = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    private void SpriteCut()
    {

        GameObject spritesRoot = gameObject;
        float spriteX = spritesRoot.GetComponent<SpriteRenderer>().bounds.size.x * spritesRoot.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit; // pixels resolution of sprite
        float spriteY = spritesRoot.GetComponent<SpriteRenderer>().bounds.size.y * spritesRoot.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
        int xcuts = 2; // xcuts * ycuts = number of pieces
        int ycuts = 2;
        for (int i = 0; i < xcuts; i++)
        {
            for (int j = 0; j < ycuts; j++)
            {
                Sprite newSprite = Sprite.Create(source, new Rect(i * spriteY / xcuts, j * spriteX / ycuts, 200, 200), new Vector2(0.5f, 0.5f));
                GameObject n = new GameObject();
                SpriteRenderer sr = n.AddComponent<SpriteRenderer>();
                sr.sprite = newSprite;
                n.transform.position = new Vector3(i * 2.25f, j * 2.25f, 0);
                n.transform.parent = spritesRoot.transform;
            }
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.transform.position.x == 0)
        {
            cutting = true;
        }
    }

    private void OnMouseUp()
    { 
        if (cutting & entered)
        {
            cuts += 1;
        }
        cutting = false;
    }

    private void OnMouseEnter()
    {
       entered = true;
    }

    private void OnMouseExit()
    {
        if (entered)
        {
            entered = false;
        }
    }
}