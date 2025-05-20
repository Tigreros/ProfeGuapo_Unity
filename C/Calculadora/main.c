#include <stdio.h>
#include "calculadora.h"
#include <math.h>

int main() {
	int a, b;
	char operaciones;



	// Calculo de volumen de un cubo
	printf("Introduce el valor del lado de tu cubo : ");

	scanf_s("%d", &a);

	float area = mult(a, a);
	float volumen = mult(area, a);

	printf("El volumen del cubo es: %f", volumen);


	// Calculo de lo que tardaria el bala en recorrer la hipotenusa de ese cubo


	float distancia = a * sqrt(3);

	//printf("\nla bala recorre : %f tanos metros", distancia);
	printf("\n\n\nla bala recorre : %f metros", distancia);




















	//printf("Introduce el segundo numero : ");

	//scanf_s("%d", &b);

	//printf("Introduce el tipo de operacion\n(S)= suma\n(R)= resta\n(M)= Multiplicar\n(D)= dividir : \n\n\n");

	//scanf_s(" %c", &operaciones, 1);

	//float resultado;

	//	switch (operaciones) {
	//		case 'S':
	//			resultado = suma(a, b);
	//			break;
	//		case 'R':
	//			resultado = resta(a, b);
	//			break;
	//		case 'M':
	//			resultado = mult(a, b);
	//			break;
	//		case 'D':
	//			if (b == 0) {
	//				printf("ERROR: NO SE PUEDE DIVIDIR POR CERO\n\n");
	//			}
	//			resultado = div(a, b);
	//			break;
	//		default:
	//			printf("WARNING: Operacion no valida\n\n");
	//			return -1;
	//	}

	//printf("el resultado de tu operacion es: %f \n ", resultado);
	return 0;
}