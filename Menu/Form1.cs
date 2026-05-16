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
		private void MostrarReglas()
		{
			Console.Clear();

			Console.WriteLine(
				"--------- REGLAS -----------");

			Console.WriteLine();


			Console.WriteLine("REY");
			Console.WriteLine("- Se mueve una casilla");

			Console.WriteLine("- Horizontal");

			Console.WriteLine("- Vertical");

			Console.WriteLine("- Diagonal");


			Console.WriteLine();


			Console.WriteLine("TORRE");
			Console.WriteLine(
				"- Movimiento horizontal");
			Console.WriteLine(
				"- Movimiento vertical");
			Console.WriteLine(
				"- No puede saltar piezas");

			Console.WriteLine();
			Console.WriteLine("SOLDADO");
			Console.WriteLine("- Avanza una casilla");

			Console.WriteLine("- Captura diagonal");

			Console.WriteLine("- No puede retroceder");


			Console.WriteLine();



			Console.WriteLine("OBJETIVO");
			Console.WriteLine(
				"- Capturar el Rey enemigo");

			Console.ReadKey();
		}

		