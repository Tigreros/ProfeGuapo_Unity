#ifndef PERSONAJE_H
#define PERSONAJE_H

typedef struct {
	char nombre[20];
	int vida;
	int ataque;
} Personaje;

void modificar_por_valor(Personaje pj);
void modificar_por_puntero(Personaje* pj);

void imprimir_personaje(const char* etiqueta, Personaje* pj);

#endif