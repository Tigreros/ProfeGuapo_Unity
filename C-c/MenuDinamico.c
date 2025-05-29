//#include <stdio.h>
//
//void saludar() {
//	printf("Hola que tal cerdo\n");
//}
//
//void preguntar(){
//	printf("Que tal estas?\n");
//}
//
//void despedir() {
//	printf("Adios perro sanche\n");
//}
//
//int main() {
//
//	void (*accion)();
//	char opcion;
//
//	printf("[S] saludar\n[P] preguntar\n[D] despedir\nElige una de estas opciones: ");
//	scanf(" %c", &opcion);
//
//	if (opcion == 's') {
//		accion = saludar;
//	}
//	else if (opcion == 'p') {
//		accion = preguntar;
//	}
//	else if (opcion == 'd') {
//		accion = despedir;
//	}
//	else {
//		printf("Opcion elegida no valida cochino\n");
//		return 1;
//	}
//
//	accion();
//	return 0;
//}