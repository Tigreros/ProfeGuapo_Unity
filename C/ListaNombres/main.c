#include <stdio.h>
#include <stdlib.h>
#include "nombres.h"

int main() {

	char opcion;
	int cantidad = 0;
	int nuevos = 0;
	char** lista_de_nombres = NULL;

	do {

		printf("\n(+) : Agregar Nombres\n(-) : limpiar lista\n(=) : Mostrar la lista\n(x) : Salir de la aplicacion\n\n");
		scanf(" %c", &opcion);

		switch (opcion)
		{
		case '+':
			printf("¿Cuantos nombre mas qieres añadir tonto?");
			scanf("%d", &nuevos);
			cargar_nombres(&lista_de_nombres, &cantidad , nuevos);
			break;

		case '-':
			printf("Has limpiado la lista");
			liberar_nombres(&lista_de_nombres, &cantidad);
			break;

		case '=':
			mostrar_nombres(lista_de_nombres, &cantidad);
			break;

		case 'x':
			printf("Saliendo del programa...");
			liberar_nombres(&lista_de_nombres, &cantidad);
			break;

		default:
			printf("La opcion elegida no existe");
			break;
		}

	} while (opcion != 'x');

	return 0;
}