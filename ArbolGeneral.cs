using System;
using System.Collections.Generic;

namespace juegoIA
{
	public class ArbolGeneral<T>
	{
		private NodoGeneral<T> raiz;

		public ArbolGeneral(T dato) {
			this.raiz = new NodoGeneral<T>(dato);
		}
	
		private ArbolGeneral(NodoGeneral<T> nodo) {
			this.raiz = nodo;
		}
	
		private NodoGeneral<T> getRaiz() {
			return raiz;
		}
	
		public T getDatoRaiz() {
			return this.getRaiz().getDato();
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			List<ArbolGeneral<T>> temp= new List<ArbolGeneral<T>>();
			foreach (var element in this.raiz.getHijos()) {
				temp.Add(new ArbolGeneral<T>(element));
			}
			return temp;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.raiz.getHijos().Add(hijo.getRaiz());
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.raiz.getHijos().Remove(hijo.getRaiz());
		}
	
		public bool esVacio() {
			return this.raiz == null;
		}
	
		public bool esHoja() {
			return this.raiz != null && this.getHijos().Count == 0;
		}
	
		public void preOrden(){
			// Procesamos raiz
			Console.Write(this.getDatoRaiz() + " ");
			
			// Hago recursion en todos los hijos
			if(!this.esHoja()){
				List<ArbolGeneral<T>> listaHijos = this.getHijos();
				foreach(var hijo in listaHijos)
					hijo.preOrden();
			}
		}
		
		public void postOrden(){					
			// Hago recursion en todos los hijos
			if(!this.esHoja()){
				List<ArbolGeneral<T>> listaHijos = this.getHijos();
				foreach(var hijo in listaHijos)
					hijo.postOrden();
			}			
			// Procesamos raiz
			Console.Write(this.getDatoRaiz() + " ");
		}
		
		public void porNiveles(){
			Cola<ArbolGeneral<T>> c  = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolAux;
			
			c.encolar(this);
			while(!c.esVacia()){
				arbolAux = c.desencolar();
				
				Console.Write(arbolAux.getDatoRaiz() + " ");
				
				if(!this.esHoja()){
					foreach(var hijo in arbolAux.getHijos())
						c.encolar(hijo);
				}
			}			
		}
		
		public int ancho(){
			Cola<ArbolGeneral<T>> c  = new Cola<ArbolGeneral<T>>();
			ArbolGeneral<T> arbolAux;
			int contArboles = 0, anchoMax = 0;
			
			c.encolar(this);
			c.encolar(null);
			anchoMax = 1;
			
			while(!c.esVacia()){
				arbolAux = c.desencolar();
				
				if(arbolAux == null){
					if(!c.esVacia())
						c.encolar(null);
					
					if(contArboles > anchoMax)
						anchoMax = contArboles;					
					
					contArboles = 0;					
				}
				else{
					// Incrementamos el contador de arboles por nivel
					contArboles++;
					
					// Encolamos hijos
					if(!this.esHoja())
					foreach(var hijo in arbolAux.getHijos())
						c.encolar(hijo);
				}				
			}
			
			return anchoMax;			
		}
		
		
	
	}
}
