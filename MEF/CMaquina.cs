using System;


namespace MEF
{
	// Estructura usada para los objetos y la estrella
	public struct S_objeto
	{
		public bool activo;	// Indica si el objeto es visible o no
		public int x,y;		// Coordenadas del objeto
	}

    /// <summary>
    /// Esta clase representa a nuestra maquina de estados finitos.
    /// </summary>
    public class CMaquina
	{
		// Enumeracion de los diferentes estados
		public enum  estados
		{
			X,
			BUSQUEDA,
			NBUSQUEDA,
			ESTRELLA,
			GANADOR,
			
		};

		// Esta variable representa el estado actual de la maquina
		private int Estado;

		// Estas variables son las coordenadas del personaje
		private int x,y;

		// Arreglo para guardar una copia de los objetos
		private S_objeto[] objetos = new S_objeto[10];
		private S_objeto estrella;

		// Variable del indice del objeto que buscamos
		private int indice;

		// Creamos las propiedades necesarias
		public int CoordX 
		{
			get {return x;}
		}

		public int CoordY
		{
			get {return y;}
		}

		public int EstadoM
		{
			get {return Estado;}
		}
			
		public CMaquina()
		{
			// Este es el contructor de la clase

			// Inicializamos las variables

			Estado=(int)estados.NBUSQUEDA;	// Colocamos el estado de inicio.
			x=320;		// Coordenada X
			y=240;		// Coordenada Y
			indice=-1;	// Empezamos como si no hubiera objeto a buscar
		}

		public void Inicializa(ref S_objeto [] Pobjetos, S_objeto Pestrella)

		{
			// Colocamos una copia de los objetos y la estrella
			// para pode trabajar internamente con la informacion

			objetos=Pobjetos;
            estrella = Pestrella;

		}

		public void Control()
		{
			// Esta funcion controla la logica principal de la maquina de estados
			
			switch(Estado)
			{
			    case (int)estados.BUSQUEDA:
					// Llevamos a cabo la accion del estado
					Busqueda();

					// Verificamos por transicion
					if(x==objetos[indice].x && y==objetos[indice].y)
					{
						// Desactivamos el objeto encontrado
						objetos[indice].activo=false;
						
						// Cambiamos de estado
						Estado=(int)estados.NBUSQUEDA;

					}

				break;

				case (int)estados.NBUSQUEDA:
					// Llevamos a cabo la accion del estado
					NuevaBusqueda();

					// Verificamos por transicion
					if(indice==-1)
                        Estado=(int)estados.ESTRELLA;
                    else
                        Estado =(int)estados.BUSQUEDA;

				break;
					
				case (int)estados.ESTRELLA:
					// Llevamos a cabo la accion del estado
					IrEstrella();

					// Verificamos por transicion
					if(x==estrella.x && y==estrella.y)				
						Estado=(int)estados.GANADOR;

				break;

			}

		}

		public void Busqueda()
		{
            // En esta funcion colocamos la logica del estado Busqueda

            // Nos dirigimos hacia el objeto actual
            if (x < objetos[indice].x && objetos[indice].x - x > 1)
                x += 2;
            else if (x < objetos[indice].x && objetos[indice].x - x == 1)
                x++;
            else if (x > objetos[indice].x && x - objetos[indice].x > 1)
                x -= 2;
            else if (x > objetos[indice].x && x - objetos[indice].x == 1)
                x++;


            if (y < objetos[indice].y && objetos[indice].y - y > 1)
                y += 2;
            else if (y < objetos[indice].y && objetos[indice].y - y == 1)
                y++;
            else if (y > objetos[indice].y && y - objetos[indice].y > 1)
                y -=2 ;
            else if (y > objetos[indice].y && y - objetos[indice].y == 1)
                y--;


        }

		public void NuevaBusqueda()
		{
			// En esta funcion colocamos la logica del estado Nueva Busqueda
			// Verificamos que haya otro objeto a buscar
			indice=-1;

            double cercania, mas_cercano=99999;
            // Buscamos el objeto más cerca
            for (int n = 0; n < 10; n++)
            {

                if (objetos[n].activo == true)
                {
                    //Calculamos cuál pelota está más cercana al Jugador
                    cercania = Math.Sqrt(Math.Pow((x - objetos[n].x), 2) + Math.Pow((y - objetos[n].y), 2));
                    if (mas_cercano > cercania)
                    {
                        mas_cercano = cercania;
                        indice = n;
                    }
                }
            }
        }

		public void IrEstrella()
		{
            // En esta funcion colocamos la logica del estado Estrella

            // Nos dirigimos hacia la estrella
            if (x < estrella.x && estrella.x - x > 1)
                x += 2;
            else if (x < estrella.x && estrella.x - x == 1)
                x++;
            else if (x > estrella.x && x - estrella.x > 1)
                x -= 2;
            else if (x > estrella.x && x - estrella.x == 1)
                x++;


            if (y < estrella.y && estrella.y - y > 1)
                y += 2;
            else if (y < estrella.y && estrella.y - y == 1)
                y++;
            else if (y > estrella.y && y - estrella.y > 1)
                y -=2 ;
            else if (y > estrella.y && y - estrella.y == 1)
                y--;

		}
        
	}

}
