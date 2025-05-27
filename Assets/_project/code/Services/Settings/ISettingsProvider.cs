using System.Threading.Tasks;
using Services.Settings.Configs.App;
using Services.Settings.Configs.Game;

namespace Services.Settings
{
	public interface ISettingsProvider
	{
		AppSettings AppSettings { get; }
		GameSettings GameSettings { get; }

		Task<GameSettings> LoadGameSettingsAsync();
	}
}