#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef struct
{
	char nombre[50];
	int vida;
	int defensa;
	int ataque;
} Personaje;

void accion_defender(Personaje* p) {
	printf(" %s se pone en guardia. Defensa aumenta a %d. \n", p->nombre, p->defensa);
}

void accion_ataque(Personaje* p) {
	printf(" %s Lanza un ataque de %d. \n", p->nombre, p->ataque);
}

void accion_curar(Personaje* p) {
	printf(" %s uso una pocion y restauro %d de vida \n", p->nombre, p->vida + 50);
}

void accion_huir(Personaje* p) {
	printf(" %s ha intentado huir del combate... \n", p->nombre);
	// Random de si el personaje pudo huir o no. 
}

void (*acciones[4])(Personaje*) = { accion_defender , accion_ataque , accion_curar , accion_huir };

int main() {
	
	Personaje pj;

	printf(" Nombre del personaje es : ");
	scanf(" %s", pj.nombre);
	pj.vida = 100;
	pj.defensa = 0;
	pj.ataque = 30;

	int opcion;
	int corriendo = 1;

	while (corriendo) {
		printf(" Que quieres hacer %s \n", pj.nombre);
		
		printf("1. Defender, 2. Atacar, 3. Curar, 4. Huir\nSelecciona una accion : \n");
		
		scanf(" %d", &opcion);

		if (opcion >= 1 && opcion <= 4) {
			if (opcion == 4) {
				corriendo = 0;
			}
			else 
			{
				acciones[opcion - 1](&pj);
			}
		}
		else 
		{
			printf("Esa opcion no existen tonto");
		}
	}
		 
	return 0; 
}
