#include<stdio.h>
#include<string.h>
#include "personaje.h"

void modificar_por_valor(Personaje pj)
{
	pj.vida = 0;
	//strcpy_s(pj.nombre, 10240, "Copia");
	printf("Direccion valor: %p\n", (void*)&pj);
}

void modificar_por_puntero(Personaje* pj)
{
	pj->vida = 0;
	//strcpy_s(pj->nombre, 10240, "Original");
	printf("Direccion puntero: %p\n", (void*)&pj);
}

void imprimir_personaje(Personaje* pj)
{
	printf("Nombre: %s | Vida : %d | Ataque : %d | Direccion externa: %p\n", pj->nombre, pj->vida, pj->ataque, (void*)&pj);
}