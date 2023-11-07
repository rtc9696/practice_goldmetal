using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    Collider2D coll;

    private void Awake()
    {
        coll = GetComponent<Collider2D>();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Area"))
        {
            Vector3 playerPos = GameManager.Instance.player.transform.position;
            Vector3 myPos = transform.position;
            float diffX = Mathf.Abs(playerPos.x - myPos.x);
            float diffY = Mathf.Abs(playerPos.y - myPos.y);

            Vector2 playerDir = GameManager.Instance.player.moveVec;
            float dirX = playerDir.x < 0 ? -1 : 1;
            float dirY = playerDir.y < 0 ? -1 : 1;

            switch (transform.tag)
            {
                case "Ground":

                    if (diffX > diffY)
                    {
                        transform.Translate(Vector2.right * dirX * 40);

                    }
                    else if (diffX < diffY)
                    {
                        transform.Translate(Vector2.up * dirY * 40);
                    }
                    break;

                case "Enemy":
                    if (coll.enabled)
                    {
                        transform.Translate(playerDir * 20 + new Vector2(Random.Range(-3f, 3f), Random.Range(-3f, 3f)));
                    }
                    break;
            }
        }
    }
}
