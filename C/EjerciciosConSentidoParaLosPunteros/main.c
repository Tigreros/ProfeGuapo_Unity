#include<stdio.h>
#include "personaje.h"

int main() {

	Personaje pj = { "Guerrero", 100, 50 };

	imprimir_personaje("ANTES", &pj);

	modificar_por_valor(pj);
	imprimir_personaje("DESPUES DE VALOR", &pj);

	modificar_por_puntero(&pj);
	imprimir_personaje("DESPUES DE PUNTERO", &pj);

	return 0;
}