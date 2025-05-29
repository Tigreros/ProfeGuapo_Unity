//#include <stdio.h>
//
//void saludar() {
//	printf("Hola que tal cerdo\n");
//}
//
//void despedir() {
//	printf("Adios perro sanche\n");
//}
//
//void ejecutar_accion(void (*accion)()) {
//	printf("[Ejecutando ACCION...]\n");
//	accion();
//	printf("[FIN DE LA ACCION]\n\n");
//}
//
//int main() {
//
//	char opcion; 
//
//	printf("[S] saludar\n[D] despedir\nElige una de estas opciones: ");
//	scanf(" %c", &opcion);
//
//	if (opcion == 's') {
//		ejecutar_accion(saludar);
//	}
//	else if (opcion == 'p') {
//		ejecutar_accion(despedir);
//	}
//	else {
//		printf("Opcion elegida no valida cochino\n");
//		return 1;
//	}
//
//	return 0;
//}