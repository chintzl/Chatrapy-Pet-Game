using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject happinessText;
    public GameObject hungerText;

    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;

    public GameObject pet;
    public GameObject petPanel;
    public GameObject[] petList;

    public GameObject homePanel;
    public Sprite[] homeTileSprites;
    public GameObject[] homeTiles;

    public GameObject background;
    public Sprite[] backgroundOptions;

    public GameObject foodPanel;
    public Sprite[] foodIcons;

    void Start()
    {

        if (!PlayerPrefs.HasKey("looks"))
            PlayerPrefs.SetInt("looks", 0);
        createPet(PlayerPrefs.GetInt("looks"));
        
        if (!PlayerPrefs.HasKey("tiles"))
            PlayerPrefs.SetInt("tiles", 0);
        changeTiles(PlayerPrefs.GetInt("tiles"));

        if (!PlayerPrefs.HasKey("background"))
            PlayerPrefs.SetInt("background", 0);
        changeBackground(PlayerPrefs.GetInt("background"));
    }

    void Update()
    {
        happinessText.GetComponent<Text> ().text = "" + pet.GetComponent<Pet> ().happiness;
        hungerText.GetComponent<Text> ().text = "" + pet.GetComponent<Pet> ().hunger;
        nameText.GetComponent<Text>().text = pet.GetComponent<Pet>().name;

        if (Input.GetKeyUp(KeyCode.Space))
            createPet(1);
    }

    public void triggerNamePanel(bool b)
    {
        namePanel.SetActive(!namePanel.activeInHierarchy);

        if (b)
        {
            pet.GetComponent<Pet>().name = nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString("name", pet.GetComponent<Pet>().name);
        }
    }

    public void buttonBehaviour(int i)
    {
        switch (i)
        {
            case (0):
            default:
                petPanel.SetActive(!petPanel.activeInHierarchy);
                break;
            case (1):
                homePanel.SetActive(!homePanel.activeInHierarchy);

                break;
            case (2):
                foodPanel.SetActive(!foodPanel.activeInHierarchy);
                break;
            case (3):

                break;
            case (4):
                pet.GetComponent<Pet>().savePet();
                Application.Quit();
                break;
        }
    }
    public void createPet(int i)
    {
        if (pet)
            Destroy(pet);
        
        pet = Instantiate(petList[i], Vector3.zero, Quaternion.identity) as GameObject;
        
        toggle(petPanel);
        
        PlayerPrefs.SetInt("looks", i);
    }

    public void changeTiles(int t)
    {
        for (int i = 0; i < homeTiles.Length; i++)
            homeTiles[i].GetComponent<SpriteRenderer>().sprite = homeTileSprites[t];

        toggle(homePanel);


        PlayerPrefs.SetInt("tiles", t);
    }

    public void changeBackground(int i)
    {
        background.GetComponent<SpriteRenderer>().sprite = backgroundOptions[i];

        toggle(homePanel);

        PlayerPrefs.SetInt("background", i);
    }
    public void selectFood(int i)
    {


        toggle(foodPanel);
    }

    public void toggle(GameObject g) 
    {
        if (g.activeInHierarchy)
            g.SetActive(false);
    }
}
