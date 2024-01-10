using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharManager : MonoBehaviour
{
    public charDatabase charDatabase;

    public Text nameText;
    public SpriteRenderer sprite;

    private int selectedOption = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("selectedOption"))
        {
            selectedOption = 0;
        } else
        {
            Load();
        }

        UpdateCharacter(selectedOption);
    }

    public void NextOption()
    {
        selectedOption++;

        if (selectedOption >= charDatabase.characterCount)
        {
            selectedOption = 0;
        }

        UpdateCharacter(selectedOption);
        Save();
    }

    public void BackOption()
    {
        selectedOption--;

        if (selectedOption < 0)
        {
            selectedOption = charDatabase.characterCount - 1;
        }

        UpdateCharacter(selectedOption);
        Save();
    }



    private void UpdateCharacter(int selectedOption)
    {
        Character character = charDatabase.GetChar(selectedOption);
        sprite.sprite = character.charSprite;
        nameText.text = character.charName;
    }

    private void Load()
    {
        selectedOption = PlayerPrefs.GetInt("selectedOption");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("selectedOption", selectedOption);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
