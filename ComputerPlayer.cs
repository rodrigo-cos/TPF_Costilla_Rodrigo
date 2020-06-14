
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{
	public class ComputerPlayer: Jugador
	{
		private ArbolGeneral<DatosJugadas> jugadas;
		
		private ArbolGeneral<int>arbol;
		
		private List<int> naipes=new List<int>();
		
		
		public ComputerPlayer()
		{
			arbol=new ArbolGeneral<int>(-1);
		}
		
		/*public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			//Implementar
			
			this.jugadas=new ArbolGeneral<DatosJugadas>(new DatosJugadas(cartasOponente,cartasPropias,limite,0));
			//inicializar(this.jugadas);
			
		}*/
		
		public void inicializar(ArbolGeneral<DatosJugadas> nodoActual,List<int>cartasPropias,List<int>cartasOponentes)
		{
			foreach (int cartaOponente in cartasOponentes) {
				ArbolGeneral<DatosJugadas>jugadaOponente=new ArbolGeneral<DatosJugadas>(new DatosJugadas(cartasOponentes,cartasPropias,0,0));
				nodoActual.getHijos().Add(jugadaOponente);
				inicializar(jugadaOponente,cartasOponentes,cartasPropias);
				//List<int> cartasDisponibles=cartasOponentes.CopyTo;
				
				
				inicializar(jugadaOponente,cartasOponentes,cartasPropias);
					
			}
		}
		
		public override void incializar(List<int> cartasPropias,List<int> cartasOponentes,int limite)
		{
			//creo 2 listas y las agrego
			
			List<int> cartPro=new List<int>();
			List<int> cartOpo=new List<int>();
			cartOpo.Add(1);
			cartOpo.Add(3);
			cartPro.Add(2);
			cartPro.Add(4);
			
			//llenarArbol(this.arbol,cartasPropias,cartasOponentes);
			//this.arbol.porNiveles();
			
			llenarArbol(this.arbol,cartPro,cartOpo);
			
			//Invoco el método porNiveles() de la clase ArbolGeneral 
			this.arbol.porNiveles();
			
			Console.WriteLine(this.arbol.getHijos().Count);
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
			//implementar
			
		}
		private void llenarArbol(ArbolGeneral<int>nodoCarta,List<int> cartasPropias,List<int> cartasOponente)
		{
			List<int>cartasPropiasSinJugada=new List<int>(cartasPropias);
			cartasPropiasSinJugada.Remove(nodoCarta.getDatoRaiz());
			foreach (int cartaOponente in cartasOponente) {
				ArbolGeneral<int> nodoCartaOponente=new ArbolGeneral<int>(cartaOponente);
				llenarArbol(nodoCartaOponente,cartasOponente,cartasPropiasSinJugada);
				nodoCarta.agregarHijo(nodoCartaOponente);
			}
		}
		
	}
}
