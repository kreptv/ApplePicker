/*
 * Created by: Haley Kelly
 * Date Created: 1/31/2022
 *
 * Last Edited by: N/A
 * Last Edited: 1/31/2022
 *
 * Description:
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ApplePicker : MonoBehaviour
{
  public GameObject basketPrefab;
  public int numBaskets = 3;
  public float basketBottomY = -14f;
  public float basketSpacingY = 2f;
  public List<GameObject> basketList;
    // Start is called before the first frame update
    void Start()
    {
      basketList = new List<GameObject>();
      for (int i = 0; i < numBaskets; i++){
        GameObject tBasketGO = Instantiate<GameObject>( basketPrefab );
        Vector3 pos = Vector3.zero;
        pos.y = basketBottomY + (basketSpacingY * i);
        tBasketGO.transform.position = pos;
        basketList.Add(tBasketGO);
      }

    }

    public void AppleDestroyed()
    {
        GameObject[] tAppleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tGo in tAppleArray)
        {
            Destroy(tGo);
        }
        int basketIndex = basketList.Count-1;
        GameObject tBasketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(tBasketGO);

        if ( basketList.Count == 0 ){
          SceneManager.LoadScene("_Scene-00");
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene-00");
        }*/

    }
}
