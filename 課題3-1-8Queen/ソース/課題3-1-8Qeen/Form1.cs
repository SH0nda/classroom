using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 課題3_1_8Qeen
{
	public partial class Form1 : Form
	{
		Control[,] _controls = new Control[8, 8];
		public Form1()
		{
			InitializeComponent();
			GetControls(this);
		}

		int qCount = 0;
		private void Click(object sender, EventArgs e)
		{
			Label label = ((Label)sender);
			if (label.BackColor == Color.Red)
				return;

			label.Text = "Q";
			label.BackColor = Color.Red;


			int num = int.Parse(label.Name.Remove(0, 5));
			for (int i = -(num / 8); i < -(num / 8) + 8; i++)
			{
				int j = i + (num / 8);
				_controls[num / 8, j].BackColor = Color.Red;    //横
				_controls[j, num % 8].BackColor = Color.Red;     //縦

				if (0 <= j && j < 8 && 0 <= ((num % 8) + i) && ((num % 8) + i) < 8)
					_controls[j, (num % 8) + i].BackColor = Color.Red;      //斜め

				if (0 <= j && j < 8 && 0 <= ((num % 8) - i) && ((num % 8) - i) < 8)
					_controls[j, (num % 8) - i].BackColor = Color.Red;      //斜め
			}

			qCount++;
			if (qCount == 8)
			{
				DialogResult result = MessageBox.Show("クリア!",
					"クリア!",
					MessageBoxButtons.OK);
			}
		}

		public void GetControls(Control parent)
		{
			foreach (Control child in parent.Controls)
			{
				_controls[int.Parse(child.Name.Remove(0, 5)) / 8, int.Parse(child.Name.Remove(0, 5)) % 8] = child;
				GetControls(child);
			}
		}
	}
}
