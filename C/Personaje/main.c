#include<stdio.h>
#include "personaje.h"

int main() {

	char nombre[20];
	int vida;
	int ataque;

	printf("Inroduce el nombre del personaje:\n");
	scanf("%s", &nombre);

	printf("Inroduce la vida del personaje:\n");
	scanf("%d", &vida);

	printf("Inroduce el ataque del personaje:\n");
	scanf("%d", &ataque);


	Personaje pj = { nombre, vida, ataque };

	imprimir_personaje("ANTES", &pj);

	modificar_por_valor(pj);
	imprimir_personaje("DESPUES DE VALOR", &pj);

	modificar_por_puntero(&pj);
	imprimir_personaje("DESPUES DE PUNTERO", &pj);

	return 0;
}
//
//
//#include<stdio.h>
//#include"Personaje.h"
//
//int main() {
//
//
//	Personaje pj = { nombre, vida, ataque };
//
// 
//	imprimir_personaje(&pj);
//
//	modificar_por_valor(pj);
//	imprimir_personaje(&pj);
//
//	modificar_por_puntero(&pj);
//	imprimir_personaje(&pj);
//	return 0;
//}