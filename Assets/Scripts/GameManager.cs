using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _buttonsLvl;
    [SerializeField] private Image[] _imageMedal;
    [SerializeField] private Sprite _bronze;
    [SerializeField] private Sprite _silver;
    [SerializeField] private Sprite _gold;

    private void Start()
    {
        OpacityMedals();
        OpeningLevel();
        AchievManager();
    }


    void OpeningLevel()
    {
        if (PlayerPrefs.GetInt("B_1") == 1)
        {
            _buttonsLvl[0].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B_2") == 2)
        {
            _buttonsLvl[1].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B_3") == 3)
        {
            _buttonsLvl[2].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B_4") == 4)
        {
            _buttonsLvl[3].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B_5") == 5)
        {
            _buttonsLvl[4].SetActive(true);
        }
        if (PlayerPrefs.GetInt("B_6") == 6)
        {
            _buttonsLvl[5].SetActive(true);
        }
    }

    void OpacityMedals()
    {
        for (int i = 0; i < _imageMedal.Length; i++)
        {
            _imageMedal[i].color = Color.clear;
        }
    }

    void AchievManager()
    {
        Achievment("D_1", 1, 2, 0);
        Achievment("D_2", 2, 3, 1);
        Achievment("D_3", 1, 2, 2);
        Achievment("D_4", 1, 2, 3);
        Achievment("D_5", 1, 2, 4);
        Achievment("D_6", 2, 3, 5);
        Achievment("D_7", 3, 4, 6);
    }
    void Achievment(string saveName, int goldCount, int silverCount, int index)
    {
        if (PlayerPrefs.GetInt($"B_{index + 1}") == index+1)
        {
            if (PlayerPrefs.GetInt(saveName) == goldCount)
            {
                _imageMedal[index].sprite = _gold;
                _imageMedal[index].color = Color.white;
            }
            else if (PlayerPrefs.GetInt(saveName) == silverCount)
            {
                _imageMedal[index].sprite = _silver;
                _imageMedal[index].color = Color.white;
            }
            else if (PlayerPrefs.GetInt(saveName) > silverCount)
            {
                _imageMedal[index].sprite = _bronze;
                _imageMedal[index].color = Color.white;
            }
        }
    }
}
