
using System;
using System.Collections.Generic;
using System.Linq;

namespace juegoIA
{
	public class ComputerPlayer: Jugador
	{
		private ArbolGeneral<DatosJugadas> jugadas;
		
		
		public ComputerPlayer()
		{
			
		}
		
		public override void  incializar(List<int> cartasPropias, List<int> cartasOponente, int limite)
		{
			//Implementar
			
			this.jugadas=new ArbolGeneral<DatosJugadas>(new DatosJugadas(cartasOponente,cartasPropias,limite,0));
			//inicializar(this.jugadas);
			
		}
		
		public void inicializar(ArbolGeneral<DatosJugadas> nodoActual,List<int>cartasPropias,List<int>cartasOponentes)
		{
			/*foreach (int cartaOponente in cartasOponentes) {
				ArbolGeneral<DatosJugadas>jugadaOponente=new ArbolGeneral<DatosJugadas>();
				nodoActual.getHijos().Add(jugadaOponente);
				inicializar(jugadaOponente,cartasOponentes,cartasPropias);
				List<int> cartasDisponibles=cartasOponentes.CopyTo;
				inicializar(jugadaOponente,cartasOponentes,cartasPropias);
					
			}*/
		}
		
		public override int descartarUnaCarta()
		{
			//Implementar
			return 0;
		}
		
		public override void cartaDelOponente(int carta)
		{
			//implementar
			
		}
		
	}
}
