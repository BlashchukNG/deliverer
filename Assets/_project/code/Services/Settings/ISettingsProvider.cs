using System.Threading.Tasks;

namespace Services.Settings
{
	public interface ISettingsProvider
	{
		AppSettings AppSettings { get; }
		GameSettings GameSettings { get; }

		Task<GameSettings> LoadGameSettingsAsync();
	}
}