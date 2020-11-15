using UnityEngine;
using UnityEngine.Playables;
using Zenject;

public class TimelineManager : MonoBehaviour
{
	[SerializeField]
	private PlayableDirector titleDirector;
	[Inject]
	private FloatingObjectGenerator floatingObjectGenerator;

	public void GameStart()
	{
		floatingObjectGenerator.Generate(Vector2Int.zero);
		// GameStateContainer
	}
}
