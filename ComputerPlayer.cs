
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
		
		/*public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			//Implementar
			
			this.jugadas=new ArbolGeneral<DatosJugadas>(new DatosJugadas(cartasOponente,cartasPropias,limite,0));
			//inicializar(this.jugadas);
			
		}*/
		
		
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
			
			llenarArbol(this.arbol,cartasPropias,cartasOponentes);
			
			//Invoco el método porNiveles() de la clase ArbolGeneral 
			//this.arbol.porNiveles();
			
			Console.WriteLine("cantidad de cartas disponibles: " + this.arbol.getHijos().Count);
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
			
			return 0;
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
				nodoCarta.getDatoRaiz().Ganadas=0;
			}
			else{
			foreach (int cartaOponente in cartasOponente) {
				DatosJugadas cartaJugadorOponente=new DatosJugadas(cartaOponente,limiteActualizado,0,!nodoCarta.getDatoRaiz().EsAi);
				ArbolGeneral<DatosJugadas> nodoCartaOponente=new ArbolGeneral<DatosJugadas>(cartaJugadorOponente);
				llenarArbol(nodoCartaOponente,cartasOponente,cartasPropiasSinJugada);
				nodoCarta.agregarHijo(nodoCartaOponente);
			}
			}
		}
		
	}
}
