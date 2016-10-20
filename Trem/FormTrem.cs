using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Trem
{
	public partial class FormTrem : Form
	{
		private Socket socket;
		private Thread thread;
		private bool alive;
        private string recebido;

		public FormTrem()
		{
			InitializeComponent();

			//Cria o soquete, especificando UDP/IP
			socket = new Socket(
				AddressFamily.InterNetwork,
				SocketType.Dgram,
				ProtocolType.Udp);

			socket.Bind(new IPEndPoint(IPAddress.Any, 6000));

			alive = true;
			thread = new Thread(CorpoDaThread);
			thread.Start();
		}

		protected override void OnFormClosed(FormClosedEventArgs e)
		{
			//Pede para terminar a thread e aguarda seu término
			alive = false;
			socket.Close();
			socket.Dispose();
			thread.Join();
			
			base.OnFormClosed(e);
		}

		private void CorpoDaThread()
		{
			byte[] buffer = new byte[1];
			while (alive)
			{
				try
				{
					int qtRecebida = socket.Receive(buffer);
                    recebido  = Encoding.UTF8.GetString(buffer, 0, qtRecebida);
				
						Invoke(new Action(() =>
						{
							tempo.Enabled = (buffer [0] == 1);
						}));
                    
				}
				catch
				{

				}
			}
		}

		private void tempo_Tick(object sender, EventArgs e)
		{

			//fazendo o trenzinho andar e a velocicade do trem :)
			trem.Left = trem.Left + 1;
			if (trem.Left > ClientSize.Width)
			{
				trem.Left = 0;
			}
		}

		
		
	}
}
