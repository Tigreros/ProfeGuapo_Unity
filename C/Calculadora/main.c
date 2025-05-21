#include <stdio.h>
#include "calculadora.h"
#include <math.h>

int main() {

	int x = 5;		// variable normal
	int* p = &x;	// puntero que guarda la dirección de x

	printf("Valor de X: %d", x);

	printf("\nDirección de X: %p: ", (void*)&x);

	printf("\nValor al que apunta p (*p): %d: ", *p);

	scanf_s("%d", &x);

	//x = 30;
	// Modificando el valor de x a través del puntero

	printf("\nDespues de X: %d", x);

	printf("\nDespues direccion de X: %p: ", (void*)&x);

	printf("\nDespues al que apunta p (*p): %d: \n\n\n", *p);

	scanf_s("%d", p);


	printf("\nDespues de X: %d", x);

	printf("\nDespues direccion de X: %p: ", (void*)&x);

	printf("\nDespues al que apunta p (*p): %d: \n\n\n", *p);

	return 0;

}




































	//int a, b;
	//char operaciones;



	//// Calculo de volumen de un cubo
	//printf("Introduce el valor del lado de tu cubo : ");

	//scanf_s("%d", &a);

	//float area = mult(a, a);
	//float volumen = mult(area, a);

	//printf("El volumen del cubo es: %f", volumen);


	//// Calculo de lo que tardaria el bala en recorrer la hipotenusa de ese cubo


	//float distancia = a * sqrt(3);

	////printf("\nla bala recorre : %f tanos metros", distancia);
	//printf("\n\n\nla bala recorre : %f metros", distancia);








	//int x = 10;

	//int* p = &x;




	//int* p = &x;





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

//}