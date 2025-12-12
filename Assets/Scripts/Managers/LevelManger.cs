using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour
{
    public GameObject Door;
    public List<Collectable> FruitPrefabs;
    public List<Collectable> Collectables;
    public Player Player;

    public void RestartLevel()
    {
       DeactivateDoor();
       RandomizeDoorPosition();
       DeleteCollectables();
       GenerateCollectables();
       PlayerStartPosition();
    }

    
    private void DeleteCollectables()
    {
        foreach (Collectable collectable in Collectables)
        {
            Destroy(collectable.gameObject);
        }
        Collectables.Clear();
    }

    private void GenerateCollectables()
    {
        Player.isAppleCollected = false;
        FruitsOperations();
    }
    public void RandomizeDoorPosition()
    {
        var location=Door.transform.position;
        location.x = Random.Range(2.7f,-2.7f);
        Door.transform.position = location;
    }
    public void DeactivateDoor()
    {
        Door.SetActive(false);
    }
    public void ShowDoor()
    {
        Door.SetActive(true);   
    }
    public void PlayerStartPosition()
    {
        Player.gameObject.SetActive(true);  
        Player.canMove = true;
        float posX = UnityEngine.Random.Range(-3f,3f);
        Player.transform.position = new Vector3(posX,0,0);
    }
    public void FruitsOperations()
    {
        var randomIndex = UnityEngine.Random.Range(0, 5);
        float posX = UnityEngine.Random.Range(-3.1f, 3.1f);
        float posZ = UnityEngine.Random.Range(9.5f, 12.5f);
        var newcollectable = Instantiate(FruitPrefabs[randomIndex]);
        if (randomIndex == 0)
        {
            newcollectable.transform.position = new Vector3(posX, 1.1f, posZ);

        }
        else if (randomIndex == 1)
        {
            newcollectable.transform.position = new Vector3(posX, 0.95f, posZ);

        }

        else if (randomIndex == 2)
        {
            newcollectable.transform.position = new Vector3(posX, 0.9f, posZ);

        }
        else if (randomIndex==3)
        {
            newcollectable.transform.position = new Vector3(posX, 1.45f, posZ);

        }
       
        else if (randomIndex == 4)
        {
            newcollectable.transform.position = new Vector3(posX, 1.15f, posZ);

        }
        Collectables.Add(newcollectable);

    }



}
