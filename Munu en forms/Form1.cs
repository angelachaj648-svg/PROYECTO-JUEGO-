using Munu_en_forms;
using System;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Juego_de_Estrategias
{
	public partial class FormMenu : Form
	{
		public FormMenu()
		{
			InitializeComponent();
		}
		private void iniciarToolStripMenuItem_Click(
			object sender,
			EventArgs e)
		{
			Form1 login =
				new Form1();

			login.Show();

			Hide();
		}

		private void reglasToolStripMenuItem_Click(object sender,
			
			EventArgs e)
		{
			MessageBox.Show(
				"REY: una casilla" +
				"TORRE: horizontal y vertical" +
				"SOLDADO: avanza y captura diagonal");
		}
		

        private void puntajesToolStripMenuItem_Click(
			object sender,
			EventArgs e)
		{
			MessageBox.Show(
				"Puntaje máximo: 120");
		}

		private void salirToolStripMenuItem_Click(bject sender,
			
			EventArgs e)
		{
			Application.Exit();
		}
	}
}


