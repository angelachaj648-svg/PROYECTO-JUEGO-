using System;
using System.Drawing;
using System.Windows.Forms;

namespace movimiento_de_pieza
{
	public partial class Form1 : Form
	{
		private GestorTurnos gestor; // Instancia de nuestra clase
		private Panel[,] casillas = new Panel[8, 8];
		private Pieza[,] tableroLogico = new Pieza[8, 8];
		private Pieza piezaSeleccionada = null;
		private int filaSeleccionada = -1;
		private int columnaSeleccionada = -1;

		public Form1()
		{
			InitializeComponent();
			gestor = new GestorTurnos();

			// Suscribirse al evento para actualizar un Label o título en la interfaz
			gestor.AlCambiarTurno += ActualizarInterfazTurno;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			InicializarPiezas();
			CrearTablero();
			DibujarPiezas();
		}

		private void CrearTablero()
		{
			int tamañoCasilla = 60;

			for (int fila = 0; fila < 8; fila++)
			{
				for (int columna = 0; columna < 8; columna++)
				{
					Panel casilla = new Panel();
					casilla.Size = new Size(tamañoCasilla, tamañoCasilla);
					casilla.Location = new Point(columna * tamañoCasilla, fila * tamañoCasilla);

					if ((fila + columna) % 2 == 0)
						casilla.BackColor = Color.White;
					else
						casilla.BackColor = Color.Gray;

					casilla.Name = $"Casilla_{fila}_{columna}";
					casilla.Tag = new Point(fila, columna);
					casilla.Click += Casilla_Click;

					this.Controls.Add(casilla);
					casillas[fila, columna] = casilla;
				}
			}
		}

		private void DibujarPiezas()
		{
			for (int f = 0; f < 8; f++)
			{
				for (int c = 0; c < 8; c++)
				{
					casillas[f, c].Controls.Clear();
				}
			}

			for (int fila = 0; fila < 8; fila++)
			{
				for (int columna = 0; columna < 8; columna++)
				{
					Pieza pieza = tableroLogico[fila, columna];

					if (pieza != null)
					{
						Label lbl = new Label();
						lbl.Dock = DockStyle.Fill;
						lbl.TextAlign = ContentAlignment.MiddleCenter;

						if (pieza.Tipo == TipoPieza.Rey)
							lbl.Text = "R";
						else if (pieza.Tipo == TipoPieza.Torre)
							lbl.Text = "T";
						else if (pieza.Tipo == TipoPieza.Soldado)
							lbl.Text = "S";

						casillas[fila, columna].Controls.Add(lbl);
					}
				}
			}
		}

		private void Casilla_Click(object sender, EventArgs e)
		{
			Panel casilla = sender as Panel;
			if (casilla == null) return;

			Point posicion = (Point)casilla.Tag;
			int fila = posicion.X;
			int columna = posicion.Y;

			if (piezaSeleccionada == null)
			{
				Pieza pieza = tableroLogico[fila, columna];

				if (pieza != null && gestor.EsTurnoDe(pieza.Color))
				{
					piezaSeleccionada = pieza;
					filaSeleccionada = fila;
					columnaSeleccionada = columna;
					MostrarMovimientos();
				}
			}
			else
			{
				bool movimiento = IntentarMover(filaSeleccionada, columnaSeleccionada, fila, columna);

				LimpiarColores();

				piezaSeleccionada = null;
				filaSeleccionada = -1;
				columnaSeleccionada = -1;

				if (movimiento)
				{
					gestor.CambiarTurno();
					DibujarPiezas();
				}
			}
		}
		private void MostrarMovimientos()
		{
			LimpiarColores();

			for (int fila = 0; fila < 8; fila++)
			{
				for (int columna = 0; columna < 8; columna++)
				{
					if (piezaSeleccionada
						.EsMovimientoValido(
							fila,
							columna,
							tableroLogico))
					{
						casillas[fila, columna]
							.BackColor =
								Color.Yellow;
					}
				}
			}
		}
	
		private void MostrarMovimientos()
		{
			// Implementación mínima: resalta la casilla seleccionada
			if (filaSeleccionada >= 0 && columnaSeleccionada >= 0)
			{
				casillas[filaSeleccionada, columnaSeleccionada].BackColor = Color.LightGreen;
			}
		}

		private void LimpiarColores()
		{
			for (int fila = 0; fila < 8; fila++)
			{
				for (int columna = 0; columna < 8; columna++)
				{
					casillas[fila, columna].BackColor = ((fila + columna) % 2 == 0) ? Color.White : Color.Gray;
				}
			}
		}

		private void ActualizarInterfazTurno(Jugador nuevoTurno)
		{
			this.Text = "Juego de Ajedrez - Turno de: " + nuevoTurno.ToString();
		}

		// Ejemplo de cómo usarlo cuando un jugador hace un movimiento válido
		private void FinalizarMovimiento()
		{
			gestor.CambiarTurno();
		}

		// Ejemplo de cómo inicializar tus piezas:
		public void InicializarPiezas()
		{
			// Blancas (en la fila 7)
			tableroLogico[7, 4] = new Rey(Jugador.Blanco, 7, 4);
			tableroLogico[7, 0] = new Torre(Jugador.Blanco, 7, 0);
			tableroLogico[7, 7] = new Torre(Jugador.Blanco, 7, 7);

			// 4 Soldados blancos (en la fila 6)
			for (int i = 2; i < 6; i++)
				tableroLogico[6, i] = new Soldado(Jugador.Blanco, 6, i);
		}

		// Método público para preparar un escenario de pruebas con piezas contrarias
		public void PrepararEscenarioPruebas()
		{
			// Inicializa las piezas blancas
			InicializarPiezas();

			// Colocar algunas piezas negras para pruebas de captura
			tableroLogico[5, 3] = new Torre(Jugador.Negro, 5, 3);
			tableroLogico[0, 0] = new Rey(Jugador.Negro, 0, 0);
		}

		public bool IntentarMover(int filaOrigen, int colOrigen, int filaDestino, int colDestino)
		{
			Pieza piezaAtacante = tableroLogico[filaOrigen, colOrigen];
			Pieza piezaObjetivo = tableroLogico[filaDestino, colDestino];

			// 1. Validar que haya una pieza en el origen
			if (piezaAtacante == null) return false;

			// 2. Validar que el movimiento sea legal para esa pieza
			if (!piezaAtacante.EsMovimientoValido(filaDestino, colDestino, tableroLogico)) return false;

			// 3. Lógica de captura
			if (piezaObjetivo != null)
			{
				// Si es del mismo color, no se puede mover ahí
				if (piezaObjetivo.Color == piezaAtacante.Color)
					return false;

				// Si es color opuesto, la capturamos
				JuegoUtilidades.CapturarPieza(piezaObjetivo);
			}

			// 4. Ejecutar el movimiento en la matriz
			tableroLogico[filaDestino, colDestino] = piezaAtacante;
			tableroLogico[filaOrigen, colOrigen] = null;

			// Actualizar coordenadas internas de la pieza
			piezaAtacante.Fila = filaDestino;
			piezaAtacante.Columna = colDestino;

			return true;
		}

		private void ReiniciarJuego()
		{
			// 1. Resetear el gestor de turnos
			gestor = new GestorTurnos();

			// Volver a suscribir el evento para actualizar la interfaz
			gestor.AlCambiarTurno += ActualizarInterfazTurno;

			// 2. Limpiar la matriz lógica (borrar piezas anteriores)
			Array.Clear(tableroLogico, 0, tableroLogico.Length);

			// 3. Volver a colocar las piezas en sus posiciones iniciales
			InicializarPiezas();

			// 4. Limpiar la interfaz gráfica y volver a dibujarla
			this.Controls.Clear(); // Quita todos los paneles actuales
			CrearTablero();        // Llama a la función que dibuja el tablero y las piezas

			MessageBox.Show("El juego ha sido reiniciado. Turno de Blancas.");
		}
	}
}
