namespace Menu
{
	internal class Menu
	{

		public void MostrarMenu()
		{
			bool salir = false;
			while (!salir)
			{
				Console.Clear();


				Console.WriteLine("-----------------------------------");
				Console.WriteLine("       JUEGO DE ESTRATEGIAS");
				Console.WriteLine("------------------------------------");

				

				Console.WriteLine("1. Iniciar Partida");
				Console.WriteLine("2. Ver Reglas");
				Console.WriteLine("3. Ver Puntajes");
				Console.WriteLine("4. Salir");

				Console.WriteLine();
				Console.Write("Seleccione una opción: ");

				string opcion =
					Console.ReadLine();
				switch (opcion)
				{ 