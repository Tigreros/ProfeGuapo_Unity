#include<stdio.h>
#include "personaje.h"

int main() {

	Personaje pj = { "Guerrero", 100, 50 };

	imprimir_personaje(&pj);

	modificar_por_valor(pj);
	imprimir_personaje(&pj);

	modificar_por_puntero(&pj);
	imprimir_personaje(&pj);

	return 0;
}