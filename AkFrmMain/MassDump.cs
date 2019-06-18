using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkFrmMain
{
	public class MassDump
	{
		protected Thread thrMass;

		private ProgressBar _bar;

		delegate void ProgressBarHandler(ProgressBar obj, int i);

		public bool bFinished = false;

		public MassDump()
		{
			
		}

		public MassDump(ProgressBar bar)
		{
			_bar = bar;
		}


		public void Run()
		{
			thrMass = new Thread(new ThreadStart(Beep));
			thrMass.Start();
		}

		public void Show(ProgressBar bar , int i)
		{
			if (bar.InvokeRequired)
			{
				ProgressBarHandler obj = new ProgressBarHandler(Show);
				bar.Invoke(obj, bar, i);
			}
			else
			{
				bar.Value = i;
			}


		}

		public void Stop()
		{
			try
			{
				this.thrMass.Abort();
			}
			catch { }
		}


		private void Beep()
		{
			for (int i = 0; i < 100; i++)
			{
				Thread.Sleep(500);

				//if (i % 10 == 0) {
					Show(_bar, i);
				//}
			}
			bFinished = true;
			thrMass.Abort();
		}

	}
}
