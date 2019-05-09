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
    new int name;

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
    /// <summary>
    /// Function that chooses random icon, background, model and name for generated rodcard
    /// </summary>
    void RadnomValues()
    {
        icon = Random.Range(0, rodsIcons.Length);
        background = Random.Range(0, backgroundColorsPrefabs.Length);
        model = Random.Range(0, models.Length);
    }
    /// <summary>
    /// Initialize rod card with choosen valuses, name of every rod have the same index as its icon
    /// </summary>
    void BuildRodCard()
    {
        backgroundColorsPrefabs[background].transform.GetChild(1).GetComponentInChildren<Text>().text = names[icon];
        backgroundColorsPrefabs[background].transform.GetChild(2).transform.GetChild(0).GetComponent<Image>().sprite = rodsIcons[icon];
        backgroundColorsPrefabs[background].transform.GetChild(5).GetComponent<RodCardPressed>().rod = models[model];
    }
    /// <summary>
    /// Resizes given panel for scroll to work correctly 
    /// </summary>
    /// <param name="rt"></param>
    void ResizePanels(RectTransform rt)
    {
        rt.sizeDelta += new Vector2(0, spinningRodsObject.transform.GetChild(1).transform.GetComponent<GridLayoutGroup>().cellSize.y);
        transform.parent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, spinningRodsObject.transform.GetChild(1).transform.GetComponent<GridLayoutGroup>().cellSize.y);
    }
    /// <summary>
    /// Spawns the number of spinning rods given in inspector
    /// </summary>
    void SpawnSpinningRods()
    {
        RectTransform rtSpinning = spinningRodsObject.GetComponent<RectTransform>();
        for (int i=0;i<spinningRods;i++)
        {

            RadnomValues();
            BuildRodCard();
            GameObject rodCard = Instantiate(backgroundColorsPrefabs[background], spinningRodsObject.transform.GetChild(1).transform, false);
            if (i == 0) rodCard.transform.GetChild(4).gameObject.SetActive(true);

            if (i % 4 == 0)  ResizePanels(rtSpinning);    
        }
    }
    /// <summary>
    /// Spawns the number of fly rods given in inspector
    /// </summary>
    void SpawnFlyRods()
    {
        RectTransform reFlying = flyRodsObject.GetComponent<RectTransform>();
        for (int i = 0; i < flyRods; i++)
        {

            RadnomValues();
            BuildRodCard();
            GameObject rodCard = Instantiate(backgroundColorsPrefabs[background], flyRodsObject.transform.GetChild(1).transform, false);
            if (i % 4 == 0) ResizePanels(reFlying);
        }
    }
    /// <summary>
    /// Spawns the number of casting rods given in inspector
    /// </summary>
    void SpawnCastingRods()
    {
        RectTransform rtCasting = castingRodsObject.GetComponent<RectTransform>();
        for (int i = 0; i < castingRods; i++)
        {

            RadnomValues();
            BuildRodCard();
            GameObject rodCard = Instantiate(backgroundColorsPrefabs[background], castingRodsObject.transform.GetChild(1).transform, false);
            if (i % 4 == 0) ResizePanels(rtCasting);
        }
    }
    /// <summary>
    /// Initialize first rod setting its name, tag and scale
    /// </summary>
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
