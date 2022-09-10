namespace Gameplay
{
	public interface IGameStateController
	{
		GameState GameState { get; }
		void SetState(GameState state);
	}
}