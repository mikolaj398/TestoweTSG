using UnityEngine;
using UnityEngine.UI;
public class RodCardPressed : MonoBehaviour
{
    public GameObject rod;
    private Button button;
    private bool choosen;
    private Transform context;
    private GameObject selectedInfo;
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ButtonPressed);
        choosen = false;
        FindGameObjects();
    }
    void FindGameObjects()
    {
        context = GameObject.FindGameObjectWithTag("Context").transform;
        selectedInfo = gameObject.transform.parent.GetChild(transform.GetSiblingIndex() - 1).gameObject;
    }
    public void ButtonPressed()
    {
        if (choosen) return;
        ChangeRod();
        selectedInfo.SetActive(true);
        DeactivatePreviousButton();
        choosen = true;
    }
    void ChangeRod()
    {
        Transform oldRod = GameObject.FindGameObjectWithTag("Rod").gameObject.transform;
        GameObject newRod = Instantiate(rod, oldRod.position, oldRod.rotation).gameObject;
        newRod.transform.SetParent(context);
        newRod.transform.localScale = new Vector3(300, 300, 300);
        newRod.name = "RodModel";
        newRod.tag = "Rod";
        Destroy(oldRod.gameObject);
    }
    public void ChangeChoose()
    {
        choosen = false;
        selectedInfo.SetActive(false);
    }
    void DeactivatePreviousButton()
    {
        GameObject previousSelectedParent = GameObject.FindGameObjectWithTag("SelectedInfo").transform.parent.gameObject;
        previousSelectedParent.transform.GetChild(previousSelectedParent.transform.childCount - 1).GetComponent<RodCardPressed>().ChangeChoose();
    }
}
