using Munu_en_forms;
using System;
using System.Windows.Forms;

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

		