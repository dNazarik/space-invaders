namespace Gameplay
{
	public class GameStateController : IGameStateController
	{
		public GameState GameState { get; private set; }

		public void SetState(GameState state) => GameState = state;
	}
}
