namespace Game
{
	public struct Volume
	{
		public Volume(float game, float ui, float music)
		{
			Game = game;
			UI = ui;
			Music = music;
		}

		public float Game { get; set; }
		public float UI { get; set; }
		public float Music { get; set; }
	}
}