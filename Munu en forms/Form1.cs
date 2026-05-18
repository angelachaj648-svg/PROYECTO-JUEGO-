using System;
using System.Windows.Forms;
using movimiento_de_pieza;

namespace Juego_de_Estrategias
{
	public partial class FormMenu : Form
	{
		public FormMenu()
		{
			InitializeComponent();
		}
		private void iniciarToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Abrir la ventana principal del juego
			var juego = new movimiento_de_pieza.Form1();
			juego.Show();
			this.Hide();
		}

		private void reglasToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show(
				"REY: una casilla\n" +
				"TORRE: horizontal y vertical\n" +
				"SOLDADO: avanza y captura diagonal");
		}
		

        private void puntajesToolStripMenuItem_Click(
			object sender,
			EventArgs e)
		{
			MessageBox.Show(
				"Puntaje máximo: 120");
		}

		private void salirToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}


