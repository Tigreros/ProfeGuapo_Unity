#include <stdio.h>
#include <string.h>
#include "nombres.h"
#include <stdlib.h>

void cargar_nombres(char*** lista, int* cantidad, int nuevos) {
	
	int total = *cantidad + nuevos;
	char** nueva_lista = (char**)malloc(sizeof(char*) * total);
	*lista = (char**)malloc(sizeof(char*) * *cantidad);

	if (*nueva_lista == NULL) {
		printf("Error al reservar memoria, el usuario no ha introucido ninguna lista");
		return; 
	}


	for (int i = 0; i < *cantidad; i++) {
		nueva_lista[i] = (char*)malloc(50 * sizeof(char));
		strcpy(nueva_lista[i], (*lista)[i]);
		free(*lista[i]);
	}
	free(*lista);


	for (int i = *cantidad; i < total; i++) {
		nueva_lista[i] = (char*)malloc(50 * sizeof(char));
		printf("introduzca el nombre %d", i + 1);
		scanf(" %s", nueva_lista[i]);
	}

	*lista = nueva_lista;
	*cantidad = total;
}

void mostrar_nombres(char** lista, int cantidad) {
	if (lista == NULL || cantidad == 0) {
		printf("\n la lista esta vacia \n");
		return;
	}
	printf("\n Nombres en la lista: \n");
	for (int i = 0; i < cantidad; i++) {
		printf("%s\n", lista[i]);
	}
}

void liberar_nombres(char*** lista, int* cantidad) {
	printf("\n\n");
	if (*lista == NULL) {
		return;
	}
	for (int i = 0; i < *cantidad; i++) {
		printf("Este tontito lo funamos, %s\n", lista[i]);
		free((*lista)[i]);
	}
	free(*lista);
	*lista = NULL;
	*cantidad = 0;

	printf("\n la lista esta vacia \n");
}