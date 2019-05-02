using UnityEngine;
using UnityEngine.UI;

public class ManyRodCardsInit : MonoBehaviour
{
    public int spinningRods=14;
    public int flyRods=10;
    public int castingRods=20;

    public Sprite[] rodsIcons = new Sprite[10];
    public GameObject[] backgroundColorsPrefabs = new GameObject[3];
    public GameObject[] models = new GameObject[2];
    public string[] names = { "lol", "vk" };

    GameObject spinningRodsObject;
    GameObject flyRodsObject;
    GameObject castingRodsObject;

    Transform context;
    int icon;
    int background;
    int model;
    int name;

    void Start()
    {
        context = GameObject.FindGameObjectWithTag("Context").transform;

        spinningRodsObject = GameObject.FindGameObjectWithTag("Spinning");
        flyRodsObject = GameObject.FindGameObjectWithTag("Fly");
        castingRodsObject = GameObject.FindGameObjectWithTag("Casting");
        SpawnSpinningRods();
        SpawnFlyRods();
        SpawnCastingRods();
        InitFirstRod();
    }
    
    void RadnomValues()
    {
        icon = Random.Range(0, rodsIcons.Length);
        background = Random.Range(0, backgroundColorsPrefabs.Length);
        model = Random.Range(0, models.Length);
        name = Random.Range(0, names.Length);
    }
    void InitRodCard()
    {
        backgroundColorsPrefabs[background].transform.GetChild(1).GetComponentInChildren<Text>().text = names[name];
        backgroundColorsPrefabs[background].transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = rodsIcons[icon];
        backgroundColorsPrefabs[background].transform.GetChild(5).GetComponent<RodCardPressed>().rod = models[model];
    }
    void ResizePanels(RectTransform rt)
    {
        rt.sizeDelta += new Vector2(0, spinningRodsObject.transform.GetChild(1).transform.GetComponent<GridLayoutGroup>().cellSize.y);
        transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, spinningRodsObject.transform.GetChild(1).transform.GetComponent<GridLayoutGroup>().cellSize.y);
    }
    void SpawnSpinningRods()
    {
        RectTransform rtSpinning = spinningRodsObject.GetComponent<RectTransform>();
        for (int i=0;i<spinningRods;i++)
        {

            RadnomValues();
            InitRodCard();
            GameObject rodCard = Instantiate(backgroundColorsPrefabs[background], spinningRodsObject.transform.GetChild(1).transform, false);
            if (i == 0) rodCard.transform.GetChild(4).gameObject.SetActive(true);

            if (i % 4 == 0)  ResizePanels(rtSpinning);    
        }
    }

    void SpawnFlyRods()
    {
        RectTransform reFlying = flyRodsObject.GetComponent<RectTransform>();
        for (int i = 0; i < flyRods; i++)
        {

            RadnomValues();
            InitRodCard();
            GameObject rodCard = Instantiate(backgroundColorsPrefabs[background], flyRodsObject.transform.GetChild(1).transform, false);
            if (i % 4 == 0) ResizePanels(reFlying);
        }
    }
    void SpawnCastingRods()
    {
        RectTransform rtCasting = castingRodsObject.GetComponent<RectTransform>();
        for (int i = 0; i < castingRods; i++)
        {

            RadnomValues();
            InitRodCard();
            GameObject rodCard = Instantiate(backgroundColorsPrefabs[background], castingRodsObject.transform.GetChild(1).transform, false);
            if (i % 4 == 0) ResizePanels(rtCasting);
        }
    }

    void InitFirstRod()
    {
        Transform oldRod = GameObject.FindGameObjectWithTag("Rod").gameObject.transform;
        GameObject newRod = Instantiate(models[model], oldRod.position, oldRod.rotation).gameObject;
        newRod.transform.SetParent(context);
        newRod.transform.localScale = new Vector3(300, 300, 300);
        newRod.name = "RodModel";
        newRod.tag = "Rod";
        Destroy(oldRod.gameObject);
    }

}
