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
		private List<int>cartasRestantesOponentes;
		private List<int>cartasRestantesAI;
		private double chancesDeGanar=0.0;
		private int sumaParcial;
		
		public DatosJugadas(List<int> cartasRestantesOponentes,List<int>cartasRestanteasAi,int limite,int sumaPadre)
		{
			this.cartasRestantesAI=cartasRestanteasAi;
			this.cartasRestantesOponentes=cartasRestantesOponentes;
			this.sumaParcial=sumaPadre;
		}
		
		public double ChancesDeGanar
		{
			get{return this.chancesDeGanar;}
			set{this.chancesDeGanar=value;}
		}
		public List<int>CartasRestantesOponente
		{
			get{return this.cartasRestantesOponentes;}
			set{this.cartasRestantesOponentes=value;}
		}
		
		public List<int>CartasRestantesAi
		{
			get{return this.cartasRestantesAI;}
			set{this.cartasRestantesAI=value;}
		}
	}
}
