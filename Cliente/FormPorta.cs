using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
	public partial class FormPorta : Form
	{
		public int Id;
	

		public FormPorta()
		{
			InitializeComponent();
		}
		private void btnIniciar_Click(object sender, EventArgs e)
		{
			if (int.TryParse(nOprocesso.Text, out Id) == false || Id < 1 || Id > 3)
			{
				MessageBox.Show("Digite um numero de 1 a a 3 para criar o processo");
			}
			else
			{
				//OK!
				DialogResult = System.Windows.Forms.DialogResult.OK;
			}
		}
	}
}
