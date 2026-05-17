using System;

namespace movimiento_de_pieza
{
	public class GestorTurnos
	{
		public event Action<Jugador> AlCambiarTurno;
		private Jugador turnoActual = Jugador.Blanco;

		public void CambiarTurno()
		{
			turnoActual = turnoActual == Jugador.Blanco ? Jugador.Negro : Jugador.Blanco;
			AlCambiarTurno?.Invoke(turnoActual);
		}

		public bool EsTurnoDe(Jugador jugador)
		{
			return turnoActual == jugador;
		}
	}
}
