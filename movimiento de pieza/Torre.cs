namespace movimiento_de_pieza
{
	public class Torre : Pieza
	{
		public Torre(Jugador color, int fila, int columna) : base(color, fila, columna)
		{
			Tipo = TipoPieza.Torre;
		}

		public override bool EsMovimientoValido(int filaDestino, int colDestino, Pieza[,] tablero)
		{
			if (filaDestino != Fila && colDestino != Columna) return false;

			int pasoFila = filaDestino == Fila ? 0 : (filaDestino > Fila ? 1 : -1);
			int pasoCol = colDestino == Columna ? 0 : (colDestino > Columna ? 1 : -1);

			int f = Fila + pasoFila;
			int c = Columna + pasoCol;
			while (f != filaDestino || c != colDestino)
			{
				if (tablero[f, c] != null) return false;
				f += pasoFila;
				c += pasoCol;
			}

			return true;
		}
	}
}
