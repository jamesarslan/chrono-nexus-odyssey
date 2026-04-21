using Godot;

namespace ChronoNexusOdyssey.Systems;

public partial class GameManager : Node
{
	public static GameManager Instance { get; private set; }

	public enum GameState { MainMenu, Playing, Paused, Cutscene, Loading }
	public GameState CurrentState { get; private set; } = GameState.MainMenu;

	public int NexusEnergy { get; set; }
	public int PlayerLevel { get; set; } = 1;

	public override void _Ready()
	{
		Instance = this;
		ProcessMode = ProcessModeEnum.Always;
	}

	public void ChangeState(GameState newState)
	{
		CurrentState = newState;
		GetTree().Paused = newState == GameState.Paused;
	}

	public void LoadScene(string scenePath)
	{
		ChangeState(GameState.Loading);
		GetTree().ChangeSceneToFile(scenePath);
	}

	public void StartNewGame()
	{
		NexusEnergy = 0;
		PlayerLevel = 1;
		LoadScene("res://scenes/hub/AetherVessel.tscn");
		ChangeState(GameState.Playing);
	}
}
