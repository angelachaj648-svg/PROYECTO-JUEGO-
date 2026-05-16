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
					case "1":

						Console.Clear();

						Console.WriteLine(
							"Iniciando partida...");

						Console.WriteLine();

						

						Console.ReadKey();

						break;
					case "2":

						MostrarReglas();

						break;

					

					case "3":

						MostrarPuntajes();

						break;

					

					case "4":
					

						salir = true;

						break;

					

					default:

						Console.WriteLine();

						Console.WriteLine(
							"Opción inválida");

						Console.ReadKey();

						break;
				}
			}
		}
		