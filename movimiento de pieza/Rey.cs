namespace movimiento_de_pieza
{
	public class Rey : Pieza
	{
		public Rey(Jugador color, int fila, int columna) : base(color, fila, columna)
		{
			Tipo = TipoPieza.Rey;
		}

		public override bool EsMovimientoValido(int filaDestino, int colDestino, Pieza[,] tablero)
		{
			int df = System.Math.Abs(filaDestino - Fila);
			int dc = System.Math.Abs(colDestino - Columna);
			return (df <= 1 && dc <= 1) && !(df == 0 && dc == 0);
		}
	}
}
