using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Cliente
{
	public partial class FormCI : Form
	{
		private int id, seqLocal, maiorExt;
		private bool secaoCriticaRequisitada, estouControlando, alive;
		private int repliesNaoRecebidos;
		private bool[] repliesDeferidos = new bool[3];
		private Thread thread;
		private Socket socket;
		public FormCI()
		{
			InitializeComponent();
			btnPausarMovimento.Enabled = false;
			btnReiniciar.Enabled = false;
			btnLiberarControle.Enabled = false;


		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			//mostrar form para perguntar o id
			FormPorta f = new FormPorta();
			if (f.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				id = f.Id;
				this.Text = "Processo " + id;
			}
			else
			{
				Close();
			}
			//Cria o soquete, especificando UDP/IP
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			//Associa o soquete criado a uma porta no computador local, e começa a
			//escutar por conexões de entrada (o valor 32 diz que o SO deve armazenar
			//até 32 conexões pendentes, caso nós não sejamos tão rápidos para
			//processá-las)
			socket.Bind(new IPEndPoint(IPAddress.Any, 6000 + id));
			alive = true;
			thread = new Thread(CorpoDaThread);
			thread.Start();
		}
		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			alive = false;
			if (socket != null)
				socket.Close();
			base.OnFormClosing(e);
		}
		private void EnviarRequest(int paraQuem)
		{
			if (seqLocal <= maiorExt)
			{
				seqLocal = maiorExt + 1;
			}
			EndPoint ep = new IPEndPoint(IPAddress.Loopback, 6000 + paraQuem);
			byte[] buffer = new byte[2];
			buffer[0] = (byte)id;
			buffer[1] = (byte)seqLocal;
			socket.SendTo(buffer, ep);
			   repliesNaoRecebidos = repliesNaoRecebidos + 1;
		}
		private void RequestRecebido(int deQuem, int relogioExterno) //y é o deQuem
		{
			if (maiorExt < relogioExterno)//relogio externo é a seq y
			{
				maiorExt = relogioExterno;
			}

			if (estouControlando == true)
			{
				repliesDeferidos[deQuem - 1] = true;
			}
			else if (secaoCriticaRequisitada == false)
			{
				EnviarReply(deQuem);
			}
			else if (seqLocal < relogioExterno)
			{
				repliesDeferidos[deQuem - 1] = true;
			}
			else if (seqLocal > relogioExterno)
			{
				EnviarReply(deQuem);
			}
			else if (id < deQuem)//processo x é o id
			{
				repliesDeferidos[deQuem - 1] = true;
			}
			else {
				EnviarReply(deQuem);
			}
		}
		private void EnviarReply(int paraQuem)
		{
			EndPoint ep = new IPEndPoint(IPAddress.Loopback, 6000 + paraQuem);
			byte[] buffer = new byte[1];
			buffer[0] = 0;
			socket.SendTo(buffer, ep);
		}
		private void EnviarTerminoMovimento()
		{
			EndPoint ep = new IPEndPoint(IPAddress.Loopback, 6000);
			byte[] buffer = new byte[1];
			buffer[0] = 0;
			socket.SendTo(buffer, ep);
		}
		private void StartMovimento()
		{
			EndPoint ep = new IPEndPoint(IPAddress.Loopback, 6000);
			byte[] buffer = new byte[1];
			buffer[0] = 1;
			socket.SendTo(buffer, ep);
		}

		private void CorpoDaThread()
		{
			while (alive)
			{
				try
				{
					EndPoint ep = new IPEndPoint(IPAddress.Any, 0);
					//Aqui o servidor primeiro recebe dados, depois envia outros!
					byte[] buffer = new byte[2];
					socket.ReceiveFrom(buffer, ref ep);
					if (buffer[0] == 0)
					{
						//recebi reply!
						Invoke(new Action(ReplyRecebido));
					}
					else
					{
						//recebi request!
						Invoke(new Action(() =>
						{
							RequestRecebido(buffer[0], buffer[1]);
						}));
					}
				}
				catch
				{
				}
			}
		}
		private void ReplyRecebido()
		{
			//aqui é uma funça que é execultada depois de eu ter pedido
		
			this.repliesNaoRecebidos = repliesNaoRecebidos - 1;
			if (repliesNaoRecebidos == 0)
			{
				this.estouControlando = true;
				btnIniciar.Enabled = false;
				btnPausarMovimento.Enabled = true;
				btnReiniciar.Enabled = true;
				btnLiberarControle.Enabled = true;
				
			}
			if (repliesNaoRecebidos > 0)
			{
				return;
			}

		}

		private void btnIniciar_Click(object sender, EventArgs e)
		{
		
			if (secaoCriticaRequisitada == false && estouControlando == false)
			{

				secaoCriticaRequisitada = true;
			
				//verificar que id que é
				if(id ==1){
					EnviarRequest(2);
					EnviarRequest(3);
					
				}
				else if (id == 2)
				{
					EnviarRequest(1);
					EnviarRequest(3);
					
				}
				else {
					EnviarRequest(1);
					EnviarRequest(2);
					
				}
			}
		}
		private void btnPausarMovimento_Click(object sender, EventArgs e)
		{
			if (estouControlando == true)
			{
				EnviarTerminoMovimento();
			}
		}

		private void btnReiniciar_Click(object sender, EventArgs e)
		{
			if (estouControlando == true)
			{
				StartMovimento();	
			}
		}
		private void btnLiberarControle_Click(object sender, EventArgs e)
		{//liberando os controles
			if (estouControlando == true)
			{
				btnLiberarControle.Enabled = false;
				btnPausarMovimento.Enabled = false;
				btnReiniciar.Enabled = false;
				btnIniciar.Enabled = true;
				secaoCriticaRequisitada = false;
				estouControlando = false;

				if (this.repliesDeferidos[0] == true)
				{
					//enviando reply para o processo  e deferindo os replies da posição 
					// dizendo que nao dfoi deferido
					EnviarReply(1);
					repliesDeferidos[0] = false;
				}

				if (this.repliesDeferidos[1] == true)
				{
					//enviando reply para o processo 2 e deferindo os replies da posição 
					// dizendo que nao dfoi deferido
					EnviarReply(2);
					repliesDeferidos[1] = false;
				}

				if (this.repliesDeferidos[2] == true)
				{
					//enviando reply para o processo  e deferindo os replies da posição 
					// dizendo que nao dfoi deferido
					EnviarReply(3);
					repliesDeferidos[2] = false;
				}



			}
			
		}


	}
}
