using UnityEngine;
using UniRx;

public class GameStateContainer
{
	private ReactiveProperty<GameState> _stateProperty = new ReactiveProperty<GameState>(GameState.Launch);
	public IReactiveProperty<GameState> stateProperty { get { return _stateProperty; } }

	void ChangeState(GameState state)
	{
		_stateProperty.Value = state;
	}
}

public enum GameState
{
	Launch = 0,
	Title = 1,
	Game = 2,
	GameOver = 3
}
