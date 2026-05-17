namespace Menu
{
	namespace Juego_de_Estrategias
	{
		internal static class Program
		{
			[STAThread]

			static void Main()
			{
				Application.EnableVisualStyles();

				Application.SetCompatibleTextRenderingDefault(false);

				Application.Run(new FormMenu());
			}
		}
	}