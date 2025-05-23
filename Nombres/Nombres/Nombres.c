#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include "Nombre.h"

void cargar_nombres(char*** lista, int* cantidad_actual, int nuevos)
{
	int total = *cantidad_actual + nuevos;

	char** nueva_lista = (char**)malloc(sizeof(char*) * total);
	if (nueva_lista == NULL) {
		printf("Error al reservar la memoria");
		return;
	}

	for (int i = 0; i < *cantidad_actual; i++) {
		nueva_lista[i] = (char*)malloc(50 * sizeof(char));
		strcpy(nueva_lista[i], (*lista)[i]);
		free((*lista)[i]);
	}
	free(*lista);

	for (int i = *cantidad_actual; i < total; i++) {
		nueva_lista[i] = (char*)malloc(50 * sizeof(char));
		printf(" Introduce el nombre: %d", i + 1);
		scanf(" %s", nueva_lista[i]);
	}

	*lista = nueva_lista;
	*cantidad_actual = total;
}

void mostrar_nombres(char** lista, int cantidad)
{
	if (lista == NULL || cantidad == 0) {
		return;
	}

	printf("Nombres actiuales: \n\n");

	for (int i = 0; i < cantidad; i++) {
		printf(" %s", lista[i]);
	}
}

void liberar_nombres(char*** lista, int* cantidad)
{
	if (*lista == NULL) return;

	for (int i = 0; i < *cantidad; i++) {
		free((*lista)[i]);
	}
	free(*lista);

	*lista = NULL;
	*cantidad = 0;

	printf("Lista limpia, memoria liberada");

}