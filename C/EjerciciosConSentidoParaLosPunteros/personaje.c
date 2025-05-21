#include<stdio.h>
#include<string.h>
#include "personaje.h"

void modificar_por_valor(Personaje pj)
{
	pj.vida = 0;
	strcpy(pj.nombre, "Copia");
	printf("Direccion valor: %p\n", (void*)&pj);
}

void modificar_por_puntero(Personaje* pj)
{
	pj->vida = 0;
	strcpy(pj->nombre, "Original");
	printf("Direccion puntero: %p\n", (void*)&pj);
}

void imprimir_personaje(const char* etiqueta Personaje* pj)
{
	printf("%s - Nombre: %s | Vida : %d | Ataque : %d | Direccion externa: %p\n", etiqueta, pj->nombre, pj->vida, pj->ataque, (void*)&pj);

}