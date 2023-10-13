namespace TennisKata
{
	public interface ITennisGame
	{
		void AddPointToPlayer(string playerName);
		string GetScore();
	}
}