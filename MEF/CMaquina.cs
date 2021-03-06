using System;


namespace MEF
{
	// Estructura usada para los objetos y la bateria
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
			ALEATORIO,
			BUSQUEDA,
			NBUSQUEDA,
			IRBATERIA,
			MUERTO,
			RECARGAR,
			
		};

		// Esta variable representa el estado actual de la maquina
		private int Estado;

		// Estas variables son las coordenadas del robot
		private int x,y;

		// Arreglo para guardar una copia de los objetos
		private S_objeto[] objetos = new S_objeto[10];
		private S_objeto bateria;

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

		public void Inicializa(ref S_objeto [] Pobjetos, S_objeto Pbateria)

		{
			// Colocamos una copia de los objetos y la bateria
			// para pode trabajar internamente con la informacion

			objetos=Pobjetos;
			bateria=Pbateria;

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
					if(indice==-1)	// Si ya no hay objetos, entonces aleatorio
                        Estado=(int)estados.IRBATERIA;
                        //Estado=(int)estados.ALEATORIO;
                    else
                        Estado =(int)estados.BUSQUEDA;

					break;
					
				case (int)estados.IRBATERIA:
					// Llevamos a cabo la accion del estado
					IrBateria();

					// Verificamos por transicion
					if(x==bateria.x && y==bateria.y)				
						Estado=(int)estados.MUERTO;

					break;

				case (int)estados.RECARGAR:

					// Hacemos la transicion
					Estado=(int)estados.BUSQUEDA;

					break;

				case (int)estados.MUERTO:
					
					break;

				case (int)estados.ALEATORIO:
					// Llevamos a cabo la accion del estado
					Aleatorio();

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
            // Buscamos el objeto m�s cerca
            for (int n = 0; n < 10; n++)
            {

                if (objetos[n].activo == true)
                {
                    //Calculamos cu�l pelota est� m�s cercana al Jugador
                    cercania = Math.Sqrt(Math.Pow((x - objetos[n].x), 2) + Math.Pow((y - objetos[n].y), 2));
                    if (mas_cercano > cercania)
                    {
                        mas_cercano = cercania;
                        indice = n;
                    }
                }
            }
        }

		public void Aleatorio()
		{
			// En esta funcion colocamos la logica del estado Aleatorio
			// Se mueve al azar

			// Cremos un objeto para tener valores aleatorios
			Random random=new Random();

			int nx=random.Next(0,3);
			int ny=random.Next(0,3);

			// Modificamos la posicion al azar
			x+=nx-1;
			y+=ny-1;

		}

		public void IrBateria()
		{
            // En esta funcion colocamos la logica del estado Ir Bateria

            // Nos dirigimos hacia la bateria
            if (x < bateria.x && bateria.x - x > 1)
                x += 2;
            else if (x < bateria.x && bateria.x - x == 1)
                x++;
            else if (x > bateria.x && x - bateria.x > 1)
                x -= 2;
            else if (x > bateria.x && x - bateria.x == 1)
                x++;


            if (y < bateria.y && bateria.y - y > 1)
                y += 2;
            else if (y < bateria.y && bateria.y - y == 1)
                y++;
            else if (y > bateria.y && y - bateria.y > 1)
                y -=2 ;
            else if (y > bateria.y && y - bateria.y == 1)
                y--;

		}


	}
}
