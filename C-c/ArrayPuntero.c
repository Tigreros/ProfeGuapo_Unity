#include <stdio.h>

void accion_saludar() {
	printf("Hola que tal cerdo\n");
}

void accion_preguntar(){
	printf("Que tal estas?\n");
}

void accion_despedir() {
	printf("Adios perro sanche\n");
}

int main() {
	void (*acciones[3])() = { accion_saludar, accion_preguntar, accion_despedir };

	int opcion;

	printf("Menu de acciones: \n [1] Saludar\n [2] Preguntar\n [3] Despedir\nSelecciona una de estas treas acciones (1 - 3)");
	scanf(" %d", &opcion);

	if (opcion >= 1 && opcion <= 3) {
		acciones[opcion - 1]();
	}
	else {
		printf("\n\nOpcion no valida flipao\n\n");
		return 1;
	}
	return 0;
}