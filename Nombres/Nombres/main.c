#include <stdio.h>
#include <stdlib.h>
#include "Nombre.h"

int main() {

	char opcion;
	char** lista = NULL;
	int cantidad = 0;

	do {
		printf("Que quieres hacer");
		scanf(" %c", &opcion);

			switch(opcion)
			{
			case '+': {
				int nuevos;
				printf("Cuantos nombre quieres añadir quieres: ");
				scanf(" %d", &nuevos);
				cargar_nombres(&lista, &cantidad, nuevos);
				break;
			}

			case '-':
				liberar_nombres(&lista, &cantidad);
				break;

			case '=':
				mostrar_nombres(lista, cantidad);
				break;

			case 'x':
				printf("Saliste wey");
				liberar_nombres(&lista, &cantidad);
				break;

			default:
				printf("Opcion no valida");
				break;
			}

	} while (opcion != 'x');

	return 0;
}