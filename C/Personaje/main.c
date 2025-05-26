#include<stdio.h>
#include "personaje.h"

int main() {

	Personaje player;

	printf("Inroduce el nombre del personaje:\n");
	scanf(" %s", player.nombre);

	printf("Inroduce la vida del personaje:\n");
	scanf(" %d", &player.vida);

	printf("Inroduce el ataque del personaje:\n");
	scanf(" %d", &player.ataque);

	imprimir_personaje("ANTES", &player);

	modificar_por_valor(player);
	imprimir_personaje("DESPUES DE VALOR", &player);

	modificar_por_puntero(&player);
	imprimir_personaje("DESPUES DE PUNTERO", &player);

	return 0;
}
