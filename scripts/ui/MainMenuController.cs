using Godot;

namespace ChronoNexusOdyssey.UI;

public partial class MainMenuController : Control
{
	private Button _newGameBtn;
	private Button _continueBtn;
	private Button _settingsBtn;
	private Button _quitBtn;

	public override void _Ready()
	{
		_newGameBtn = GetNode<Button>("NewGameButton");
		_continueBtn = GetNode<Button>("ContinueButton");
		_settingsBtn = GetNode<Button>("SettingsButton");
		_quitBtn = GetNode<Button>("QuitButton");

		_newGameBtn.Pressed += OnNewGame;
		_continueBtn.Pressed += OnContinue;
		_settingsBtn.Pressed += OnSettings;
		_quitBtn.Pressed += OnQuit;

		_continueBtn.Disabled = true;
	}

	private void OnNewGame()
	{
		Systems.GameManager.Instance.StartNewGame();
	}

	private void OnContinue()
	{
		// TODO: Load saved game
	}

	private void OnSettings()
	{
		// TODO: Open settings menu
	}

	private void OnQuit()
	{
		GetTree().Quit();
	}
}
