using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	public PlayerManager PlayerMG;

	public TextMeshProUGUI Metal;
	public TextMeshProUGUI Copper;
	public TextMeshProUGUI Oil;
	public TextMeshProUGUI Gold;
	public TextMeshProUGUI Gas;

	private void Update()
	{
		Metal.text = "Metal :" + ECSWorld.ECSMG.Get<MetalComponent>(PlayerMG.ECS_EntityID).value.ToString();
		Copper.text = "Copper :" + ECSWorld.ECSMG.Get<CopperComponent>(PlayerMG.ECS_EntityID).value.ToString();
		Oil.text = "Oil :"+ECSWorld.ECSMG.Get<OilComponent>(PlayerMG.ECS_EntityID).value.ToString();
		Gold.text = "Golid :"+ECSWorld.ECSMG.Get<GoldComponent>(PlayerMG.ECS_EntityID).value.ToString();
		Gas.text = "Gas :"+ECSWorld.ECSMG.Get<GasComponent>(PlayerMG.ECS_EntityID).value.ToString();
	}



}

