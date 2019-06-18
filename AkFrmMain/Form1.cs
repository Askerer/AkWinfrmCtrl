using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkFrmMain
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		MassDump objDump;//= new MassDump(this.);

		private void button1_Click(object sender, EventArgs e)
		{
			if (this.button1.Text == "Start")
			{
				this.button1.Text = "End";
				objDump = new MassDump(this.progressBar1);
				objDump.Run();

			}
			else
			{
				this.button1.Text = "Start";
				objDump.Stop();
			}
		}
	}
}
