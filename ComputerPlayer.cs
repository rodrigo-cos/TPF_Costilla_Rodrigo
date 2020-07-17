
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{
	public class ComputerPlayer: Jugador
	{
		private ArbolGeneral<DatosJugadas> arbol;
		
		//private ArbolGeneral<int>arbol;
		
		private List<int> naipes=new List<int>();
		
		
		
		
		public ComputerPlayer()
		{
			
			//arbol=new ArbolGeneral<int>(-1);
			
		}
		
		
		public override void incializar(List<int> cartasPropias,List<int> cartasOponentes,int limite)
		{
			//creo 2 listas y las agrego
			DatosJugadas inicial=new DatosJugadas(-1,limite,0,true);
			arbol=new ArbolGeneral<DatosJugadas>(inicial);
			
			/*List<int> cartPro=new List<int>();
			List<int> cartOpo=new List<int>();
			cartOpo.Add(1);
			cartOpo.Add(3);
			cartPro.Add(2);
			cartPro.Add(4);*/
			
			//llenarArbol(this.arbol,cartasPropias,cartasOponentes);
			//this.arbol.porNiveles();
			
			this.naipes=cartasPropias;
			
			
			llenarArbol(this.arbol,cartasPropias,cartasOponentes);
			
			//Invoco el método porNiveles() de la clase ArbolGeneral 
			//this.arbol.porNiveles();
			
			//Console.WriteLine("cantidad de cartas disponibles: " + this.arbol.getHijos().Count);
			
			Console.WriteLine("cantidad de victorias en total para la pc: {0} ",this.arbol.getDatoRaiz().Ganadas);
			
		}
		
		public override int descartarUnaCarta()
		{
			//Implementar
				Console.WriteLine("Naipes disponibles (Computer):");
			for (int i = 0; i < naipes.Count; i++) {
				Console.WriteLine(naipes[i].ToString());
				if (i<naipes.Count-1) {
					Console.Write("","");
				}
			}
			
			Console.WriteLine();
			int max=-99999;
			ArbolGeneral<DatosJugadas>mejorEle=new ArbolGeneral<DatosJugadas>(null);
				
				foreach (ArbolGeneral<DatosJugadas> hijo in this.arbol.getHijos()) {
				if(hijo.getDatoRaiz().Ganadas>max)
					max=hijo.getDatoRaiz().Ganadas;
				    mejorEle=hijo;
				}
			
		
			this.arbol=mejorEle;
			Console.WriteLine("carta jugada {0}",mejorEle.getDatoRaiz().Carta);
			return mejorEle.getDatoRaiz().Carta;
		}
		
		public override void cartaDelOponente(int carta)
		{
			//lo que hay que hacer es elegir al hijo que corresponde a esa carta
			
			//implementar
			
			foreach (ArbolGeneral<DatosJugadas> hijo in this.arbol.getHijos()) {
				if(hijo.getDatoRaiz().Carta==carta)
				{
					this.arbol=hijo;
					return;
				}
			}
			
			
		}
		private void llenarArbol(ArbolGeneral<DatosJugadas>nodoCarta,List<int> cartasPropias,List<int> cartasOponente)
		{
			List<int>cartasPropiasSinJugada=new List<int>(cartasPropias);
			
			cartasPropiasSinJugada.Remove(nodoCarta.getDatoRaiz().Carta);
			
			int limiteActualizado=nodoCarta.getDatoRaiz().LimiteActual - nodoCarta.getDatoRaiz().Carta;
			
			if(limiteActualizado<0)
			{
				if(nodoCarta.getDatoRaiz().EsAi){
					nodoCarta.getDatoRaiz().Ganadas=-1;
				}else{
			
				nodoCarta.getDatoRaiz().Ganadas=1;
				}
		}else{
			foreach (int cartaOponente in cartasOponente) {
				DatosJugadas cartaJugadorOponente=new DatosJugadas(cartaOponente,limiteActualizado,0,!nodoCarta.getDatoRaiz().EsAi);
				ArbolGeneral<DatosJugadas> nodoCartaOponente=new ArbolGeneral<DatosJugadas>(cartaJugadorOponente);
				llenarArbol(nodoCartaOponente,cartasOponente,cartasPropiasSinJugada);
				nodoCarta.agregarHijo(nodoCartaOponente);
				nodoCarta.getDatoRaiz().Ganadas+=nodoCartaOponente.getDatoRaiz().Ganadas;
		}
				//Console.WriteLine(nodoCarta.getDatoRaiz());
		
	}
		}}}