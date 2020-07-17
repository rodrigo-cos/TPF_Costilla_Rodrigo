/*
 * Created by SharpDevelop.
 * User: Master-Race
 * Date: 9/5/2020
 * Time: 09:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace juegoIA
{
	/// <summary>
	/// Description of DatosJugadas.
	/// </summary>
	public class DatosJugadas
	{
		int carta;
		int limiteActual;
		int ganadas;
		bool esAi;
		
		
		public DatosJugadas(int carta,int limeactual,int ganadas,bool esAi)
		{
			this.carta=carta;
			this.limiteActual=limeactual;
			this.ganadas=ganadas;
			this.esAi=esAi;
		}

		public int Carta
		{
			get{return this.carta;}
		}
		public int LimiteActual
		{
			get{return this.limiteActual;}
		}
		public bool EsAi
		{
			get{return this.esAi;}
		}
		public int Ganadas
		{
			get{return this.ganadas;}
			set{this.ganadas=value;}
		}
		public override string ToString()
		{
			return string.Format("[DatosJugadas Carta={0}, LimiteActual={1}, Ganadas={2}, EsAi={3}]", carta, limiteActual, ganadas, esAi);
		}

	}
}
