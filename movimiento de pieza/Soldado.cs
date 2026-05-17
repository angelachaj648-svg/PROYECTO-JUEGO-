namespace movimiento_de_pieza
{
	public class Soldado : Pieza
	{
		public Soldado(Jugador color, int fila, int columna) : base(color, fila, columna)
		{
			Tipo = TipoPieza.Soldado;
		}

		public override bool EsMovimientoValido(int filaDestino, int colDestino, Pieza[,] tablero)
		{
			int direccion = (Color == Jugador.Blanco) ? -1 : 1;
			int inicioFila = (Color == Jugador.Blanco) ? 6 : 1;

			// Movimiento simple
			if (colDestino == Columna && filaDestino == Fila + direccion && tablero[filaDestino, colDestino] == null)
				return true;

			// Primer movimiento: dos casillas
			if (colDestino == Columna && Fila == inicioFila && filaDestino == Fila + 2 * direccion && tablero[Fila + direccion, Columna] == null && tablero[filaDestino, colDestino] == null)
				return true;

			// Captura diagonal
			if (System.Math.Abs(colDestino - Columna) == 1 && filaDestino == Fila + direccion && tablero[filaDestino, colDestino] != null && tablero[filaDestino, colDestino].Color != Color)
				return true;

			return false;
		}
	}
}
