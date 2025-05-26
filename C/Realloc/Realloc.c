#include <stdio.h>
#include <stdlib.h>

int main() {

	int* numeros = NULL; // 1. creamos un puntero a int para almacenar numeros
	int cantidad = 0;

	printf("¿Cuantos numeros deseas ingersar en la lista?\n");
	scanf(" %d", &cantidad);

	// 2. Reservar en memoria
	numeros = (int*)malloc(cantidad * sizeof(int));

	// 3. Validamos se malloc funcionó
	if (numeros == NULL) {
		printf("Error al reservar memoria\n");
		return 1;
	}

	// 4. Cargamos los números iniciales
	for (int i = 0; i < cantidad; i++) {
		printf("Introduce el numero %d :", i + 1);
		scanf(" %d", &numeros[i]);
	}

	// 5. pedr aumentar el tamaño del bloque de memoria
	int nuevos;
	printf("\n¿Cuanto smas quieres?");
	scanf(" %d", &nuevos);

	// 6. vamos a usar realloc para aumentar el tamaño del array
	int* temp = (int*)realloc(numeros, (cantidad + nuevos) * sizeof(int));

	// 7. Validamos si realloc ha funcionado
	if (temp == NULL) {
		printf("No se puede ampliar la memoria pringao\n");
		free(numeros);
		return 1;
	}

	// 8. Actualizar el puntero original
	numeros = temp;

	// 9. Añadir al puntero original los nuevos numeros
	for (int i = cantidad; i < cantidad + nuevos; i++) {
		printf("Introduce el numero %d :", i + 1);
		scanf(" %d", &numeros[i]);
	}

	// 10. Mostrar el contenido 
	printf("contenido de la lista es: \n");
	for (int i = 0; i < cantidad + nuevos; i++) {
		printf(" %d \n", numeros[i]);
	}

	// 11. Nos aseguramos de cuando termine la aplicacion. Liberar toda la memoria que hemos usado
	free(numeros);
	printf("la lista numeros ha quedado liberada, comprobamos con su valor %d", numeros);

	return 0;
}