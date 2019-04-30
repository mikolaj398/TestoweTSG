using UnityEngine;
using UnityEngine.UI
    ;
public class RodCardInit : MonoBehaviour
{
    public int progressBarIndex=3;
    GameObject progressBar;
    int nextLevelPoints;
    int gainedPoints;

    void Start()
    {
        progressBar = transform.GetChild(progressBarIndex).gameObject;
        InitLevelPointsValues();
        SetText();
        InitSlider();
        CheckUpgradeArrow();
    }

    void InitLevelPointsValues()
    {
        nextLevelPoints = Random.Range(1, 20);
        gainedPoints = Random.Range(1, 40);
    }
    void InitSlider()
    {
        Slider slider = progressBar.GetComponentInChildren<Slider>();
        slider.maxValue = nextLevelPoints;
        slider.value = gainedPoints;
    }
    void SetText()
    {
        Text progressText = progressBar.GetComponentInChildren<Text>();
        progressText.text = gainedPoints+"/"+nextLevelPoints;
    }
    void CheckUpgradeArrow()
    {
        Button upgradeArrow = progressBar.GetComponentInChildren<Button>();
        if (gainedPoints>=nextLevelPoints) upgradeArrow.gameObject.SetActive(true);
        else upgradeArrow.gameObject.SetActive(false);

    }

}
