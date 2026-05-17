using System;

namespace movimiento_de_pieza
{
	public enum Jugador { Blanco, Negro }
	public enum TipoPieza { Rey, Torre, Soldado }

	public abstract class Pieza
	{
		public TipoPieza Tipo { get; protected set; }
		public Jugador Color { get; protected set; }
		public int Fila { get; set; }
		public int Columna { get; set; }

		protected Pieza(Jugador color, int fila, int columna)
		{
			Color = color;
			Fila = fila;
			Columna = columna;
		}

		public abstract bool EsMovimientoValido(int filaDestino, int colDestino, Pieza[,] tablero);
	}
}
